using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interfaces {
    internal interface IUI {

        public char YorN();

        public void DisplayError(string error);

        public int AskGarageSize();

        public void PrintGarage(IVehicle[] vehicles, int totalGarageSpaces);

        public bool AskIfGarageShouldBePrefilled();
    }
}
