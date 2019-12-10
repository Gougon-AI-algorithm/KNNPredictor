using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNPredictor
{
    public class Factor
    {
        public double _wind = 0;
        public double _power = 0;
        public double _pitch = 0;
        public double _euclidean = 0;

        public Factor(double wind, double power, double pitch)
        {
            _wind = wind;
            _power = power;
            _pitch = pitch;
        }

        public Factor(double wind, double power, double pitch, double euclidean)
        {
            _wind = wind;
            _power = power;
            _pitch = pitch;
            _euclidean = euclidean;
        }
    }
}
