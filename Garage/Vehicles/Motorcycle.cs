using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace GarageTask.Vehicles
{
    internal class Motorcycle : Vehicle {
        public Motorcycle(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, bool hasCarriage, int wheels = 2) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            HasCarriage = hasCarriage;
        }

        private bool HasCarriage { get; set; }

        public bool GetHasCarriage() { return HasCarriage; }
    }
}
