﻿using Garage.Enums;
using Garage.Errors;
using Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask.Vehicles
{
    internal class Vehicle : IVehicle {
        private string? _registrationNumber;

        public Vehicle(string registrationNumber, Colour colour,  double cargoSpace, double weight, int topSpeed, int wheels) {
            RegistrationNumber = registrationNumber;
            Colour = colour;
            CargoSpace = cargoSpace;
            Weight = weight;
            TopSpeed = topSpeed;
            Wheels = wheels;
        }

        private string RegistrationNumber { 
            get => _registrationNumber;
            set {
                if (value.Length != 6) {
                    throw new ArgumentException(new RegistratíonNumberFormatError().UEMessage());
                }

                for (int i = 0; i < 6; i++) {
                    if (i < 3) {
                        if (!char.IsLetter(value[i])) { throw new ArgumentException(new RegistratíonNumberFormatError().UEMessage()); } 
                    } else {
                        if (!char.IsNumber(value[i])) { throw new ArgumentException(new RegistratíonNumberFormatError().UEMessage()); }
                    }
                }
                _registrationNumber = value.ToUpper();
            }
        }

        private Colour Colour { get; set; }

        private double CargoSpace { get; set; }

        private double Weight { get; set; }

        private int TopSpeed { get; set; }

        private int Wheels { get; set; }

        public string GetRegistrationNumber() {
            return RegistrationNumber;
        }

        public Colour GetColour() {
            return Colour;
        }

        public double GetCargoSpace() {
            return CargoSpace;
        }

        public double GetWeight() {
            return Weight;
        }

        public int GetTopSpeed() {
            return TopSpeed;
        }

        public int GetWheels() {
            return Wheels;
        }

    }
}
