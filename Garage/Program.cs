using GarageTask.Vehicles;

namespace GarageTask {
    internal class Program {
        static void Main(string[] args) {
            try {
                Boat b1 = new Boat("aBa123", Colour.Orange, 400.6, 2320.8, 60);
                Airplane a1 = new Airplane("TBA555", Colour.Yellow, 0.0, 0.0, 0, 8);
                Motorcycle m1 = new Motorcycle("KLG899", Colour.Purple, 0.0, 0.0, 0);

                Garage<IVehicle> garage = new Garage<IVehicle>(15);

                garage.AddVehicle(b1);
                garage.AddVehicle(a1);
                garage.AddVehicle(m1);

                foreach (IVehicle v in garage) {
                    Console.WriteLine(v.GetRegistrationNumber());
                }

                garage.PrintGarage(3);
            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }
            


            

            

        }
    }
}
