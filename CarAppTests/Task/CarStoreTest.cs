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
    public class CarStoreTest
    {
        #region Class init
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            context.WriteLine("CarStoreTests init");
        }

        [ClassCleanup]
        public static void Cleanup()
        {

        }
        #endregion

        #region Collection Assert
        [Owner("Waleed")]
        [TestMethod]
        public void GetAllStoreCars_HasToyotaCar_ContainsTheCar()
        {
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Forward);
            List<Car> cars = new List<Car> { car1, car2 };
            var carStore = new CarStore(cars);
            //Act
            var carsInStore = carStore.GetAllStoreCars();
            //Assert
            CollectionAssert.Contains(carsInStore, car1);
        }

        [TestMethod]
        public void GetAllStoreCars_HasToyotaAndHondaCar_ContainsTheTwoCars()
        {
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Forward);
            var car3 = new Car(CarType.Audi, 0, DrivingMode.Forward);
            List<Car> cars = new List<Car> { car1, car2, car3 };
            List<Car> subSet = new List<Car> { car1, car2 };
            var carStore = new CarStore(cars);

            var carsInStore = carStore.GetAllStoreCars();

            CollectionAssert.IsSubsetOf(subSet, carsInStore);
        }
        #endregion

    }
}
