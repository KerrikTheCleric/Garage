using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interfaces {
    internal interface IGarageHandler {


        public IVehicle[] GetArrayOfVehicles();

        public int GetTotalGarageSpaces();
    }
}
