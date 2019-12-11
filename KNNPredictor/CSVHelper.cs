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

        public void ClearNARows(params string[] attrs)
        {
            List<string> necessaryRows = new List<string>();
            necessaryRows.Add(_lines[0]);

            for (int rowNum = 0; rowNum < _lines.Length; rowNum++)
            {
                string[] row = GetRow(rowNum);
                if (!IsRowHasNA(attrs, row))
                    necessaryRows.Add(_lines[rowNum]);
            }

            _lines = necessaryRows.ToArray();
        }

        private bool IsRowHasNA(string[] attrs, string[] row)
        {
            foreach (string attr in attrs)
            {
                int attrOrder = GetColumnNumWithName(attr);
                if (!IsDouble(row[attrOrder]))
                    return true;
            }
            return false;
        }

        public List<double> GetColumnDatas(string columnName)
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

        private List<double> TransformColumnFromStringToDouble(string[] stringDatas)
        {
            int dataLength = stringDatas.Length;
            List<double> datas = new List<double>();
            for (int rowNum = 0; rowNum < dataLength; rowNum++)
            {
                if (IsDouble(stringDatas[rowNum]))
                {
                    datas.Add(double.Parse(stringDatas[rowNum]));
                }
            }
            return datas;
        }

        private bool IsDouble(string str)
        {
            double temp = 0;
            return double.TryParse(str, out temp);
        }

        private void HandleCSVIsOpen()
        {
            if (_lines == null)
                throw new Exception("You don't open the csv file.");
        }
    }
}
