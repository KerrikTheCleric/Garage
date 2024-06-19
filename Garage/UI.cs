using Garage.Errors;
using Garage.Interfaces;
using Garage.Resources;
using GarageTask.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage {
    internal class UI : IUI {

        public char YorN() {
            while (true) {
                char input = char.ToUpper(Console.ReadKey().KeyChar);

                if (input == 'Y' || input == 'N') {
                    Console.WriteLine();
                    return input;
                }
                Console.Write("\b \b"); // Use backspace ('\b') to erase the incorrect character.
            }
        }

        public void DisplayError(string error) {
            Console.WriteLine("Error: " + error);
        }

        public int AskGarageSize() {
            Console.WriteLine("Initializing new garage. Input the maximum amount of vehicles desired below:\n");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult <= 0) {
                DisplayError(new GarageSizeError().UEMessage());
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }

            return parsedResult;
        }

        public void PrintGarage(IVehicle[] vehicles, int totalGarageSpaces) {

            int columnsPrinted = 0;
            int spacesPrinted = 0;

            for (int i = 0; i < totalGarageSpaces; i++) {
                if (vehicles[i] == null) {
                    Console.Write($"{spacesPrinted + 1}. [ ] ");
                } else {
                    Console.Write($"{spacesPrinted + 1}. [V] ");
                }
                columnsPrinted++;
                spacesPrinted++;

                if (columnsPrinted == GarageConstants.GARAGE_PRINTING_COLUMN_COUNT) {
                    Console.Write("\n");
                    columnsPrinted = 0;
                }
            }
            Console.WriteLine("");
        }

        public bool AskIfGarageShouldBePrefilled() {
            Console.WriteLine("Would you like to fill up the garage with already existing vehicles, Y/N?\n");

            if (YorN() == 'Y') {
                return true;
            } else {
                return false;
            }
        }

        public int AskHowManyVehiclesShouldBeAddedAutomatically(int availabelVehicles, int totalGarageSpaces) {

            int upperLimit = 0;
            if (totalGarageSpaces < availabelVehicles) {
                upperLimit = totalGarageSpaces;
            } else {
                upperLimit = availabelVehicles;
            }

            Console.WriteLine($"There are {totalGarageSpaces} parking spots available and there are {availabelVehicles} vehicles that can be added. How many would you like to add? Enter a number ranging from 1 to {upperLimit}:\n");

            int desiredAmount = int.TryParse(Console.ReadLine(), out desiredAmount) ? desiredAmount : 0;
            

            while (desiredAmount <= 0 || desiredAmount > upperLimit) {
                Console.WriteLine($"Please enter a number ranging from 1 to {upperLimit}:\n");
                desiredAmount = int.TryParse(Console.ReadLine(), out desiredAmount) ? desiredAmount : 0;
            }
            return desiredAmount;
        }
    }
}
