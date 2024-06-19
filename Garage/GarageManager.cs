﻿using Garage.Enums;
using Garage.Errors;
using Garage.Interfaces;
using GarageTask;
using GarageTask.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage {
    internal class GarageManager {
        IUI uI;
        IGarageHandler gHandler;

        public GarageManager() {
            uI = new UI();
            int garageSize = uI.AskGarageSize();
            gHandler = new GarageHandler(garageSize);
        }


        public void StartProgram() {

            // Print Empty Garage
            //uI.PrintGarage(gHandler.GetArrayOfVehicles(), gHandler.GetTotalGarageSpaces());

            // Ask to populate garage with old vehicles

            if (uI.AskIfGarageShouldBePrefilled()) {
                PopulateGarage();
            }
            MainLoop();
        }

        private void MainLoop() {
            uI.ClearConsole();
            uI.PrintGarage(gHandler.GetArrayOfVehiclesAndEmptySpots(), gHandler.GetTotalGarageSpaces());
            uI.PrintWelcomeMessage();

            bool exit = false;

            while (!exit) {
                switch (uI.MainMenu()) {
                    case 1:
                        DisplayVehicle();
                        break;
                    case 2:
                        DisplayAllVehicles();
                        break;
                    case 3:
                        DisplayVehicleTypes();
                        break;
                    case 4:
                        AddVehicle();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        exit = true;
                        break;
                    default:
                        break;
                }
                uI.PrintGarage(gHandler.GetArrayOfVehiclesAndEmptySpots(), gHandler.GetTotalGarageSpaces());
                uI.PrintStandardMenuMessage();
            }
            uI.ClearConsole();
            uI.PrintExitMessage();
        }

        private void DisplayVehicle() {
            IVehicle result = null;
            bool parkingSpotSearch = false;

            switch (uI.AskForMethodOfSearchingVehicle()) {
                case 1:
                    uI.PrintGarage(gHandler.GetArrayOfVehiclesAndEmptySpots(), gHandler.GetTotalGarageSpaces());
                    result = gHandler.FindVehicleAtSpotNumber(uI.AskForParkingNumber(gHandler.GetTotalGarageSpaces()));
                    parkingSpotSearch = true;
                    break;
                case 2:
                    result = gHandler.FindVehicleWithRegistrationNumber(uI.AskForRegistrationNumber());
                    break;
                default:
                    break;
            }

            if (result != null) {
                uI.PrintVehicle(result);
            } else if(parkingSpotSearch){
                uI.DisplayError(new NoVehicleFoundAtParkingSpotError().UEMessage());
            } else {
                uI.DisplayError(new NoVehicleWithRegistrationNumberFoundError().UEMessage());
            }
        }

        private void DisplayAllVehicles() {
            IVehicle[] vehicleArray = gHandler.GetArrayOfVehiclesAndEmptySpots();
            uI.PrintArrayOfVehicles(vehicleArray);
        }

        private void DisplayVehicleTypes() {
            List<string> listOfTypes = gHandler.CollectAllVehicleTypes();

            foreach (string type in listOfTypes) {
                uI.PrintVehicleTypeCount(type, gHandler.CountVehiclesOfType(type));
            }
        }

        private void AddVehicle() {
            // Ask for type

            string type = uI.AskForType();

            // Ask For RegistrationNumber

            string regNumber = uI.AskForRegistrationNumber();

            // Ask for Colour

            Colour colour = uI.AskForColour();

            // Ask for Cargo Space

            double cargoSpace = uI.AskForCargoSpace();

            // Ask for Weight

            double weight = uI.AskForWeight();

            // Ask for TopSpeed

            int topSpeed = uI.AskForTopSpeed();

            // Ask for Wheels

            int wheels = uI.AskForWheels();

            // Switch case on type, ask for specific value

            IVehicle v;

            switch (type) {
                case "Airplane":
                    char flightClass = uI.AskForFlightClass();
                    v = new Airplane(regNumber, colour, cargoSpace, weight, topSpeed, flightClass, wheels);

                    try {
                        gHandler.AddVehicleToGarage(v);
                    } catch (Exception e) {
                        uI.DisplayError(e.Message);
                    }
                    break;
                case "Boat":
                    bool hasSail = uI.AskForHasSail();
                    v = new Boat(regNumber, colour, cargoSpace, weight, topSpeed, hasSail, wheels);

                    try {
                        gHandler.AddVehicleToGarage(v);
                    } catch (Exception e) {
                        uI.DisplayError(e.Message);
                    }
                    break;
                case "Bus":
                    bool isDoubleDecker = uI.AskForIsDoubleDecker();
                    v = new Bus(regNumber, colour, cargoSpace, weight, topSpeed, isDoubleDecker, wheels);

                    try {
                        gHandler.AddVehicleToGarage(v);
                    } catch (Exception e) {
                        uI.DisplayError(e.Message);
                    }
                    break;
                case "Car":
                    FuelType fueltype = uI.AskForFuelType();
                    v = new Car(regNumber, colour, cargoSpace, weight, topSpeed, fueltype, wheels);

                    try {
                        gHandler.AddVehicleToGarage(v);
                    } catch (Exception e) {
                        uI.DisplayError(e.Message);
                    }
                    break;
                case "Motorcycle":
                    bool hasCarriage = uI.AskForHasCarriage();
                    v = new Motorcycle(regNumber, colour, cargoSpace, weight, topSpeed, hasCarriage, wheels);

                    try {
                        gHandler.AddVehicleToGarage(v);
                    } catch (Exception e) {
                        uI.DisplayError(e.Message);
                    }
                    break;
                case "Vehicle":
                    v = new Vehicle(regNumber, colour, cargoSpace, weight, topSpeed, wheels);

                    try {
                        gHandler.AddVehicleToGarage(v);
                    } catch (Exception e) {
                        uI.DisplayError(e.Message);
                    }
                    break;
                default:
                    break;
            }

            uI.PrintAddVehicleSuccessMessage();

            // Create Vehicle and add it to the garage

            
        }

        private void PopulateGarage() {

            // Declare Vehicles

            List<Vehicle> prefabList = new List<Vehicle>();

            prefabList.Add(new Airplane("TBA555", Colour.Black, 865.7, 1500, 700, 'B', 8));
            prefabList.Add(new Boat("aBa123", Colour.Blue, 400.6, 2320.8, 60, true));
            prefabList.Add(new Bus("JKT550", Colour.Brown, 655, 3000.4, 120, true, 6));
            prefabList.Add(new Car("KOL901", Colour.Gold, 201.6, 489.7, 150, FuelType.Diesel, 4));
            prefabList.Add(new Motorcycle("KLG899", Colour.Purple, 12.5, 220.5, 160, false));
            prefabList.Add(new Vehicle("MMO010", Colour.Gray, 77.8, 500.7, 90, 5));

            prefabList.Add(new Airplane("TBA666", Colour.Blue, 865.7, 1500, 0, 'A', 8));
            prefabList.Add(new Boat("aBa124", Colour.Brown, 400.6, 2320.8, 60, true));
            prefabList.Add(new Bus("JKT555", Colour.Gold, 655, 3000.4, 150, true));
            prefabList.Add(new Car("KOL988", Colour.Purple, 201.6, 449.7, 220, FuelType.Gasoline, 4));
            prefabList.Add(new Motorcycle("KLL899", Colour.Gray, 18.5, 320.5, 180, true));
            prefabList.Add(new Vehicle("MMO989", Colour.Green, 67.8, 550.7, 175, 0));

            prefabList.Add(new Airplane("TBA444", Colour.Brown, 895.7, 1500, 700, 'B', 8));
            prefabList.Add(new Boat("aBa567", Colour.Gold, 400.6, 2320.8, 60, true));
            prefabList.Add(new Bus("JAK550", Colour.Purple, 655, 3200.4, 150, true));
            prefabList.Add(new Car("KOL999", Colour.Gray, 199.6, 689.7, 225, FuelType.Diesel, 4));
            prefabList.Add(new Motorcycle("KGG400", Colour.Purple, 12.5, 120.5, 190, false));
            prefabList.Add(new Vehicle("MMP010", Colour.Red, 47.8, 580.7, 600, 7));



            // Ask how many Vehicles to put in out of the maximum available and maximum

            int vehiclesToAdd = uI.AskHowManyVehiclesShouldBeAddedAutomatically(prefabList.Count, gHandler.GetTotalGarageSpaces());

            // Add vehicles

            for (int i = 0; i < vehiclesToAdd; i++) {
                try {
                    gHandler.AddVehicleToGarage(prefabList[i]);
                } catch (Exception) {
                    uI.DisplayError("There was an issue with one of the premade vehicles and it wasn't added to the garage.");
                }
            }
        }
    }
}
