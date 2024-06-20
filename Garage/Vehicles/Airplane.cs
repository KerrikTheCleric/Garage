using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace GarageTask.Vehicles
{
    public class Airplane : Vehicle {
        private char _flightClass;

        public Airplane(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, char flightClass, int wheels = 3) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            _flightClass = flightClass;
        }

        public char GetFlightClass() { return _flightClass; }

        public override string GetSpecificationsText() {
            return "Airplane: " + base.GetSpecificationsText() + $" - Flight Class: {_flightClass}";
        }
    }
}
