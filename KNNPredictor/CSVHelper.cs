using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNPredictor
{
    public class CSVHelper
    {
        private string ENCODING = "big5";

        private string[] _lines = null;

        public CSVHelper(string filePath)
        {
            _lines = OpenCSVFile(filePath);
        }

        private string[] OpenCSVFile(string filePath)
        {
            Encoding encoding = Encoding.GetEncoding(ENCODING);
            string[] lines = null;
            try
            {
                return System.IO.File.ReadAllLines(filePath, encoding);
            }
            catch
            {
                throw new Exception("Close the csv file.");
            }
        }

        public void ClearUnnecessaryRows(params string[] unnecassaryRowNames)
        {
            List<string> necessaryRows = new List<string>();

            for (int rowNum = 0; rowNum < _lines.Length; rowNum++)
            {
                string[] row = GetRow(rowNum);
                if (IsRowNecessary(row, unnecassaryRowNames))
                    necessaryRows.Add(_lines[rowNum]);
            }

            _lines = necessaryRows.ToArray();
        }

        private bool IsRowNecessary(string[] row, string[] unnecessaryRowNames)
        {
            return !unnecessaryRowNames.Contains(row[0]);
        }

        public double[] GetColumnDatas(string columnName)
        {
            int order = GetColumnNumWithName(columnName);
            string[] datas = GetColumnDatasWithOrder(order);
            return TransformColumnFromStringToDouble(datas);
        }
        
        private int GetColumnNumWithName(string columnName)
        {
            HandleCSVIsOpen();

            string[] attrs = GetAttributes();
            if (attrs.Contains(columnName))
                return Array.IndexOf(attrs, columnName);
            else
                return -1;
        }

        private string[] GetAttributes()
        {
            HandleCSVIsOpen();

            string[] attrs = _lines[0].Split(',');
            return attrs;
        }

        private string[] GetColumnDatasWithOrder(int order)
        {
            HandleCSVIsOpen();

            int dataLength = _lines.Length;
            string[] datas = new string[dataLength-1];

            // Drop attribute row
            for (int rowNum = 1; rowNum < dataLength; rowNum++)
            {
                string[] row = GetRow(rowNum);
                datas[rowNum-1] = row[order];
            }

            return datas;
        }

        private string[] GetRow(int rowNum)
        {
            HandleCSVIsOpen();

            string[] row = _lines[rowNum].Split(',');
            return row;
        }

        private double[] TransformColumnFromStringToDouble(string[] stringDatas)
        {
            int dataLength = stringDatas.Length;
            double[] datas = new double[dataLength];
            for (int rowNum = 0; rowNum < dataLength; rowNum++)
            {
                datas[rowNum] = TryParseStringToDouble(stringDatas[rowNum]);
            }
            return datas;
        }

        public double TryParseStringToDouble(string num)
        {
            try
            {
                return double.Parse(num);
            }
            catch
            {
                throw new Exception("Can't parse " + num + " to double.");
            }
        }

        private void HandleCSVIsOpen()
        {
            if (_lines == null)
                throw new Exception("You don't open the csv file.");
        }
    }
}
