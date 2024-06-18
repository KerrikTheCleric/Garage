﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace GarageTask.Vehicles
{
    internal class Bus : Vehicle {
        public Bus(string registrationNumber, Colour colour, double cargoSpace, double weight, int topSpeed, bool isDoubleDecker, int wheels = 6) : base(registrationNumber, colour, cargoSpace, weight, topSpeed, wheels) {
            IsDoubleDecker = isDoubleDecker;
        }

        private bool IsDoubleDecker { set; get; }

        public bool GetIsDoubleDecker() { return IsDoubleDecker; }
    }
}
