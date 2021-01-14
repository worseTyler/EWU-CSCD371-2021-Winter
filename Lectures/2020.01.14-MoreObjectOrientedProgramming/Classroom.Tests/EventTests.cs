using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Classroom.Tests
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void TimeSpan_SetTo1Hour_ThrowsExcption()
        {
            _ = new Event(DateTime.Now, new TimeSpan(hours: 1, minutes: 0, seconds: 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TimeSpan_SetTo0_ThrowsExcption()
        {
            _ = new Event (DateTime.Now, new TimeSpan(hours:0, minutes:0, seconds: 0));
        }

        [TestMethod]
        public void Properties_UsingReflection_VerifySetIsSameAsGet()
        {
            Event course = new(DateTime.Now, new TimeSpan(hours: 1, minutes: 0, seconds: 0));
            Type courseType = typeof(Event);
            // courseType.GetProperties()
        }
    }
}
