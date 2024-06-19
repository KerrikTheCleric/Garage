using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace GarageTask.Vehicles
{
    internal class Bus : Vehicle {
        private bool _isDoubleDecker;

        public Bus(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, bool isDoubleDecker, int wheels = 6) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            _isDoubleDecker = isDoubleDecker;
        }

        public bool GetIsDoubleDecker() { return _isDoubleDecker; }

        public override string GetSpecificationsText() {
            return "Bus: " + base.GetSpecificationsText() + $" - Is a Double Decker: {_isDoubleDecker}";
        }
    }
}
