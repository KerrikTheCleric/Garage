using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask.Vehicles {
    internal class Bus : Vehicle {
        public Bus(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, int wheels = 6) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
        }
    }
}
