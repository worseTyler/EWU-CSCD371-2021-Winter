using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Classroom.Tests
{
    [TestClass]
    public class FingerPrintTests
    {
        [TestMethod]
        public void CreateFingerPrint()
        {
            FingerPrint fingerPrint = new ("Inigo Montoya");
            Assert.AreEqual(
                "Inigo Montoya", fingerPrint.CreatedBy);
        }

        [TestMethod]
        public void CreateBy_ThereIsNoSet()
        {
            FingerPrint fingerPrint = new("Inigo Montoya");
            // fingerPrint.CreatedBy = "Princess Buttercup";
            Assert.AreEqual("Inigo Montoya", fingerPrint.CreatedBy);
        }

        [TestMethod]
        public void CreateBy_UpdateValue()
        {
            FingerPrint fingerPrint = new("Inigo Montoya");
            fingerPrint.ModifiedBy = "Princess Buttercup";
            Assert.AreEqual("Princess Buttercup", fingerPrint.ModifiedBy);
        }
    }
}
