using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNPredictor
{
    public class KNN
    {
        CSVHelper _csvHelper = null;

        public KNN(string filePath)
        {
            _csvHelper = new CSVHelper(filePath);
            _csvHelper.ClearUnnecessaryRows("R80711", "R80736");
        }

        public double Predict(string wsFactor, string pFactor, string baFactor)
        {
            double predictPitch = double.MinValue;

            



            return predictPitch;
        }
    }
}
