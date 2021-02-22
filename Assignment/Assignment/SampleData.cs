using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                string[] lines = File.ReadAllLines("People.csv");
                return lines.Skip(1).Distinct();
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => CsvRows.Select(item =>
            {
                string[] strings = item.Split(',');
                if (strings.Length > 7 && strings[6].Length == 2)
                    return strings[6];
                return string.Empty;
            })
            .Where(item => !(string.IsNullOrWhiteSpace(item)))
            .Distinct()
            .OrderBy(item => item);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());
        // 4.
        public IEnumerable<IPerson> People => CsvRows.Select(item =>
        {
            string[] items = item.Split(',');
            Person person = new(items[1], items[2], new Address(items[4], items[5], items[6], items[7]), items[3]);
            return person;
        }).OrderBy(item => item.Address.State)
            .ThenBy(item => item.Address.City)
            .ThenBy(item => item.Address.Zip);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people.Select(item => item.Address.State).Distinct().Aggregate(string.Empty, (item, next) =>
            {
                item += next;
                item += ", ";
                return item;
            }).TrimEnd().TrimEnd(',');
    }
}
