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

        public int AskHowManyVehiclesShouldBeAddedAutomatically(int availabelVehicles, int totalGarageSpaces);

        public void ClearConsole();

        public void PrintWelcomeMessage();

        public void PrintStandardMenuMessage();

        public int MainMenu();

        public void PrintVehicle(IVehicle v, int number = -1);

        public void PrintArrayOfVehicles(IVehicle[] array);

        public void PrintExitMessage();

        public int AskForMethodOfSearchingVehicle();

        public int AskForParkingNumber(int totalGarageSpaces);

        public string AskForRegistrationNumber();

        public void PrintVehicleTypeCount(string type, int count);
    }
}
