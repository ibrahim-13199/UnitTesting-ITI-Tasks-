using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarAppTests
{
    [TestClass]
    public class CarTests
    {
        public static int ClassCount = 0;

        #region Class init
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            context.WriteLine("CarTests init");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }
        #endregion
        public CarTests()
        {
            ClassCount++;
        }
        #region Test Init
        private static Car _audiCar;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void MyTestInit()
        {
            _audiCar =  new Car(CarType.Audi, 100, DrivingMode.Forward);
            TestContext.WriteLine("Test init");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("Test clean up");
            TestContext.WriteLine($"Number of classes: {CarTests.ClassCount}");
        }
        #endregion

        #region Assert

        [TestMethod]
        public void TimeToCoverProvidedDistance_Distance100Velocity25_Time4()
        {
            // Arrange
            double providedDistance = 100;
            double velocity = 25;
            double expectedTime = 4;
            Car car = new Car(CarType.BMW, velocity, DrivingMode.Forward);
            // Act
            var actualResult = car.TimeToCoverProvidedDistance(providedDistance);

            // Assert
            Assert.AreEqual(expectedTime, actualResult);
        }

        [Ignore]
        [TestMethod]
        public void GetMyCar_ExistingInstance_NotNull()
        {
            // Arrange
            Car car = new Car();

            // Act
            var actual = car.GetMyCar();

            // Assert
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void TwoCars_DifferentInstancesSameState_EqualCars()
        {
            var car1 = new Car(CarType.Audi, 100, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 100, DrivingMode.Forward);

            Assert.AreEqual(car1, car2);
        }

        [TestMethod]
        public void TwoCars_DifferentInstancesSameState_NotSameCars()
        {
            var car1 = new Car(CarType.Audi, 100, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 100, DrivingMode.Forward);

            Assert.AreNotSame(car1, car2);
        }

        [Owner("Waleed")]
        [Priority(1)]
        [TestCategory("Logic")]
        [TestMethod]
        public void GetMyCar_ExistingInstance_TypeCar()
        {
            var car = new Car();

            var myCar = car.GetMyCar();

            Assert.IsInstanceOfType(myCar, typeof(Car));
        }
        [Owner("Amr")]
        [Priority(2)]
        [TestCategory("Data")]
        [TestMethod]
        public void Accelerate_ToyotaInitialVelocity25_Velocity35()
        {
            double velocity = 25;
            Car car = new Car(CarType.Toyota, velocity, DrivingMode.Forward);
            double expectedVelocity = 35;

            car.Accelerate();

            Assert.AreEqual(expectedVelocity, car.Velocity);
        }

        [Owner("Waleed")]
        [Priority(2)]
        [TestCategory("Data")]
        [TestMethod]
        public void IsStopped_Velocity0_True()
        {
            var car = new Car(CarType.Audi, 0, DrivingMode.Stopped);

            var actualResult = car.IsStopped();

            Assert.IsTrue(actualResult);
        }
        #endregion

        #region String Assert
        [TestMethod]
        public void GetDirection_CarForward_PrintForward()
        {
            var car = new Car();
            car.DrivingMode = DrivingMode.Forward;
            var expected = "Forward";

            var actualDirection = car.GetDirection();

            StringAssert.Matches(actualDirection, new System.Text.RegularExpressions.Regex(expected));
        }
        #endregion

        #region Exception
        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void Accelerate_TypeHonda_ThrowException()
        {
            var car = new Car(CarType.Honda, 100, DrivingMode.Forward);

            car.Accelerate();
        }
        #endregion
    }
}
