# EWU-CSCD371-2021-Winter

## See [Docs](Docs)

## Assignment 6

The purpose of this assignment is to solidify your learning of programming with the Task Parallel Library (TPL) and the sundry synchronization API.

## Reading

If you haven't already, read:

- Chapter 20: Programming with Task-Based Asynchronous Pattern
- Chapter 22: Thread Synchronization

Recommended But **Not** Required (in order of priority)

- Chapter 19: Introducing Multithreading
- Chapter 21: Iterating in Parallel
- Chapter 18: Reflection, Attributes, and Dynamic Programming
- Chapter 16: LINQ with Query Expressions

## Instructions

DUE: All homework is allowed an additional two days (so rather than submitting for peer review Monday it may be posted Wednesday).  Final code should be submitted by midnight on Saturday, March 6.

Place all code in a single unit testing project called Assignment7.

1. In this example, we are intentionally `System.Net.WebClient.DownloadString()` to **simulate** a high-latency operation - pretending there is no async. version.

- Implement an async (using TPL) method, `DownloadTextAsync(params string[] urls)`, that calls `System.Net.WebClient.DownloadString()` and returns **the total number of characters downloaded** from all the urls. ❌✔
  - You do not need to download the urls in parallel.
  - In your tests use https://google.com repeatedly for the urls parameter.
- Implement an async (using TPL) method, `DownloadTextRepeatedlyAsync(int repetitions, params string[] urls)`, that uses a parallel loop to call `DownloadTextAsync` repeatedly for `repetitions` times and returns **the total number of characters downloaded** across all iterations. ❌✔
- Add support to `DownloadTextRepeatedlyAsync` for cancellation so that the method can be cancelled before all the repetitions occur. ❌✔
- Add support to `DownloadTextRepeatedlyAsync` for observing the progress (`IProgress<T>`) that shows the percentage of repetitions that have completed. ❌✔
- Be sure to add any synchronization if needed. ❌✔

1. Turn in the solutions discussed/solved in class using the following [un-synchronized code](https://raw.githubusercontent.com/IntelliTect/EssentialCSharp/v8.0/src/Chapter22/Listing22.01.UnsychronizedState.cs):

- Write a test to show that the code is not synchronized as is. ❌✔
- Synchronize and test using `lock`. ❌✔
- Synchronize and test using `System.Threading.Interlocked`. ❌✔
- Demonstrate that synchronization is not required when using `System.Threading.ThreadLocal<T>`. ❌✔

## Testing

- Configure all tests to run in parallel. ❌✔

## Extra Credit

- Submit a PR with unit tests for at least 3 code listings in Chapters 20-23 (see https://github.com/IntelliTect/EssentialCSharp/tree/v8.0/src) where the the listing currently has no unit tests. ❌✔

## Fundamentals

- Ensure you enable nullable reference types, net5 targeted, C# 9.0, warnings as errors, and enabled .NET analyzers for both projects ❌✔
- Fully unit test the assignment ❌✔
- Choose simplicity over than complexity ❌✔
