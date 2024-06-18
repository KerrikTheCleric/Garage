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

        public void DisplayError(string error) {
            Console.WriteLine("Error: " + error);
        }

        public int AskGarageSize() {

            Console.WriteLine("Initializing new garage. Input the maximum amount of vehicles desired below:\n");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
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


            /*foreach (IVehicle v in this) {
                Console.Write($"{spacesPrinted + 1}. [V] ");
                columnsPrinted++;
                spacesPrinted++;

                if (columnsPrinted == columns) {
                    Console.Write("\n");
                    columnsPrinted = 0;
                }
            }

            for (int i = 0; i < RemainingGarageSpaces; i++) {
                Console.Write($"{spacesPrinted + 1}. [ ] ");
                columnsPrinted++;
                spacesPrinted++;


                if (columnsPrinted == columns) {
                    Console.Write("\n");
                    columnsPrinted = 0;
                }
            }*/
            Console.WriteLine("");
        }
    }
}
