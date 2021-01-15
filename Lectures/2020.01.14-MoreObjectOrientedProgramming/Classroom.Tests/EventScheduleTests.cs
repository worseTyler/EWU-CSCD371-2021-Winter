using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Classroom.Tests
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void TimeSpan_SetTo1Hour_ThrowsExcption()
        {
            _ = new EventSchedule(DateTime.Now, new TimeSpan(hours: 1, minutes: 0, seconds: 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TimeSpan_SetTo0_ThrowsExcption()
        {
            _ = new EventSchedule (DateTime.Now, new TimeSpan(hours:0, minutes:0, seconds: 0));
        }

        [TestMethod]
        public void Properties_UsingReflection_VerifySetIsSameAsGet()
        {
            Course course = new ("CSCD371");
            Type courseType = typeof(EventSchedule);
            foreach(PropertyInfo property in 
                courseType.GetProperties()
                .Where(item=>item.CanWrite && item.CanRead && item.PropertyType.IsByRef))
            {
                // Set the property to it's default value
                property.SetValue(course, null, null);
                // Read out the value
                _ = property.GetValue(course);
            }
        }

        private static EventSchedule CreateSampleEvent()
        {
            return new(DateTime.Now, new TimeSpan(hours: 1, minutes: 0, seconds: 0));
        }

        [TestMethod]
        public void ToString_StandardEvent_OutputEventName()
        {
            EventSchedule eventSchedule = CreateSampleEvent();
            Assert.AreEqual(
                $"{nameof(Classroom)}.{nameof(EventSchedule)}", eventSchedule.ToString());
        }

        [TestMethod]
        public void Equality_TwoSameEvents_NotEqual()
        {
            EventSchedule eventSchedule1 = CreateSampleEvent();
            EventSchedule eventSchedule2 = CreateSampleEvent();
            Assert.AreNotEqual(eventSchedule1, eventSchedule2);
        }
    }
}
