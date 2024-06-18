using Garage.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask
{
    internal class Garage<T> : IGarage<T>, IEnumerable<T> where T : IVehicle {
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

            _vehicles[freeSpace] = (T)newVehicle;
            _remainingGarageSpaces--;
            return 0;
        }

        // RemoveVehicleAtSpotNumber

        // RemoveVehicleWithRegistrationNumber

        public IVehicle FindVehicleAtSpotNumber(int index) {

            if (_totalGarageSpaces > index && index >= 0) {
                return _vehicles[index];
            }
            return null;
        }

        // FindVehicleWithRegistrationNumber

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
