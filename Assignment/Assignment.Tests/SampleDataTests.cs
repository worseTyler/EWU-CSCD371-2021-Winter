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
        public void GetUniqueSortedListOFStatesGivenCsvRows_UsingLinq_ReturnsOrderedList()
        {
            SampleData sampleData = new();
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            // Comparing the states content with itself after "manually" distinct/ordered
			bool result = states.SequenceEqual(states.Distinct().OrderBy(item => item));

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
			IEnumerable<IPerson> actual = sampleData.People;

			IEnumerable<IPerson> expected = sampleData.People
				.OrderBy(item => item.Address.State)
				.ThenBy(item => item.Address.City)
				.ThenBy(item => item.Address.Zip);

			IEnumerable<(IPerson,  IPerson)> output = actual.Zip(expected);

            Assert.IsTrue(output.All(item =>
                (item.Item1.FirstName == item.Item2.FirstName) &&
                (item.Item1.LastName == item.Item2.LastName) &&
                (item.Item1.EmailAddress == item.Item2.EmailAddress)));
        }

        [TestMethod]
        public void People_WithHardCodedPerson_FoundInList()
        {
            //Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577
            Address address = new("7884 Corry Way", "Helena", "MT", "70577");
            Person person = new("Priscilla", "Jenyns", address, "pjenyns0@state.gov");
            SampleData sampleData = new();

            bool output = sampleData.People.Any(item =>
            (item.FirstName == person.FirstName &&
            item.LastName == person.LastName &&
            item.EmailAddress == person.EmailAddress &&
            item.Address.StreetAddress == person.Address.StreetAddress &&
            item.Address.City == person.Address.City &&
            item.Address.State == person.Address.State &&
            item.Address.Zip == person.Address.Zip));

            Assert.IsTrue(output);
        }

        [TestMethod]
        public void FilterByEmailAddress_GivenValidPreicate_ReturnsPerson()
        {
            SampleData sampleData = new();
            IEnumerable<(string, string)> actual = sampleData.FilterByEmailAddress(item => item.Contains("stanford"));

            bool personOne = actual.Any(item => item.Item1 == "Sancho" && item.Item2 == "Mahony");
            bool personTwo = actual.Any(item => item.Item1 == "Fayette" && item.Item2 == "Dougherty");

            Assert.IsTrue(personOne);
            Assert.IsTrue(personTwo);
        }
        [TestMethod]
        public void FilterByEmailAddress_GivenInvalidPredicate_Returns()
        {
            SampleData sampleData = new();
            IEnumerable<(string FirstName, string LastName)> actual = sampleData.FilterByEmailAddress(item => item.Contains("no one has this in their email"));
            Assert.AreEqual<int>(0, actual.Count());
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_WithValidObject_ReturnsValidString()
        {
            SampleData sampleData = new();
            string actual = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            string expected = string.Join(", ", sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

            Assert.AreEqual<string>(expected, actual);
        }
    }
}
