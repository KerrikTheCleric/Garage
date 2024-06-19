using Garage;
using Garage.Enums;
using Garage.Interfaces;
using GarageTask.Vehicles;
using System.Resources;
using System.Text.Json;

/*
 TODO:

 1. Remove JSON File
 2. Make printing columns into a constant
 3. Move functionality from Garage to GarageHandler?
 4. Match interfaces with implementations.
 5. Print garage using colours?
 6. Swap properties for standard fields.
 7. Decide on how to balance custom errors versus exceptions.
 8. Add offset for first 9 printed vehicles in the display.
 
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


            /*try {
                Boat b1 = new Boat("aBa123", Colour.Orange, 400.6, 2320.8, 60, true);
                Airplane a1 = new Airplane("TBA555", Colour.Yellow, 0.0, 0.0, 0, 'B',8);
                Motorcycle m1 = new Motorcycle("KLG899", Colour.Purple, 0.0, 0.0, 0, true);

                Garage<IVehicle> garage = new Garage<IVehicle>(45);



                garage.AddVehicle(b1);
                garage.AddVehicle(a1);
                garage.AddVehicle(m1);

                foreach (IVehicle v in garage) {
                    Console.WriteLine(v.GetRegistrationNumber());
                }

                garage.PrintGarage(10);

                IVehicle result = garage.FindVehicleAtSpotNumber(2);

                Console.WriteLine(result.GetRegistrationNumber());
                Console.WriteLine(result.GetType());
                Console.WriteLine(result is Boat);

                switch (result.GetType().Name) {

                    case "Motorcycle":
                        Motorcycle m = (Motorcycle)result;
                        Console.WriteLine("Is a motorcycle! Has carriage: " + m.GetHasCarriage());
                        break;
                    default:
                        break;
                }


            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }*/

        }
    }
}
