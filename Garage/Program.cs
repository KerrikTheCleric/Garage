using Garage;
using GarageTask.Vehicles;
using System.Resources;
using System.Text.Json;

namespace GarageTask {
    internal class Program {
        static void Main(string[] args) {


            /*GarageManager gManager = new GarageManager();

            try {
                gManager.StartProgram();
            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }*/

            //string jsonString = File.ReadAllText("Resources\\starter_vehicles.json");
            //Airplane a = JsonSerializer.Deserialize<Airplane>(jsonString);


            try {
                Boat b1 = new Boat("aBa123", Colour.Orange, 400.6, 2320.8, 60, true);
                Airplane a1 = new Airplane("TBA555", Colour.Yellow, 0.0, 0.0, 0, 'B',8);
                Motorcycle m1 = new Motorcycle("KLG899", Colour.Purple, 0.0, 0.0, 0, false);

                Garage<IVehicle> garage = new Garage<IVehicle>(45);



                garage.AddVehicle(b1);
                garage.AddVehicle(a1);
                garage.AddVehicle(m1);

                foreach (IVehicle v in garage) {
                    Console.WriteLine(v.GetRegistrationNumber());
                }

                garage.PrintGarage(10);

                IVehicle result = garage.FindVehicleAtSpotNumber(44);

                Console.WriteLine(result.GetRegistrationNumber());
                Console.WriteLine(result.GetType());
                Console.WriteLine(result is Boat);

                switch (result.GetType().Name) {

                    case "Motorcycle":
                        Console.WriteLine("Is a motorcycle!");
                        break;
                    default:
                        break;
                }


            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }
            


            

            

        }
    }
}
