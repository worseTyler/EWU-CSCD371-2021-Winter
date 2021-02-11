# EWU-CSCD371-2021-Winter

## See [Docs](Docs)

## Assignment 6

The purpose of this assignment is to solidify your learning of:

- Lambda expressions
- LINQ with Standard Query Operators
  - Selecting (projection)
  - Filtering
  - Aggregation
  - Sorting
  - Unit testing collections.
- Implementing IEnumerable

Becuase of the amount of material, **the homework will span two weeks of class with the final submission on Thursday 2/25**. (No assignment is due Thu 2/18)

## Reading

Prior to Thu 2/16:

- Chapter 15: Collection Interfaces with Standard Query Operators
- Chapter 17: Building Custom Collections

Prior to Tue 2/23:

- Chapter 20: Programming with Task-Based Asynchronous Pattern
- Chapter 22: Thread Synchronization

Recommended But **Not** Required (in order of priority)

- Chapter 19: Introducing Multithreading
- Chapter 21: Iterating in Parallel
- Chapter 18: Reflection, Attributes, and Dynamic Programming
- Chapter 16: LINQ with Query Expressions

## Instructions

**Throughout, consider using the `System.Linq.Enumerable` methods `Zip`, `Count`, `Sort` and `Contains` methods for testing collections.**.  (Preferably avoid using `Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert` although that might be easier, in order to get a firmer grasp on on additional LINQ API.)

1. Implement the `ISampleData.CsvRows` property, loading the data from the `People.csv` file and returning each line as a single string. ❌✔

- Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project. ❌✔
- Using LINQ, skip the first row in the `People.csv`. ❌✔
- Be sure to appropriately handle resource (`IDisposable`) items correctly if applicable (and it may not be depending on how you implement it). ❌✔

1. Implement `IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()` to return a **sorted**, **unique** list of states. ❌✔

- Use `ISampleData.CsvRows` for your data source. ❌✔
- Don't forget the list should be unique. ❌✔
- Sort the list alphabetically. ❌✔
- Include a test that leverages a hard coded list of Spokane based addresses. ❌✔
- Include a test that uses LINQ to verify the data is sorted correctly (do not use a hard coded list). ❌✔

1. Implement `ISampleData.GetAggregateSortedListOfStatesUsingCsvRows()` to return a `string` that contains a **unique**, comma separated list of states. ❌✔

- Use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows()` for your data source. ❌✔
- Consider "selecting" only the states and calling `ToArray()` to retrieve an array of all the state names. ❌✔
- Given the array, consider using `string.Join` to combine the list into a single string. ❌✔

1. Implement the `ISampleData.People` property to return all the items in `People.csv` as `Person` objects ❌✔

- Use `ISampleData.CsvRows` as the source of the data. ❌✔
- Sort the list by State, City, Zip. (Sort the addresses first then select). ❌✔
- Be sure that `Person.Address` is also populated. ❌✔
- Adding null validation to all the `Person` and `Address` properties is **optional**.
- Consider using `ISampleData.CsvRows` in your test to verify your results. ❌✔

1. Implement `ISampleDate.FilterByEmailAddress(Predicate<string> filter)` to return a list of names where the email address matches the `filter`. ❌✔

- Use `ISampleData.People` for your data source. ❌✔

1. Implement `ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)` to return a `string` that contains a **unique**, comma separated list of states. ❌✔

- Use the `people` parameter from `ISampleData.GetUniqueListOfStates` for your data source. ❌✔
- At a minimum, use `System.Linq.Enumerable.Aggregate` LINQ method to create your result. ❌✔
- Don't forget the list should be unique. ❌✔
- It is recommended that at a minimum you use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows` to validate your result.

1. Given the implementation of `Node` in Assignment5, implement `IEnumerable<T>`. ❌✔

## Extra Credit

The following are options for extra credit (you don't need to do them all):

- Implement the homework using async/await and multi-threading by defining a new `SampleDataAsync` class that implements `ISampleData`). Refactor both your `SampleData` and `SampleDataAsync` classes so there is minimal duplication. This includes refactoring your tests so a significant amount of test code can be re-used. ❌✔

## Fundamentals

- Ensure you enable nullable reference types, net5 targetted, C# 9.0, warnings as errors, and enabled .NET analyzers for both projects ❌✔
- Fully unit test the assignment ❌✔
- Choose simplicity over than complexity ❌✔
