using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRowsProperty_GivenFilePath_LoadsDataProperly()
        {
            SampleData sampleData = new();
            IEnumerable<string> enumerable = sampleData.CsvRows;

            Assert.AreEqual("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", enumerable.First());
        }
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual<int>(1, 1);
        }

    }
}
