using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace GarageTask.Vehicles
{
    internal class Motorcycle : Vehicle {
        private bool _hasCarriage;

        public Motorcycle(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, bool hasCarriage, int wheels = 2) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            _hasCarriage = hasCarriage;
        }

        public bool GetHasCarriage() { return _hasCarriage; }

        public override string GetSpecificationsText() {
            return "Motorcycle: " + base.GetSpecificationsText() + $" - Has Carriage: {_hasCarriage}";
        }
    }
}
