using GarageTask.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask {
    internal class Garage<T> : IEnumerable<T> where T : IVehicle{
        private T[] _vehicles;


        public Garage (int size) {
            _vehicles = new T[size];
            Vehicles = _vehicles;
        }

        public void AddVehicle(IVehicle v) {
            /*for (int i = 0; i < _vehicles.Length; ++i) {
                if (Vehicles[i] = null) {

                }
            }*/

            Vehicles[0] = (T)v;

            for (int i = 0; i < Vehicles.Length; ++i) {
                Console.WriteLine(Vehicles[i]);
            }

        }

        private T[] Vehicles { 
            get => _vehicles; 
            set => _vehicles = value; 
        }

        public IEnumerator<T> GetEnumerator() {

            for(int i = 0; i < _vehicles.Length; ++i)
            {
                yield return _vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
