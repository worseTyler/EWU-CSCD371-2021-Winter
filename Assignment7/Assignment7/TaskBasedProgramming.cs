using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)] // I found this online to run tests in parallel but I'm not sure where to put it
namespace Assignment7
{
    [TestClass]
    public class TaskBasedProgramming
    {
        private async Task<int> DownloadTextAsync(params string[] urls)
        {
            if (urls is null)
                throw new ArgumentNullException($"DownloadTextAsync: {nameof(urls)} was null");

            Task<int> task = Task.Run(() =>
            {
                int numChars = 0;
                foreach (string url in urls)
                {
                    WebClient webClient = new();
                    string output = webClient.DownloadString(url);
                    numChars += output.Length;
                }
                return numChars;
            });

            return await task;
        }

        public async Task<int> DownloadTextRepeatedlyAsync(int repetitions, IProgress<double> progress, ParallelOptions parallelOptions, params string[] urls)
        {
            if (urls is null)
                throw new ArgumentNullException($"DownloadTextAsync: {nameof(urls)} was null");
            if (repetitions < 0)
                throw new ArgumentException($"DownloadTextAsync: Doesn't make sense to have less than zero repetitions ({repetitions})");

            Task<int> task = Task.Run(() =>
            {
                int numChars = 0;

                Parallel.For(0, repetitions, parallelOptions, index =>
                {
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                    // numChars += DownloadTextAsync(urls).Result;  //Thread synchronization problem
                    //Interlocked.Add(ref numChars, await DownloadTextAsync(urls)); // When called with async action, the Parallel.For does not wait for the function to return, just the invocation of the method
                    Interlocked.Add(ref numChars, DownloadTextAsync(urls).Result);

                    progress.Report(((double)index + 1) / repetitions);

                });

                return numChars;
            });

            return await task;
        }

        [TestMethod]
        public void DownloadTextAsync_GivenValidParams_ReturnsREASONABLEOutput()
        {

            IEnumerable<string> urls = Enumerable.Repeat<string>("http://google.com", 15); // I really don't like using this because it keeps changing
            int lowerBound = 700000;
            int upperBound = 800000;

            int actual = DownloadTextAsync(urls.ToArray()).Result;

            Console.WriteLine($"Output: Number of characters: {actual}");

            bool result = (actual < upperBound && actual > lowerBound);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DownloadTextAsync_GivenNullParams_ThrowsException()
        {
            bool isThrown = false;
            try
            {
                DownloadTextAsync(null!).Wait();
            }
            catch (AggregateException aggregateException)
            {
                aggregateException.Handle(exception =>
                {
                    if (exception is ArgumentNullException)
                        isThrown = true;
                    return true;
                });
            }
            Assert.IsTrue(isThrown);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_GivenRelativelyStaticSite_ReturnsExpectedValue()
        {
            IEnumerable<string> urls = Enumerable.Repeat<string>("http://intellitect.com", 15);

            int actual = DownloadTextRepeatedlyAsync(5, new Progress<double>(progress => Console.WriteLine($"Progress: {progress * 100}%")), new ParallelOptions(), urls.ToArray()).Result;
            int lowerBound = 10000000;
            int upperBound = 13000000;
            Console.WriteLine(actual);

            bool result = (actual < upperBound && actual > lowerBound);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_GivenNullParams_ThrowsException()
        {
            bool isThrown = false;
            try
            {
                DownloadTextRepeatedlyAsync(5, new Progress<double>(progress => Console.WriteLine($"Progress: {progress * 100}%")), new ParallelOptions(), null!).Wait();
            }
            catch (AggregateException aggregateException)
            {
                aggregateException.Handle(exception =>
                {
                    if (exception is ArgumentNullException)
                        isThrown = true;
                    return true;
                });
            }
            Assert.IsTrue(isThrown);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_GivenInvalidRepetitions_ThrowsException()
        {
            IEnumerable<string> urls = Enumerable.Repeat<string>("http://intellitect.com", 15);
            bool isThrown = false;
            try
            {
                DownloadTextRepeatedlyAsync(-1, new Progress<double>(progress => Console.WriteLine($"Progress: {progress * 100}%")), new ParallelOptions(), urls.ToArray()).Wait();
            }
            catch (AggregateException aggregateException)
            {
                aggregateException.Handle(exception =>
                {
                    if (exception is ArgumentException)
                        isThrown = true;
                    return true;
                });
            }
            Assert.IsTrue(isThrown);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsycn_LoopCanBeCancelled()
        {
            IEnumerable<string> urls = Enumerable.Repeat<string>("http://intellitect.com", 15);
            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cts.Token;

            bool canceled = false;

            Task task = Task.Run(() =>
            {
                cts.Cancel();
            });
            try
            {
                int actual = DownloadTextRepeatedlyAsync(5, new Progress<double>(progress => Console.WriteLine($"Progress: {progress * 100}%")), parallelOptions, urls.ToArray()).Result;
            }
            catch(AggregateException aggregateException)
            {
                aggregateException.Handle(exception =>
                {
                    if (exception is OperationCanceledException)
                        canceled = true;
                    return true;
                });
            }
            Assert.IsTrue(canceled);
        }
    }
}
