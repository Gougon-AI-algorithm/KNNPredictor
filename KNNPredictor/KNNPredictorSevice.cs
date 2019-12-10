﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNPredictor
{
    public class KNNPredictorSevice
    {
        public const string INPUT_CORRECT_CODE = "INPUT_CORRECT";
        public const string INPUT_ERROR_CODE = "INPUT_ERROR";

        private KNN _knn = null;

        public void InitializeKNN(string filePath)
        {
            _knn = new KNN(filePath);
        }

        public bool KNNExist
        {
            get
            {
                return _knn != null;
            }
        }

        public string CheckInput(string winds, string power)
        {
            if (winds.All(char.IsNumber) && power.All(char.IsNumber))
            {
                return INPUT_CORRECT_CODE;
            }
            return INPUT_ERROR_CODE;
        }

        public double Predict()
        {
            double predictPitch = double.MinValue;

            // if (_knn != null)
                // predictPitch = _knn.Predict();

            return predictPitch;
        }
    }
}