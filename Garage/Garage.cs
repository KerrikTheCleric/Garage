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

        private T[] Vehicles {
            get => _vehicles;
            set => _vehicles = value;
        }

        private int TotalGarageSpaces { get; set; }

        private int RemainingGarageSpaces { get; set; }

        public int AddVehicle(IVehicle newVehicle) {

            if (RemainingGarageSpaces == 0) {
                return 1;
            }

            int freeSpace = -1;

            for (int i = 0; i < Vehicles.Length; ++i) {

                if (Vehicles[i] != null) {
                    if (newVehicle.GetRegistrationNumber() == Vehicles[i].GetRegistrationNumber()) {
                        return 2;
                    }
                } else if (freeSpace == -1) {
                    freeSpace = i;
                }
            }

            Vehicles[freeSpace] = (T)newVehicle;
            RemainingGarageSpaces--;
            return 0;
        }

        // RemoveVehicleAtSpotNumber

        // RemoveVehicleWithRegistrationNumber

        public IVehicle FindVehicleAtSpotNumber(int index) {

            if (TotalGarageSpaces > index && index >= 0) {
                return Vehicles[index];
            }
            return null;
        }

        // FindVehicleWithRegistrationNumber

        // Move to UI

        public void PrintGarage(int columns) {

            int columnsPrinted = 0;
            int spacesPrinted = 0;

            for (int i = 0; i < TotalGarageSpaces; i++) {
                if (Vehicles[i] == null) {
                    Console.Write($"{spacesPrinted + 1}. [ ] ");
                } else {
                    Console.Write($"{spacesPrinted + 1}. [V] ");
                }
                columnsPrinted++;
                spacesPrinted++;

                if (columnsPrinted == columns) {
                    Console.Write("\n");
                    columnsPrinted = 0;
                }
            }


            /*foreach (IVehicle v in this) {
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
            }*/
            Console.WriteLine("");
        }

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
