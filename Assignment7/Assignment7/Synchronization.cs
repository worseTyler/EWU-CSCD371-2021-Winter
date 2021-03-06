using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment7
{
    [TestClass]
    public class Synchronization
    {
        [TestMethod]
        public void Unsynchronized_GivenLargeEnoughInput_IsNotSynchronized()
        {
            string[] input = { "1000000" };

            Assert.AreNotEqual<int>(0, Program.Unsynchronized(input));
            // This passing shows that it is not synchronized
        }

        [TestMethod]
        public void SynchronizedLock_GivenLargeInput_OutputIsZero()
        {
            string[] input = { "1000000" };
            Assert.AreEqual<int>(0, Program.SynchronizedLock(input));
        }

        [TestMethod]
        public void SynchronizedInterlocked_GivenLargeInput_OutputIsZero()
        {
            string[] input = { "1000000" };
            Assert.AreEqual<int>(0, Program.SynchronizedInterlocked(input));
        }

        [TestMethod]
        public void MyTestMethod()
        {
            string[] input = { "1000000" };
            Assert.AreEqual<int>(1000000, Program.SynchronizedThreadLocal(input));
            // The threads are entirely separate and cannont affect each other
            // if this wasn't the case then the actual value you be less than the
            // expected value
        }
    }


    public class Program
    {
        static int _Total = int.MaxValue;
        static int _UnsyncCount = 0;

        public static int Unsynchronized(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => Decrement());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                _UnsyncCount++;
            }

            task.Wait();
            Console.WriteLine($"Count = {_UnsyncCount}");

            return _UnsyncCount;
        }

        static void Decrement()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                _UnsyncCount--;
            }
        }
        readonly static object Lock = new object();
        public static int _LockCount = 0;
        public static int SynchronizedLock(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementLock());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                lock (Lock)
                {
                    _LockCount++;
                }
            }

            task.Wait();
            Console.WriteLine($"Count = {_LockCount}");

            return _LockCount;
        }

        static void DecrementLock()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                lock (Lock)
                {
                    _LockCount--;
                }
            }
        }

        public static int _InterlockedCount = 0;
        public static int SynchronizedInterlocked(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementInterlocked());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                Interlocked.Increment(ref _InterlockedCount);
            }

            task.Wait();
            Console.WriteLine($"Count = {_InterlockedCount}");

            return _InterlockedCount;
        }

        static void DecrementInterlocked()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                Interlocked.Decrement(ref _InterlockedCount);
            }
        }


        static ThreadLocal<int> CountLocal = new();

        public static int Count
        {
            get { return CountLocal.Value; }
            set { CountLocal.Value = value; }
        }

        public static int SynchronizedThreadLocal(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementThreadLocal());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                Count++;
            }

            task.Wait();
            Console.WriteLine($"Count = {Count}");

            return Count;
        }

        static void DecrementThreadLocal()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                Count--;
            }
        }
    }
}
