using GarageTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interfaces {
    internal interface IGarageHandler {


        public IVehicle[] GetArrayOfVehicles();

        public int GetTotalGarageSpaces();

        public void AddVehicleToGarage(IVehicle vehicle);

        public IVehicle FindVehicleAtSpotNumber(int index);

        public IVehicle FindVehicleWithRegistrationNumber(string regNumber);
    }
}
