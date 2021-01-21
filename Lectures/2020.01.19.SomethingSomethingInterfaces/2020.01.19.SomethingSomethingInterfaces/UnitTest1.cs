using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace _2020._01._19.SomethingSomethingInterfaces
{
    public interface IMagicNumberGenerator
    {
        public int DoStuff()
        {
            return 42;
        }
    }

    public interface ICookingService
    {
        internal string Create();

        public int DoStuff()
        {
            return 43;
        }
    }

    public class WaffleService : ICookingService, IMagicNumberGenerator
    {
        string ICookingService.Create()
        {
            throw new NotImplementedException();
        }

    }

    [TestClass]
    public class WaffleCookTests
    {
        //private class TestingCookingService : ICookingService
        //{
        //    public string CreateReturnValue { get; set; } = "Syrup";
        //    public int NumCalls { get; set; }
        //    public string Create()
        //    {
        //        if (NumCalls++ == 0)
        //        {
        //            return "Tuna Fish";
        //        }
        //        return CreateReturnValue;
        //    }
        //}

        [TestMethod]
        public void DoStuffTests()
        {
            IMagicNumberGenerator service = new WaffleService();
            ICookingService service2 = new WaffleService();

            Assert.AreEqual(42, service.DoStuff());
            Assert.AreEqual(43, service2.DoStuff());
        }

        /*
        [TestMethod]
        public void MakeMeAWaffle_WithValidTopping_CreatesWaffle()
        {
            //Arrange
            var service = new TestingCookingService();
            var cook = new WaffleCook(service);

            //Act
            Waffle waffle = cook.MakeMeAWaffle("Maple Syrup");

            //Assert
            Assert.IsNotNull(waffle);
            Assert.AreEqual("Syrup", waffle.Stuff);
        }
        */
        [TestMethod]
        public void MakeMeAWaffle2_WithValidTopping_CreatesWaffle()
        {
            //Arrange
            Mock<ICookingService> mock = new();

            var returnValue = Guid.NewGuid().ToString();

            mock.Setup(cookingService => cookingService.Create())
                .Returns(returnValue);

            var cook = new WaffleCook(mock.Object);

            //Act
            Waffle waffle = cook.MakeMeAWaffle("Maple Syrup");

            //Assert
            mock.VerifyAll();
            Assert.IsNotNull(waffle);
            Assert.AreEqual(returnValue, waffle.Stuff);
        }

        [TestMethod]
        public void MakeMeAWaffle_WithFish_Retries()
        {
            //Arrange
            Mock<ICookingService> mock = new();

            mock.SetupSequence(cookingService => cookingService.Create())
                .Returns("Tuna Fish")
                .Returns("Cheese");

            var cook = new WaffleCook(mock.Object);

            //Act
            Waffle waffle = cook.MakeMeAWaffle("Maple Syrup");

            //Assert
            Assert.IsNotNull(waffle);
            Assert.AreEqual("Cheese", waffle.Stuff);

            mock.Verify(cookingService => cookingService.Create(), Times.Exactly(2));
        }
    }
    public class WaffleCook
    {
        private ICookingService Service { get; }

        public WaffleCook(ICookingService service)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public Waffle MakeMeAWaffle(string topping)
        {
            if (topping.Contains("Fish"))
            {
                throw new ArgumentException("YUCK!", nameof(topping));
            }
            string goodStuff = Service.Create();

            while(goodStuff.Contains("Fish"))
            {
                goodStuff = Service.Create();
            }

            return new Waffle(goodStuff);
        }
    }

    public record Waffle(string Stuff) { }
}
