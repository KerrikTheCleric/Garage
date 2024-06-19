using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace GarageTask.Vehicles
{
    internal class Boat : Vehicle {
        private bool _hasSail; 

        public Boat(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, bool hasSail, int wheels = 0) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            _hasSail = hasSail;
        }

        public bool GetHasSail() { return _hasSail; }

        public override string GetSpecificationsText() {
            return "Boat: " + base.GetSpecificationsText() + $" - Has Sail: {_hasSail}";
        }
    }
}
