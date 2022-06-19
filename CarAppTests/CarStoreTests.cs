using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppTests
{
    [TestClass]
    public class CarStoreTests
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

            var carsInStore = carStore.GetAllStoreCars();

            CollectionAssert.Contains(carsInStore, car1);
        }
        
        [TestMethod]
        public void GetAllStoreCars_HasToyotaAndHondaCar_ContainsTheTwoCars()
        {
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Forward);
            var car3 = new Car(CarType.Audi, 0, DrivingMode.Forward);
            List<Car> cars = new List<Car> { car1, car2,car3 };
            List<Car> subSet = new List<Car> { car1, car2 };
            var carStore = new CarStore(cars);

            var carsInStore = carStore.GetAllStoreCars();

            CollectionAssert.IsSubsetOf(subSet, carsInStore);
        }

        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_Equal()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var car3 = new Car(CarType.Audi, 0, DrivingMode.Forward);
            var car4 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            var carStore2 = new CarStore(new List<Car> { car3, car4 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEqual(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_NotEquivalent()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var car3 = new Car(CarType.Audi, 0, DrivingMode.Forward);
            var car4 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            var carStore2 = new CarStore(new List<Car> { car3, car4 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreNotEquivalent(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_Equivalent()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var carStore2 = new CarStore(new List<Car> { car2, car1 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEquivalent(store1Cars, store2Cars);
        }
        #endregion
    }
}
