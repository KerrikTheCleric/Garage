using Garage;
using Garage.Enums;
using Garage.Interfaces;
using GarageTask.Vehicles;
using System.Resources;
using System.Text.Json;

/*
 TODO:

 Print garage using colours?
 Combine UI Ask methods
 Remove needless properties
 Immediately cancel new vehicle process after inputting registration number if it already exists.
 
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
