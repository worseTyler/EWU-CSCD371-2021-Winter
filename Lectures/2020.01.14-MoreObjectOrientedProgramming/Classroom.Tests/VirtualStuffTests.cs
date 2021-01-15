using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Classroom.Tests
{
    [TestClass]
    public class VirtualStuffTests
    {
        const string InigoMontoya = "Inigo Montoya";

        [TestMethod]
        public void NonVirtualMethod_GiveSpecialSampleThing_ReturnSpecialSampleThing()
        {
            SpecialSampleThing thing = new(InigoMontoya);

            Assert.AreEqual(
                $"{nameof(SpecialSampleThing)}: {InigoMontoya}", 
                thing.NonVirtualMethod());
        }

        [TestMethod]
        public void VirtualMethod_GivenSpecialSampleThing_ReturnSpecialSampleThing()
        {
            SpecialSampleThing thing = new(InigoMontoya);

            Assert.AreEqual(
                $"{nameof(SpecialSampleThing)}: {InigoMontoya}",
                thing.VirtualMethod());
        }

        [TestMethod]
        public void NonVirtualMethod_GivenSpecialSampleThingCastToSampleThing_ReturnSpecialSampleThing()
        {
            SampleThing thing = new(InigoMontoya);

            Assert.AreEqual(
                $"{nameof(SampleThing)}: {InigoMontoya}",
                thing.NonVirtualMethod());
        }

        [TestMethod]
        public void VirtualMethod_GivenSpecialSampleThingCastToSampleThing_ReturnSpecialSampleThing()
        {
            SampleThing thing = new(InigoMontoya);

            Assert.AreEqual(
                $"{nameof(SampleThing)}: {InigoMontoya}",
                thing.VirtualMethod());
        }
    }
}