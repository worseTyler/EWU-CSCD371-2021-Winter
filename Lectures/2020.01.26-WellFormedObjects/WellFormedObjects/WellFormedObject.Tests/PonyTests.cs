using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WellFormedObjects;

namespace WellFormedObject.Tests
{
    [TestClass]
    public class PonyTests
    {
        [TestMethod]
        public void EqualityTests()
        {
            Pony pony1 = new()
            {
                NumLegs = 4,
                Name = "Star"
            };
            Pony pony2 = new()
            {
                NumLegs = 4,
                Name = "Moon"
            };

            Assert.AreNotEqual(pony1, pony2);
            Assert.IsFalse(pony1 != pony2);
            Assert.IsFalse(null == pony1);
            Assert.IsFalse(pony1 == null);
        }

        [TestMethod]
        public void AdditionOfPonies()
        {
            Pony star = CreateStar();

            Pony other = star + "Flying";

            Assert.AreEqual("Star Flying", other.Name);
        }

        [TestMethod]
        public void CastStuff()
        {
            int? nullableInt = 0;

            int value = (int)nullableInt;

            Pony star = CreateStar();
            Assert.AreEqual(4, (int)star);

            Pony nullPony = null;
            Assert.AreEqual(-1, (int)nullPony);
        }

        [TestMethod]
        public void TempFileExample()
        {
            using TempFile tempFile = new();

            Assert.IsTrue(File.Exists(tempFile.FilePath));

            using (var streamWriter = new StreamWriter(tempFile.FilePath))
            {
                streamWriter.WriteLine("This is a line");
            }
            
            Assert.IsFalse(File.Exists(tempFile.FilePath));
        }

        private static Pony CreateStar()
        {
            return new()
            {
                NumLegs = 4,
                Name = "Star"
            };
        }
    }
}
