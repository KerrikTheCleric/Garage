using GarageTask.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask {
    internal class Garage<T> : IEnumerable<T> where T : IVehicle {
        private T[] _vehicles;


        public Garage(int size) {
            _vehicles = new T[size];
            Vehicles = _vehicles;
            TotalGarageSpaces = size;
            RemainingGarageSpaces = size;
        }

        public bool AddVehicle(IVehicle newVehicle) {

            if (RemainingGarageSpaces == 0) {
                return false;
            }

            // TODO: Change loop to traverse entire array looking for registration duplicates and save last free spot to use

            for (int i = 0; i < Vehicles.Length; ++i) {
                if (Vehicles[i] == null) {
                    Vehicles[i] = (T)newVehicle;
                    RemainingGarageSpaces = RemainingGarageSpaces--;
                    return true;
                }
            }
            return false;
        }

        public void PrintGarage(int columns) {

            int columnsPrinted = 0;
            int spacesPrinted = 0;

            foreach (IVehicle v in this) {
                Console.Write($"{spacesPrinted + 1}. [V] ");
                columnsPrinted++;
                spacesPrinted++;

                if (columnsPrinted == columns) {
                    Console.Write("\n");
                    columnsPrinted = 0;
                }
            }

            for (int i = 0; i < RemainingGarageSpaces; i++) {
                Console.Write($"{spacesPrinted + 1}. [ ] ");
                columnsPrinted++;
                spacesPrinted++;


                if (columnsPrinted == columns) {
                    Console.Write("\n");
                    columnsPrinted = 0;
                }
            }
            Console.WriteLine("");
        }

        private T[] Vehicles {
            get => _vehicles;
            set => _vehicles = value;
        }

        private int TotalGarageSpaces { get; set; }

        private int RemainingGarageSpaces { get; set; }


        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < Vehicles.Length; ++i) {
                if (Vehicles[i] != null) {
                    yield return _vehicles[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
