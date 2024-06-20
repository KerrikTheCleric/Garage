using GarageTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interfaces {
    internal interface IGarageHandler {


        public IVehicle[] GetArrayOfVehiclesAndEmptySpots();

        public List<IVehicle> GetListOfOnlyVehicles();

        public int GetTotalGarageSpaces();

        public int GetRemainingGarageSpaces();

        public void AddVehicleToGarage(IVehicle vehicle);

        public bool RemoveVehicleAtSpotNumber(int index);

        public bool RemoveVehicleWithRegistrationNumber(string regNumber);

        public IVehicle FindVehicleAtSpotNumber(int index);

        public IVehicle FindVehicleWithRegistrationNumber(string regNumber);

        public List<String> CollectAllVehicleTypes();

        public int CountVehiclesOfType(string type);
    }
}
