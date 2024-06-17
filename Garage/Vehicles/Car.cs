using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask.Vehicles {
    internal class Car : Vehicle {
        public Car(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, int wheels = 4) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
        }
    }
}
