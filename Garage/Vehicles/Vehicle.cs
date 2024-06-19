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
        private Colour _colour;
        private double _cargoSpace;
        private double _weight;
        private int _topSpeed;
        private int _wheels;

        public Vehicle(string registrationNumber, Colour colour,  double cargoSpace, double weight, int topSpeed, int wheels) {
            RegistrationNumber = registrationNumber;
            _colour = colour;
            _cargoSpace = cargoSpace;
            _weight = weight;
            _topSpeed = topSpeed;
            _wheels = wheels;
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

        public string GetRegistrationNumber() {
            return RegistrationNumber;
        }

        public Colour GetColour() {
            return _colour;
        }

        public double GetCargoSpace() {
            return _cargoSpace;
        }

        public double GetWeight() {
            return _weight;
        }

        public int GetTopSpeed() {
            return _topSpeed;
        }

        public int GetWheels() {
            return _wheels;
        }

        public virtual string GetSpecificationsText() {
            return $"Registration Number: {_registrationNumber} - Colour: {_colour} - Cargo Space: {_cargoSpace} - Weight:  {_weight} - Top Speed: {_topSpeed} - Wheels: {_wheels}";
        }

    }
}
