using Garage.Errors;
using Garage.Interfaces;
using GarageTask.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask {

    // Represents direct UI functions              

    internal class GarageHandler : IGarageHandler {

        IGarage<IVehicle> _garage;

        public GarageHandler(int garageSize) {
            Garage = new Garage<IVehicle>(garageSize);
        }

        private IGarage<IVehicle> Garage { get => _garage; set => _garage = value; }

        public IVehicle[] GetArrayOfVehicles() {
            return Garage.GetVehicleArray<IVehicle>();
        }
        public int GetTotalGarageSpaces() {
            return _garage.GetTotalGarageSpaces();
        }

        public void AddVehicleToGarage(IVehicle vehicle) {

            switch (_garage.AddVehicle(vehicle)) {
                case 1:
                    throw new ArgumentException(new GarageFullError().UEMessage());
                case 2:
                    throw new ArgumentException(new ExistingRegistrationNumberError().UEMessage());
                default:
                    break;
            }

        }

        public IVehicle FindVehicleAtSpotNumber(int index) {
            return _garage.FindVehicleAtSpotNumber(index);
        }

        public IVehicle FindVehicleWithRegistrationNumber(string regNumber) {
            return _garage.FindVehicleWithRegistrationNumber(regNumber);
        }


    }
}
