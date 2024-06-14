using GarageTask.Vehicles;

namespace GarageTask {
    internal class Program {
        static void Main(string[] args) {
            Boat b1 = new Boat();
            Boat b2 = new Boat();
            Boat b3 = new Boat();

            Garage<IVehicle> garage = new Garage<IVehicle>(1);

            garage.AddVehicle(b1);
        }
    }
}
