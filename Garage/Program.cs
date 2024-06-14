using GarageTask.Vehicles;

namespace GarageTask {
    internal class Program {
        static void Main(string[] args) {
            Boat b1 = new Boat();
            Airplane a1 = new Airplane();
            Motorcycle m1 = new Motorcycle();

            Garage<IVehicle> garage = new Garage<IVehicle>(3);

            garage.AddVehicle(b1);
            garage.AddVehicle(a1);
            //garage.AddVehicle(m1);

            foreach (IVehicle v in garage) {
                Console.WriteLine(v.GetType());
            }

            garage.PrintGarage(3);

        }
    }
}
