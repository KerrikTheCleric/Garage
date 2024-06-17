﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask.Vehicles {
    internal class Airplane : Vehicle {

        public Airplane(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, char flightClass, int wheels = 3) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            FlightClass = flightClass;
        }

        private char FlightClass { get; set; }
    }
}
