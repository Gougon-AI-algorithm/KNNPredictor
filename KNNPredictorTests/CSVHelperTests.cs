using Microsoft.VisualStudio.TestTools.UnitTesting;
using KNNPredictor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KNNPredictor.Tests
{
    [TestClass()]
    public class CSVHelperTests
    {
        CSVHelper _csvHelper = null;
        PrivateObject _csvObject = null;

        [TestInitialize()]
        public void Initialize()
        {
            _csvHelper = new CSVHelper("../../wind_power_data_2017_2020.csv");
            _csvObject = new PrivateObject(_csvHelper);
        }

        [TestMethod()]
        public void CSVHelperTest()
        {
            string[] lines = (string[])_csvObject.GetField("_lines");
            Assert.AreEqual(lines[1], "R1,##,0.8,-1");
        }

        [TestMethod()]
        public void ClearUnnecessaryRowsTest()
        {
            _csvHelper.ClearUnnecessaryRows("R1", "R2");

            string[] lines = (string[])_csvObject.GetField("_lines");
            Assert.AreEqual(lines[1], "R3,##,45.5,45.5");
        }

        [TestMethod()]
        public void GetColumnDatasTest()
        {
            double[] datas = { 0.8, -1, 45.5 };
            List<double> predictDatas = _csvHelper.GetColumnDatas("Attr1");

            Assert.AreEqual(datas[0], predictDatas[0]);
            Assert.AreEqual(datas[1], predictDatas[1]);
            Assert.AreEqual(datas[2], predictDatas[2]);
        }

        [TestMethod()]
        public void GetColumnNumWithNameTest()
        {
            Assert.AreEqual(_csvObject.Invoke("GetColumnNumWithName", "Attr1"), 2);
            Assert.AreEqual(_csvObject.Invoke("GetColumnNumWithName", "Attr3"), -1);
        }

        [TestMethod()]
        public void GetAttributesTest()
        {
            string[] attrs = { "Serial_number", "Date_time", "Attr1", "Attr2" };
            string[] predictAttrs = (string[])_csvObject.Invoke("GetAttributes");

            Assert.AreEqual(attrs[0], predictAttrs[0]);
            Assert.AreEqual(attrs[1], predictAttrs[1]);
            Assert.AreEqual(attrs[2], predictAttrs[2]);
            Assert.AreEqual(attrs[3], predictAttrs[3]);
        }

        [TestMethod()]
        public void GetColumnDatasWithOrderTest()
        {
            string[] datas = { "0.8", "-1", "45.5" };
            string[] predictDatas = (string[])_csvObject.Invoke("GetColumnDatasWithOrder", 2);

            Assert.AreEqual(datas[0], predictDatas[0]);
            Assert.AreEqual(datas[1], predictDatas[1]);
            Assert.AreEqual(datas[2], predictDatas[2]);
        }

        [TestMethod()]
        public void GetRowTest()
        {
            string[] datas = { "R1", "##", "0.8", "-1" };
            string[] predictDatas = (string[])_csvObject.Invoke("GetRow", 1);

            Assert.AreEqual(datas[0], predictDatas[0]);
            Assert.AreEqual(datas[1], predictDatas[1]);
            Assert.AreEqual(datas[2], predictDatas[2]);
            Assert.AreEqual(datas[3], predictDatas[3]);
        }

        // [TestMethod()]
        // public void ParseDoubleToDoubleTest()
        // {
        //     _csvObject.Invoke("TryParseStringToDouble", "-1.5");
        // }
    }
}