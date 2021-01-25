namespace CanHazFunny.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void TellJoke_WhenCalled_RunsBothInterfacedMethods()
        {
            Mock<IJokeService> iJokeService = new ();
            Mock<IOutputJoke> iOutputJoke = new ();

            string returnValue = Guid.NewGuid().ToString();
            iJokeService.Setup(getJoke => getJoke.GetJoke())
                .Returns(returnValue);

            string retrievedJoke = iJokeService.Object.GetJoke();

            iOutputJoke.Setup(outputJoke => outputJoke.OutputJoke(retrievedJoke));

            Jester jester = new Jester(iJokeService.Object, iOutputJoke.Object);

            jester.TellJoke();

            Assert.AreEqual(retrievedJoke, returnValue);
            iOutputJoke.Verify(outputJoke => outputJoke.OutputJoke(retrievedJoke), Times.Once());
        }

        [TestMethod]
        public void TellJoke_GivenChuckNorrisJoke_CyclesThroughJokes()
        {
            Mock<IJokeService> iJokeService = new ();
            Mock<IOutputJoke> iOutputJoke = new ();

            iJokeService.SetupSequence(getJoke => getJoke.GetJoke())
                .Returns("If you spell Chuck Norris in Scrabble, you win. Forever.")
                .Returns("The chief export of Chuck Norris is pain.")
                .Returns("An actually good joke");

            iOutputJoke.Setup(outputJoke => outputJoke.OutputJoke("Who Knows"));

            Jester jester = new Jester(iJokeService.Object, iOutputJoke.Object);

            jester.TellJoke();

            iJokeService.Verify(getJoke => getJoke.GetJoke(), Times.Exactly(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_GivenNullOutputJokeService_ThrowNullException()
        {
            Mock<IOutputJoke> iOutputJoke = new ();
            _ = new Jester(null, iOutputJoke.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_GivenNullJokeService_ThrowNullException()
        {
            Mock<IJokeService> iJokeService = new ();
            _ = new Jester(iJokeService.Object, null);
        }
    }
}
