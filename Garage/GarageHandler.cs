using Garage;
using Garage.Errors;
using Garage.Interfaces;
using GarageTask.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTask {
    internal class GarageHandler : IGarageHandler {

        IGarage<IVehicle> _garage;

        public GarageHandler(int garageSize) {
            _garage = new Garage<IVehicle>(garageSize);
        }

        /// <summary>
        /// Gets the full garage array which can contain empty spots with null.
        /// </summary>
        /// <returns>Fhe full garage array which can contain empty spots with null.</returns>

        public IVehicle[] GetArrayOfVehiclesAndEmptySpots() {
            return _garage.GetVehicleArray<IVehicle>();
        }

        /// <summary>
        /// Filters the garage array for vehicles and returns them as a list.
        /// </summary>
        /// <returns>A list of vehicle sin the garage.</returns>

        public List<IVehicle> GetListOfOnlyVehicles() {

            List<IVehicle> listOfVehicles = new List<IVehicle>();
            IVehicle[] array = _garage.GetVehicleArray<IVehicle>();

            for (int i = 0; i < _garage.GetTotalGarageSpaces(); i++) {
                if (array[i] != null) {
                    listOfVehicles.Add(array[i]);
                }
            }
            return listOfVehicles;
        }

        public int GetTotalGarageSpaces() {
            return _garage.GetTotalGarageSpaces();
        }

        public int GetRemainingGarageSpaces() {
            return _garage.GetRemainingGarageSpaces();
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

        public bool RemoveVehicleAtSpotNumber(int index) {
            return _garage.RemoveVehicleAtSpotNumber(index);
        }

        public bool RemoveVehicleWithRegistrationNumber(string regNumber) {
            return _garage.RemoveVehicleWithRegistrationNumber(regNumber);
        }

        public IVehicle FindVehicleAtSpotNumber(int index) {
            return _garage.FindVehicleAtSpotNumber(index);
        }

        public IVehicle FindVehicleWithRegistrationNumber(string regNumber) {
            return _garage.FindVehicleWithRegistrationNumber(regNumber);
        }

        /// <summary>
        /// Looks over the garage and collects all the vehicle types present.
        /// </summary>
        /// <returns>A list of vehicle types present in the garage.</returns>

        public List<String> CollectAllVehicleTypes() {
            List<string> listOfTypes = new List<string>();

            foreach (IVehicle v in _garage.GetVehicleArray<IVehicle>()) {

                if (v != null) {
                    if (!listOfTypes.Contains(v.GetType().Name)) {
                        listOfTypes.Add(v.GetType().Name);
                    }
                }
            }
            return listOfTypes;
        }

        /// <summary>
        /// Counts the vehicles of the provided type in the garage array.
        /// </summary>
        /// <param name="type">The vehicle type to count.</param>
        /// <returns>The amount of that vehicle type present in the garage.</returns>

        public int CountVehiclesOfType(string type) {
            int result = 0;

            foreach (IVehicle v in _garage.GetVehicleArray<IVehicle>()) {
                if (v != null) {
                    if (v.GetType().Name.Equals(type)) {
                        result++;
                    }
                }
                    
            }
            return result;
        }


    }
}
