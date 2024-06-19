using GarageTask.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interfaces {
    internal interface IGarage<T> {

        public T[] GetVehicleArray<T2>();

        public int GetTotalGarageSpaces();

        public int AddVehicle(T newVehicle);

        /*public int AddVehicle(IVehicle newVehicle) {

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
        }*/

        // FindVehicleWithRegistrationNumber
    }
}
