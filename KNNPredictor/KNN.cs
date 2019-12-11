using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNPredictor
{
    public class KNN
    {
        CSVHelper _csvHelper = null;

        List<Factor> _factors = null;

        public KNN(string filePath)
        {
            _csvHelper = new CSVHelper(filePath);
            _csvHelper.ClearUnnecessaryRows("R80711", "R80736");
            if (_factors != null)
                _factors.Clear();
        }

        public void DecideFactors(string wsFactor, string pFactor, string baFactor)
        {
            _csvHelper.ClearNARows(wsFactor, pFactor, baFactor);
            List<double> winds = _csvHelper.GetColumnDatas(wsFactor);
            List<double> powers = _csvHelper.GetColumnDatas(pFactor);
            List<double> pitches = _csvHelper.GetColumnDatas(baFactor);
            _factors = new List<Factor>();
            for (int rowNum = 0; rowNum < winds.Count; rowNum++)
            {
                double wind = winds[rowNum];
                double power = powers[rowNum];
                double pitch = pitches[rowNum];
                _factors.Add(new Factor(wind, power, pitch));
            }
        }

        public double Predict(double wind, double power)
        {
            double predictPitch = double.MinValue;
            Factor factor = new Factor(wind, power, 0);
            List<Factor> neighbors = GetNeighbors(factor);
            predictPitch = GetPitchWhichMostOftenInNeighbor(neighbors);
            return predictPitch;
        }

        private List<Factor> GetNeighbors(Factor factor)
        {
            List<Factor> euclideanFactors = GetEuclideanFactors(factor);
            euclideanFactors = euclideanFactors.OrderBy(val => val._euclidean).ToList();
            List<Factor> neighborFactors = new List<Factor>();
            for (int count = 0; count < 10; count++)
            {
                neighborFactors.Add(euclideanFactors[count]);
            }
            return neighborFactors;
        }

        private List<Factor> GetEuclideanFactors(Factor predictFactor)
        {
            List<Factor> euclideanFactors = new List<Factor>();
            int dataLength = _factors.Count;
            for (int rowNum = 0; rowNum < dataLength; rowNum++)
            {
                Factor curFactor = _factors[rowNum];
                Factor euclideanFactor = GetEuclideanFactor(curFactor, predictFactor);
                euclideanFactors.Add(euclideanFactor);
            }
            return euclideanFactors;
        }

        private Factor GetEuclideanFactor(Factor curFactor, Factor predictFactor)
        {
            double distance = GetEuclideanDistance(curFactor, predictFactor);
            Factor euclideanFactor = new Factor(curFactor._wind, curFactor._power, curFactor._pitch, distance);
            return euclideanFactor;
        }

        private double GetEuclideanDistance(Factor factor, Factor predict)
        {
            double windDiff = Math.Abs(factor._wind - predict._wind);
            double powerDiff = Math.Abs(factor._power - predict._power);
            double euclideanDistance = Math.Pow(windDiff, 2) + Math.Pow(powerDiff, 2);
            return euclideanDistance;
        }

        public double GetPitchWhichMostOftenInNeighbor(List<Factor> neighbors)
        {
            Dictionary<double, int> pitchCounts = new Dictionary<double, int>();
            foreach (Factor neighbor in neighbors)
            {
                CountingPitch(pitchCounts, neighbor._pitch);
            }
            double mostOftenPitch = GetBiggestCountInPitchCounts(pitchCounts);
            return mostOftenPitch;
        }

        private void CountingPitch(Dictionary<double, int> pitchCounts, double neighborPitch)
        {
            if (pitchCounts.ContainsKey(neighborPitch))
            {
                pitchCounts[neighborPitch]++;
            }
            else
            {
                pitchCounts.Add(neighborPitch, 0);
            }
        }

        private double GetBiggestCountInPitchCounts(Dictionary<double, int> pitchCounts)
        {
            KeyValuePair<double, int> mostOftenPitchCount = new KeyValuePair<double, int>(0, 0);
            foreach(KeyValuePair<double, int> pitchCount in pitchCounts)
            {
                if (pitchCount.Value > mostOftenPitchCount.Value)
                    mostOftenPitchCount = pitchCount;
            }
            return mostOftenPitchCount.Key;
        }
    }
}
