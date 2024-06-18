using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace GarageTask.Vehicles
{
    internal class Boat : Vehicle {
        public Boat(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, bool hasSail, int wheels = 0) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            HasSail = hasSail;
        }

        private bool HasSail { get; set; }

        public bool GetHasSail() { return HasSail; }
    }
}
