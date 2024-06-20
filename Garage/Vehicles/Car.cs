using Garage.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask.Vehicles
{
    public class Car : Vehicle {
        private FuelType _fuelType;

        public Car(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, FuelType fueltype, int wheels = 4) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            _fuelType = fueltype;
        }

        public FuelType GetFueltype() { return _fuelType; }

        public override string GetSpecificationsText() {
            return "Car: " + base.GetSpecificationsText() + $" - Fuel Type: {_fuelType}";
        }
    }
}
