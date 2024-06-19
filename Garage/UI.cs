using Garage.Enums;
using Garage.Errors;
using Garage.Interfaces;
using Garage.Resources;
using GarageTask.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
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
                Console.Write("\b \b");
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

            while (spacesPrinted < 9) {
                if (vehicles[spacesPrinted] == null) {
                    Console.Write($" {spacesPrinted + 1}. [ ] ");
                } else {
                    Console.Write($" {spacesPrinted + 1}. [V] ");
                }
                columnsPrinted++;
                spacesPrinted++;

                if (columnsPrinted == GarageConstants.GARAGE_PRINTING_COLUMN_COUNT) {
                    Console.Write("\n");
                    columnsPrinted = 0;
                }
            }

            for (int i = spacesPrinted; i < totalGarageSpaces; i++) {
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
                Console.WriteLine("");
                return true;
            } else {
                Console.WriteLine("");
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

        public void ClearConsole() {
            Console.Clear();
        }

        public void PrintWelcomeMessage() {
            Console.WriteLine("Welcome to Garage Software. This is the main menu where you can select options pertaining to your garage by inputting the appropriate number as listed below:\n");
        }

        public void PrintStandardMenuMessage() {
            Console.WriteLine("Please select an option by inputting the appropriate number as listed below:\n");
        }

        public int MainMenu() {
            Console.WriteLine("1) Display Vehicle");
            Console.WriteLine("2) Display All Vehicles");
            Console.WriteLine("3) Vehicle Types");
            Console.WriteLine("4) Add Vehicle");
            Console.WriteLine("5) Nothing");
            Console.WriteLine("6) Nothing");
            Console.WriteLine("7) Nothing");
            Console.WriteLine("8) Nothing");
            Console.WriteLine("9) Nothing");
            Console.WriteLine("10) Nothing");
            Console.WriteLine("11) Nothing");
            Console.WriteLine("12) Exit");

            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult <= 0 && parsedResult < 13) {
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }

            ClearConsole();

            return parsedResult;
        }


        public void PrintVehicle(IVehicle v, int number = -1) {

            if (v != null) {

                switch (v.GetType().Name) {
                    case "Airplane":
                        Airplane airplane = (Airplane)v;
                        if (number == -1) {
                            Console.WriteLine(airplane.GetSpecificationsText());
                        } else {
                            Console.WriteLine($"{number}. " + airplane.GetSpecificationsText());
                        }
                        break;
                    case "Boat":
                        Boat boat = (Boat)v;
                        if (number == -1) {
                            Console.WriteLine(boat.GetSpecificationsText());
                        } else {
                            Console.WriteLine($"{number}. " + boat.GetSpecificationsText());
                        }
                        break;
                    case "Bus":
                        Bus bus = (Bus)v;
                        if (number == -1) {
                            Console.WriteLine(bus.GetSpecificationsText());
                        } else {
                            Console.WriteLine($"{number}. " + bus.GetSpecificationsText());
                        }
                        break;
                    case "Car":
                        Car car = (Car)v;
                        if (number == -1) {
                            Console.WriteLine(car.GetSpecificationsText());
                        } else {
                            Console.WriteLine($"{number}. " + car.GetSpecificationsText());
                        }
                        break;
                    case "Motorcycle":
                        Motorcycle motorcycle = (Motorcycle)v;
                        if (number == -1) {
                            Console.WriteLine(motorcycle.GetSpecificationsText());
                        } else {
                            Console.WriteLine($"{number}. " + motorcycle.GetSpecificationsText());
                        }                        
                        break;
                    case "Vehicle":
                        Vehicle vehicle = (Vehicle)v;
                        if (number == -1) {
                            Console.WriteLine("Unknown Vehicle: " +vehicle.GetSpecificationsText());
                        } else {
                            Console.WriteLine($"{number}. " + "Unknown Vehicle: " + vehicle.GetSpecificationsText());
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void PrintArrayOfVehicles(IVehicle[] array) {
            for (int i = 0; i < array.Length; i++) {
                PrintVehicle(array[i], i + 1);
            }
            Console.WriteLine();
        }

        public void PrintExitMessage() {
            Console.WriteLine("Exiting application...\n");
        }

        public int AskForMethodOfSearchingVehicle() {

            Console.WriteLine("How do you wish to find the vehicle?\n");
            Console.WriteLine("1) Parking Number");
            Console.WriteLine("2) Registration Number\n");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult != 1 && parsedResult != 2 ) {
                DisplayError(new OneOrTwoError().UEMessage());
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");
            return parsedResult;
        }

        public int AskForParkingNumber(int totalGarageSpaces) {

            Console.WriteLine($"Please input the desired parking number in the span 1 through {totalGarageSpaces} below:\n");

            int desiredParkingNumber = int.TryParse(Console.ReadLine(), out desiredParkingNumber) ? desiredParkingNumber : 0;

            while (desiredParkingNumber <= 0 || desiredParkingNumber > totalGarageSpaces) {
                Console.WriteLine($"Please enter a parking number ranging from 1 to {desiredParkingNumber}:\n");
                desiredParkingNumber = int.TryParse(Console.ReadLine(), out desiredParkingNumber) ? desiredParkingNumber : 0;
            }
            Console.WriteLine("");
            return desiredParkingNumber - 1;
        }

        public string AskForRegistrationNumber() {
            Console.WriteLine($"Please input the desired registration number formatted like \"ABC123\"\n");

            string desiredRegNumber = Console.ReadLine().ToUpper();

            while (!Helper.IsRegistrationNumberValid(desiredRegNumber)) {
                Console.WriteLine($"Please enter a registration number formatted like \"ABC123\"\n");
                desiredRegNumber = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("");
            return desiredRegNumber;
        }

        public void PrintVehicleTypeCount(string type, int count) {
            Console.WriteLine($"{type}: {count}");
        }

        public string AskForType() {
            Console.WriteLine("What type of vehicle is it? Select \"Vehicle\" if nothing matches.\n");
            Console.WriteLine("1) Airplane");
            Console.WriteLine("2) Boat");
            Console.WriteLine("3) Bus");
            Console.WriteLine("4) Car");
            Console.WriteLine("5) Motorcycle");
            Console.WriteLine("6) Vehicle");


            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (!Enumerable.Range(1, 6).Contains(parsedResult)) {
                Console.WriteLine($"Please pick a type by inputting a number from 1 through 6.\n");
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");

            switch (parsedResult) {
                case 1:
                    return "Airplane";
                case 2:
                    return "Boat";
                case 3:
                    return "Bus";
                case 4:
                    return "Car";
                case 5:
                    return "Motorcycle";
                case 6:
                    return "Vehicle";
                default:
                    return "";
            }
        }

        public Colour AskForColour() {

            Console.WriteLine("What colour is the vehicle?\n");
            Console.WriteLine("1) Blue");
            Console.WriteLine("2) Green");
            Console.WriteLine("3) Orange");
            Console.WriteLine("4) Yellow");
            Console.WriteLine("5) Purple");
            Console.WriteLine("6) Brown");
            Console.WriteLine("7) Gray");
            Console.WriteLine("8) Red");
            Console.WriteLine("9) Pink");
            Console.WriteLine("10) White");
            Console.WriteLine("11) Black");
            Console.WriteLine("12) Gold");

            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (!Enumerable.Range(1, 12).Contains(parsedResult)) {
                Console.WriteLine($"Please pick a colour by inputting a number from 1 through 12.\n");
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");

            switch (parsedResult) {
                case 1:
                    return Colour.Blue;
                case 2:
                    return Colour.Green;
                case 3:
                    return Colour.Orange;
                case 4:
                    return Colour.Yellow;
                case 5:
                    return Colour.Purple;
                case 6:
                    return Colour.Brown;
                case 7:
                    return Colour.Gray;
                case 8:
                    return Colour.Red;
                case 9:
                    return Colour.Pink;
                case 10:
                    return Colour.White;
                case 11:
                    return Colour.Black;
                case 12:
                    return Colour.Gold;
                default:
                    return Colour.White;
            }
        }

        public double AskForCargoSpace() {
            Console.WriteLine($"Please input the cargo space of the vehicle in cubic meters. Decimal numbers are allowed.");

            double parsedResult = double.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult < 0) {
                Console.WriteLine($"Please input the cargo space of the vehicle in cubic meters. Decimal numbers are allowed.");
                parsedResult = double.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");
            return parsedResult;
        }

        public double AskForWeight() {
            Console.WriteLine($"Please input the weight of the vehicle in Kg. Decimal numbers are allowed.");

            double parsedResult = double.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult < 0) {
                Console.WriteLine($"Please input the weight of the vehicle in Kg. Decimal numbers are allowed.");
                parsedResult = double.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");
            return parsedResult;
        }

        public int AskForTopSpeed() {
            Console.WriteLine($"Please input the top speed of the vehicle in Km/h.");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult < 0) {
                Console.WriteLine($"Please input the top speed of the vehicle in Km/h.");
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");
            return parsedResult;
        }

        public int AskForWheels() {
            Console.WriteLine($"Please input how many wheels the vehicle has.");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult < 0) {
                Console.WriteLine($"Please input how many wheels the vehicle has.");
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");
            return parsedResult;
        }

        public char AskForFlightClass() {

            Console.WriteLine($"Please provide the flight class of the airplane. Accepted classes are 'A', 'B' & 'C'.");

            while (true) {
                char parsedResult = char.ToUpper(Console.ReadKey().KeyChar);

                if (parsedResult == 'A' || parsedResult == 'B' || parsedResult == 'C') {
                    Console.WriteLine();
                    return parsedResult;
                }
                Console.Write("\b \b");
            }
        }

        public bool AskForHasSail() {
            Console.WriteLine("Does the boat have a sail?\n");
            Console.WriteLine("1) True");
            Console.WriteLine("2) False\n");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult != 1 && parsedResult != 2) {
                DisplayError(new OneOrTwoError().UEMessage());
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");

            if (parsedResult == 1) { return true; } else {
                return false;
            }
        }

        public bool AskForIsDoubleDecker() {
            Console.WriteLine("Is the bus a double decker?\n");
            Console.WriteLine("1) True");
            Console.WriteLine("2) False\n");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult != 1 && parsedResult != 2) {
                DisplayError(new OneOrTwoError().UEMessage());
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");

            if (parsedResult == 1) { return true; } else {
                return false;
            }

        }

        public FuelType AskForFuelType() {
            Console.WriteLine("Does the car run on Diesel or Gasoline?\n");
            Console.WriteLine("1) Diesel");
            Console.WriteLine("2) Gasoline\n");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult != 1 && parsedResult != 2) {
                DisplayError(new OneOrTwoError().UEMessage());
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");

            if (parsedResult == 1) { return FuelType.Diesel; } else {
                return FuelType.Gasoline;
            }
        }

        public bool AskForHasCarriage() {
            Console.WriteLine("Does the motorcycle have a carriage?\n");
            Console.WriteLine("1) True");
            Console.WriteLine("2) False\n");
            int parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;

            while (parsedResult != 1 && parsedResult != 2) {
                DisplayError(new OneOrTwoError().UEMessage());
                parsedResult = int.TryParse(Console.ReadLine(), out parsedResult) ? parsedResult : -1;
            }
            Console.WriteLine("");

            if (parsedResult == 1) { return true; } else {
                return false;
            }
        }

        public void PrintAddVehicleSuccessMessage() {
            Console.WriteLine("==New vehicle successfully added to garage.==\n");
        }
    }
}
