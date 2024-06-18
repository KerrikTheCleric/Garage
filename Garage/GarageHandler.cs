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
    }
}
