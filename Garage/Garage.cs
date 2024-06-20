using Garage.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask
{
    public class Garage<T> : IGarage<T>, IEnumerable<T> where T : IVehicle {
        private T[] _vehicles;
        private int _totalGarageSpaces;
        private int _remainingGarageSpaces;


        public Garage(int size) {
            _vehicles = new T[size];
            _totalGarageSpaces = size;
            _remainingGarageSpaces = size;
        }

        public T[] GetVehicleArray<T2>() {
            return _vehicles.ToArray();
        }

        public int GetTotalGarageSpaces() {
            return _totalGarageSpaces;
        }

        public int GetRemainingGarageSpaces() {
            return _remainingGarageSpaces;
        }

        /// <summary>
        /// Adds a new vehicle to the garage.
        /// </summary>
        /// <param name="newVehicle">The vew vehicle to add.</param>
        /// <returns>0 upon success, 1 if the garage is full and 2 if the registration number already exists.</returns>

        public int AddVehicle(T newVehicle) {

            if (_remainingGarageSpaces == 0) {
                return 1;
            }

            int freeSpace = -1;

            for (int i = 0; i < _vehicles.Length; ++i) {

                if (_vehicles[i] != null) {
                    if (newVehicle.GetRegistrationNumber() == _vehicles[i].GetRegistrationNumber()) {
                        return 2;
                    }
                } else if (freeSpace == -1) {
                    freeSpace = i;
                }
            }

            _vehicles[freeSpace] = newVehicle;
            _remainingGarageSpaces--;
            return 0;
        }

        /// <summary>
        /// Removes a vehicle from a parking spot.
        /// </summary>
        /// <param name="index">The number of the parking spot to remove from.</param>
        /// <returns>True upon success, false upon failure.</returns>

        public bool RemoveVehicleAtSpotNumber(int index) {
            if (_vehicles[index] != null) {
                _vehicles[index] = default(T);
                _remainingGarageSpaces++;
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Removes a vehicle with the provided registration number.
        /// </summary>
        /// <param name="regNumber">The registration number to look for.</param>
        /// <returns>True upon success, false upon failure.</returns>

        public bool RemoveVehicleWithRegistrationNumber(string regNumber) {

            for (int i = 0; i < _vehicles.Length; ++i) {

                if (_vehicles[i] != null) {
                    if (regNumber == _vehicles[i].GetRegistrationNumber()) {
                        _vehicles[i] = default(T);
                        _remainingGarageSpaces++;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Finds the vehicle on the provided parking spot.
        /// </summary>
        /// <param name="index">The number of the parking spot to check</param>
        /// <returns>The vehicle or null.</returns>

        public T FindVehicleAtSpotNumber(int index) {
            if (_totalGarageSpaces > index && index >= 0) {
                return _vehicles[index];
            }
            return default(T);
        }

        /// <summary>
        /// Finds the vehicle with the provided registration number.
        /// </summary>
        /// <param name="regNumber">The registration number to look for.</param>
        /// <returns>The vehicle or null.</returns>

        public T FindVehicleWithRegistrationNumber(string regNumber) {

            for (int i = 0; i < _vehicles.Length; ++i) {

                if (_vehicles[i] != null) {
                    if (regNumber == _vehicles[i].GetRegistrationNumber()) {
                        return _vehicles[i];
                    }
                }
            }
            return default(T);
        }

        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < _vehicles.Length; ++i) {
                if (_vehicles[i] != null) {
                    yield return _vehicles[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
