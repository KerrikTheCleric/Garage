using Garage.Interfaces;
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
    }
}
