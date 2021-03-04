using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Assignment7
{
    [TestClass]
    public class TaskBasedProgramming
    {
        [TestMethod]
        public async Task TestMethod1()
        {

            IEnumerable<string> urls = Enumerable.Repeat<string>("http://intellitect.com", 15);

			int thing1 = await DownloadTextAsync(urls.ToArray());
			Console.WriteLine($"Thing 1: Number of characters: {thing1}");
			
			int thing2 = DownloadText(urls.ToArray());
			Console.WriteLine($"Thing 2: Number of characters: {thing2}");

			int thing3 = await DownloadTextRepeatedlyAsync(5, urls.ToArray());
			Console.WriteLine($"Thing 3: Number of characters: {thing3}");

		}

		public async Task<int> DownloadTextAsync(params string[] urls)
        {
			Task<int> task = Task.Run(() =>
			{
				int numChars = 0;
				foreach (string url in urls)
				{

					Console.WriteLine($"Calling URL: {url} - {System.DateTime.Now}");
					WebClient webClient = new();
					DateTime begin = System.DateTime.Now;
					string output = webClient.DownloadString(url);
					DateTime end = System.DateTime.Now;
					Console.WriteLine($"URL call took: {(end - begin).TotalSeconds} seconds.");
					numChars += output.Length;
				}
				return numChars;
			});

			return await task;
        }

		public async Task<int> DownloadTextRepeatedlyAsync(int repetitions, params string[] urls)
		{
			return await Task.Run(() =>
			{
				int numChars = 0;

                ParallelLoopResult x = Parallel.For(0, repetitions, async index =>
				{
					numChars += await DownloadTextAsync(urls);
				});

				return numChars;
			});
		}

		public int DownloadText(params string[] urls)
		{
			int numChars = 0;
			foreach (string url in urls)
			{
				Console.WriteLine($"Calling URL: {url} - {System.DateTime.Now}");
				WebClient webClient = new();
				DateTime begin = System.DateTime.Now;
				string output = webClient.DownloadString(url);
				DateTime end = System.DateTime.Now;
				Console.WriteLine($"URL call took: {(end - begin).TotalSeconds} seconds.");
				numChars += output.Length;
			}
			return numChars;
		}

	}
}