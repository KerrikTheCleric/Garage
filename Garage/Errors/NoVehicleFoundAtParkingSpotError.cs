using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Errors {
    internal class NoVehicleFoundAtParkingSpotError : UserError {
        public override string UEMessage() {
            return "No vehicle parked at that parking space.";
        }
    }
}
