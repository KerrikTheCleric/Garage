using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask.Vehicles
{
    internal class Motorcycle : Vehicle {
        public Motorcycle(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, bool withCarriage, int wheels = 2) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            WithCarriage = withCarriage;
        }

        private bool WithCarriage { get; set; }
    }
}
