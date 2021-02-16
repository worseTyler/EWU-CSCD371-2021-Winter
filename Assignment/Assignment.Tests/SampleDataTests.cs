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
        public void GetUniqueSortedListOFStatesGivenCsvRows_HardCodedList_ReturnsList()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void GetUniqueSortedListOFStatesGivenCsvRows_UsingLinq_ReturnsOrderedList()
        {
            SampleData sampleData = new();
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            bool result = states.SequenceEqual(states.OrderBy(item => item));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsStringofStates()
        {
            SampleData sampleData = new();
            string expected = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
            string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void People_GivenRows_CreatesSortedPeopleEnum()
        {
            SampleData sampleData = new();
            IEnumerable<IPerson> actual = sampleData.CsvRows.Select(item =>
            {
                string[] items = item.Split(',');
                Person person = new(items[1], items[2], new Address(items[4], items[5], items[6], items[7]), items[4]);
                return person;
            }).OrderBy(item => item.Address.State)
            .ThenBy(item => item.Address.City)
            .ThenBy(item => item.Address.Zip);

            IEnumerable<(IPerson,IPerson)> output = actual.Zip(sampleData.People);
            foreach((IPerson, IPerson) item in output)
            {
                Assert.AreEqual(item.Item1.FirstName, item.Item2.FirstName);
            }
        }
    }
}
