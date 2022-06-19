using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarsApp;

namespace CarAppTests.Task
{
    [TestClass]
    public class CarTests
    {
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

        [TestMethod]
        public void Accelerate_ToyotaInitialVelocity20_Velocity30()
        {
            double velocity = 20;
            Car car = new Car(CarType.Toyota, velocity, DrivingMode.Forward);
            double expectedVelocity = 30;

            car.Accelerate();

            Assert.AreEqual(expectedVelocity, car.Velocity);

        }
        [TestMethod]
        public void Stopped_intailVelocity100_stopedVelocity0()
        {
            //Arrange
            double intailVelocety = 100;
            double endVelocety = 0;
            Car car = new Car(CarType.Toyota, intailVelocety, DrivingMode.Forward);
            //Act
            car.Stop();
            //Assert
            Assert.AreEqual(endVelocety, car.Velocity);

        }


     

        [TestMethod]
        public void TwoCars_DifferentInstancesSameState_NotSameCars()
        {
            var car1 = new Car(CarType.Audi, 100, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 100, DrivingMode.Forward);

            Assert.AreNotSame(car1, car2);
        }

        /////////////////////////////////////////////
        ///String Assert
        
        [TestMethod]
        public void GetDirection_CarForward_PrintForward()
        {
            var car = new Car();
            car.DrivingMode = DrivingMode.Forward;
            var expected = "Forward";

            var actualDirection = car.GetDirection();

            StringAssert.Matches(actualDirection, new System.Text.RegularExpressions.Regex(expected));
        }

        public void GetDirection_CarNotReverse_PrintAhead()
        {
            Car car = new Car();
            car.DrivingMode = DrivingMode.Forward;
            var result = "Not Reverse";

            var actualDirection = car.GetDirection();

            StringAssert.DoesNotMatch(actualDirection, new System.Text.RegularExpressions.Regex(result));
         
            
        }



    }
}
