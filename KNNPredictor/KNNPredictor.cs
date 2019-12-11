using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNNPredictor
{
    public partial class KNNPredictor : Form
    {
        private const string PITCH_TEXT = "Pitch : ";

        private const string OPEN_CSV_FAIL_CODE = "CSV_OPEN_FAIL";
        private const string OPEN_CSV_FAIL_MSG = "Filed to open csv!";

        private const string INPUT_ERROR_MSG = "Input error!";

        private KNNPredictorSevice _knnService = null;

        public KNNPredictor()
        {
            InitializeComponent();
            _knnService = new KNNPredictorSevice();
            _selectFileButton.Click += ClickSelectFileButton;
            _predictButton.Click += ClickPredictButton;
        }

        #region Click select file button
        public void ClickSelectFileButton(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filePath = GetCSVFilePath(openFileDialog);
            if (filePath == OPEN_CSV_FAIL_CODE)
            {
                ShowFileError();
            }
            else
            {
                _knnService.InitializeKNN(filePath);
            }
        }

        private string GetCSVFilePath(OpenFileDialog openFileDialog)
        {
            string filePath = OPEN_CSV_FAIL_CODE;

            openFileDialog.Filter = "(*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }

            return filePath;
        }

        private void ShowFileError()
        {
            MessageBox.Show(OPEN_CSV_FAIL_MSG);
        }
        #endregion

        #region Click predict button
        public void ClickPredictButton(object sender, EventArgs e)
        {
            if (_knnService.KNNExist)
            {
                string error = CheckInput();
                if (error == KNNPredictorSevice.INPUT_ERROR_CODE)
                {
                    ShowInputError();
                }
                else
                {
                    PredictPitch();
                }
            }
        }

        private string CheckInput()
        {
            return _knnService.CheckInput(_windTextBox.Text, _powerTextBox.Text);
        }

        private void ShowInputError()
        {
            MessageBox.Show(INPUT_ERROR_MSG);
        }

        private void PredictPitch()
        {
            double wind = double.Parse(_windTextBox.Text);
            double power = double.Parse(_powerTextBox.Text);
            double predictPitch = _knnService.Predict(wind, power);
            _pitchLabel.Text = PITCH_TEXT + predictPitch.ToString();
        }
        #endregion
    }
}
