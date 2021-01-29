using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Exceptions
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WhatIsAnException()
        {
            object foo = null;

            if (foo is null)
            {
                string s = foo.ToString();
                throw new ApplicationException();
            }
        }

        [TestMethod]
        public void LetsPlayCatch()
        {

            try
            {
                DoStuff(null);
            }
            //catch (ArgumentException e)
            //    when (e.ParamName == "p")
            //{

            //}
            catch(ArgumentException e)
            {
                if (e.ParamName == "p")
                {
                    //Handle exception
                    throw new InvalidOperationException("Cannot play catch now", e);
                }
                else
                {
                    throw;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                Console.WriteLine("In Finally");
            }
        }

        [TestMethod]
        public void DiaperPattern()
        {
            // DO NOT DO THIS
            try
            {
                //Do stuff
            }
            catch (Exception)
            {
                //Supress exception
            }
        }

        [TestMethod]
        public void CatchAndRethrow()
        {
            // DO NOT DO THIS
            try
            {
                //Do stuff
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private static void DoStuff(object p)
        {
            if (p is null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            //Calls other methods
        }
    }
}
