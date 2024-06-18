using Garage.Errors;
using Garage.Interfaces;
using GarageTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage {
    internal class GarageManager {
        IUI uI;
        IGarageHandler gHandler;

        public GarageManager() {
            uI = new UI();

            int garageSize = uI.AskGarageSize();

            while (garageSize  <= 0) {
                uI.DisplayError(new GarageSizeError().UEMessage());
                garageSize = uI.AskGarageSize();
            }

            gHandler = new GarageHandler(garageSize);
        }


        public void StartProgram() {

            // Print Empty Garage

            uI.PrintGarage(gHandler.GetArrayOfVehicles(), gHandler.GetTotalGarageSpaces());

            // Ask to populate garage with old vehicles
        }
    }
}
