using Garage;
using Garage.Enums;
using Garage.Interfaces;
using GarageTask.Vehicles;
using System.Resources;
using System.Text.Json;

/*
 TODO:

 1. Remove JSON File
 3. Move functionality from Garage to GarageHandler?
 4. Match interfaces with implementations.
 5. Print garage using colours?
 6. Swap properties for standard fields.
 7. Decide on how to balance custom errors versus exceptions.
 8. Add offset for first 9 printed vehicles in the display.
 8. Combine UI Ask methods
 
 */

namespace GarageTask
{
    internal class Program {
        static void Main(string[] args) {


            GarageManager gManager = new GarageManager();

            try {
                gManager.StartProgram();
            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
