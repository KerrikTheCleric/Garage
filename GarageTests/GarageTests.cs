using Garage.Enums;
using Garage.Errors;
using Garage.Interfaces;
using GarageTask;
using GarageTask.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace GarageTask.Tests {
    [TestClass()]
    public class GarageTests {

        [TestMethod()]
        public void AddVehicleTest() {

            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(1);

            Airplane a = new Airplane("TBA555", Colour.Black, 865.7, 1500, 700, 'B', 8);

            // Act

            int res = garage.AddVehicle(a);

            // Assert

            Assert.AreEqual(0, res);
        }

        [TestMethod()]
        public void AddTooManyVehiclesTest() {

            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(1);

            Airplane a = new Airplane("TBA555", Colour.Black, 865.7, 1500, 700, 'B', 8);
            Boat b = new Boat("aBa123", Colour.Blue, 400.6, 2320.8, 60, true);

            // Act

            garage.AddVehicle(a);
            int res = garage.AddVehicle(b);

            // Assert

            Assert.AreEqual(1, res);
        }

        [TestMethod()]
        public void AddSameRegNumberTest() {
            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(2);

            Airplane a = new Airplane("TBA555", Colour.Black, 865.7, 1500, 700, 'B', 8);
            Boat b = new Boat("TBA555", Colour.Blue, 400.6, 2320.8, 60, true);

            // Act

            garage.AddVehicle(a);
            int res = garage.AddVehicle(b);

            // Assert

            Assert.AreEqual(2, res);
        }

        [TestMethod()]
        public void RemoveVehicleAtSpotNumberSuccessTest() {

            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(1);

            Airplane a = new Airplane("TBA555", Colour.Black, 865.7, 1500, 700, 'B', 8);

            // Act

            garage.AddVehicle(a);
            bool res = garage.RemoveVehicleAtSpotNumber(0);

            // Assert

            Assert.AreEqual(true, res);
        }

        [TestMethod()]
        public void RemoveVehicleAtSpotNumberFailTest() {

            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(1);

            // Act

            bool res = garage.RemoveVehicleAtSpotNumber(0);

            // Assert

            Assert.AreEqual(false, res);
        }

        [TestMethod()]
        public void RemoveVehicleWithRegistrationNumberSuccessTest() {

            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(1);

            Airplane a = new Airplane("TBA555", Colour.Black, 865.7, 1500, 700, 'B', 8);

            // Act

            garage.AddVehicle(a);
            bool res = garage.RemoveVehicleWithRegistrationNumber("TBA555");

            // Assert

            Assert.AreEqual(true, res);
        }

        [TestMethod()]
        public void RemoveVehicleWithRegistrationNumberFailTest() {

            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(1);

            // Act

            bool res = garage.RemoveVehicleWithRegistrationNumber("TBA555");

            // Assert

            Assert.AreEqual(false, res);

        }

        [TestMethod()]
        public void FindVehicleAtSpotNumberTest() {

            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(1);

            Airplane a = new Airplane("TBA555", Colour.Black, 865.7, 1500, 700, 'B', 8);

            // Act

            garage.AddVehicle(a);
            IVehicle res = garage.FindVehicleAtSpotNumber(0);

            // Assert

            Assert.AreEqual(a, res);
        }

        [TestMethod()]
        public void FindVehicleWithRegistrationNumberTest() {

            // Arrange

            IGarage<IVehicle> garage = new Garage<IVehicle>(1);

            Airplane a = new Airplane("TBA555", Colour.Black, 865.7, 1500, 700, 'B', 8);

            // Act

            garage.AddVehicle(a);
            IVehicle res = garage.FindVehicleWithRegistrationNumber("TBA555");

            // Assert

            Assert.AreEqual(a, res);

        }
    }
}