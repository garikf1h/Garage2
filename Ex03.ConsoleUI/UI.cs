using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        private Garage m_Garage;

        public UI()
        {
            m_Garage = new Garage();
            RunUI();
        }

        private enum eExitOrCont
        {
            Exit = -1,
            Continue
        }

        public void RunUI()
        {
            int input;
            Console.WriteLine("Hello, Welcome to the garage");
            Console.WriteLine("=======================================");
            printMenu();
            input = getValidChoise();
            Console.Clear();
            while (input != 8)
            {
                switch (input)
                {
                    case 1:
                        {
                            addVehicleToGarageMenu();
                            break;
                        }

                    case 2:
                        {
                            showVehiclesByLicensePlateNumber();
                            break;
                        }

                    case 3:
                        {
                            changeStatOfCarMenu();
                            break;
                        }

                    case 4:
                        {
                            pumpWheelsToMaxMenu();
                            break;
                        }

                    case 5:
                        {
                            fillFuelMenu();
                            break;
                        }

                    case 6:
                        {
                            chargeEnergyMenu();
                            break;
                        }

                    case 7:
                        {
                            printAllVehicles();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("This wasn't a correct choise");
                            break;
                        }
                }

                printMenu();
                input = getValidChoise();
            }

            Console.WriteLine("Have a nice day");
        }

        private void printAllVehicles()
        {
            StringBuilder outputMess = m_Garage.GetAllVehicles();
            Console.WriteLine(outputMess);
        }

        private int getValidChoise()
        {
            int input;
            string inputString = Console.ReadLine();
            while(!int.TryParse(inputString, out input))
            {
                Console.Write("This wasn't correct choise! please pick a digit from the list!");
                inputString = Console.ReadLine();
            }

            return input;
        }

        private void showVehiclesByLicensePlateNumber()
        {
            eRepairStatus repairStatus;
            repairStatus = getValidRepairStatus();
            StringBuilder outputVehicles = m_Garage.GetVehiclesByLicensePlateNumberAndStatus(repairStatus);
            Console.WriteLine(outputVehicles);
        }

        private eRepairStatus getValidRepairStatus()
        {
            string repairStatusStr;
            int repairStatus;
            Console.WriteLine("Please enter the status of vehicles you want to see:press 0-InRepair, press 1- Fixed, press 2- Paid, press 3- All");
            repairStatusStr = Console.ReadLine();
            while(!int.TryParse(repairStatusStr, out repairStatus) || (repairStatus > 4 || repairStatus < 0))
            {
                Console.WriteLine("Wrong choise!");
                Console.WriteLine("Please enter the status of vehicles you want to see:press 0-InRepair, press 1- Fixed, press 2- Paid, press 3- All");
                repairStatusStr = Console.ReadLine();
            }

            return (eRepairStatus)repairStatus;
        }

        private void chargeEnergyMenu()
        {
            float amountOfEnergyToFill;
            Vehicle vehicleToChargeEnergyTo;
            ElectricVehicle electricVehicleToGet;
            eExitOrCont exitOrCont = eExitOrCont.Continue;
            Console.WriteLine("Please enter license plate number for car to add energy to, or press -1 to go back to the main menu");
            vehicleToChargeEnergyTo = getValidLicensePlateNumberAndGetVehicle(ref exitOrCont);
            while(!m_Garage.IsElectricType(vehicleToChargeEnergyTo, out electricVehicleToGet) && exitOrCont != eExitOrCont.Exit)
            {
                Console.WriteLine("Please enter valid vehicle, this vehicle is not electric, or press -1 to go back to the main menu");
                vehicleToChargeEnergyTo = getValidLicensePlateNumberAndGetVehicle(ref exitOrCont);
            }

            if (exitOrCont != eExitOrCont.Exit)
            {
                amountOfEnergyToFill = getAmountOfEnergyToAdd(electricVehicleToGet, ref exitOrCont);
                if (exitOrCont != eExitOrCont.Exit)
                {
                    m_Garage.ChargeEnergy(electricVehicleToGet, amountOfEnergyToFill);
                    Console.WriteLine(string.Format("Energy of {0} was charged to vehicle with license plate number of {1}, current energy level is:{2}", amountOfEnergyToFill, electricVehicleToGet.LicencsePlateNumber, electricVehicleToGet.LeftBatteryTimeInHours));
                    Thread.Sleep(1500);
                }
            }
        }

        private float getAmountOfEnergyToAdd(ElectricVehicle i_vehicle, ref eExitOrCont io_ExitOrCont)
        {
            float amountOfEnergyToFill, maxAmountToAdd;
            bool isValid;
            string amountOfEnergyToFillStr;
            Console.WriteLine("Please enter amount of energy to charge, or press -1 to go back to the main menu");
            amountOfEnergyToFillStr = Console.ReadLine();
            putExitIfMinus1(amountOfEnergyToFillStr, ref io_ExitOrCont);
            isValid = float.TryParse(amountOfEnergyToFillStr, out amountOfEnergyToFill);
            while((!m_Garage.CheckValidEnergyToAdd(i_vehicle, amountOfEnergyToFill, out maxAmountToAdd) || !isValid) && (io_ExitOrCont != eExitOrCont.Exit))
            {
                if(!isValid)
                {
                    Console.WriteLine("Please enter a float number, max float to add is " + maxAmountToAdd);
                    amountOfEnergyToFillStr = Console.ReadLine();
                    isValid = float.TryParse(amountOfEnergyToFillStr, out amountOfEnergyToFill);
                }
                else
                {
                    Console.WriteLine("Please enter a valid eneregy amount to add, min amount is 0 ,max amount possible is " + maxAmountToAdd);
                    amountOfEnergyToFillStr = Console.ReadLine();
                    isValid = float.TryParse(amountOfEnergyToFillStr, out amountOfEnergyToFill);
                }

                putExitIfMinus1(amountOfEnergyToFillStr, ref io_ExitOrCont);
            }

            return amountOfEnergyToFill;
        }

        private void putExitIfMinus1(string i_Input, ref eExitOrCont io_ExitOrCont)
        {
            if (i_Input == "-1")
            {
                io_ExitOrCont = eExitOrCont.Exit;
            }
        }

        private void pumpWheelsToMaxMenu()
        {
            Vehicle vehicleToPump;
            eExitOrCont exitOrCont = eExitOrCont.Continue;
            Console.WriteLine("Please enter license plate number for car to pump wheels to max, or press -1 to go back to main menu");
            vehicleToPump = getValidLicensePlateNumberAndGetVehicle(ref exitOrCont);
            if (exitOrCont != eExitOrCont.Exit)
            {
                m_Garage.FillWheelsOfVehicleToMax(vehicleToPump);
                Console.WriteLine(string.Format("The wheels in car with license plate number of {0} was pumped! Going back to the main menu", vehicleToPump.LicencsePlateNumber));
                Thread.Sleep(1500);
            }
        }

        private Vehicle getValidLicensePlateNumberAndGetVehicle(ref eExitOrCont io_ExitOrCont)
        {
            string licensePlateNumber = Console.ReadLine();
            putExitIfMinus1(licensePlateNumber, ref io_ExitOrCont);
            Vehicle vehicleToReturn;
            while (!m_Garage.IsCarExists(licensePlateNumber, out vehicleToReturn) && io_ExitOrCont != eExitOrCont.Exit)
            {
                Console.WriteLine("The car you entered doesn't exist in the garage! please try again. or press -1 to go back to the main menu");
                licensePlateNumber = Console.ReadLine();
                putExitIfMinus1(licensePlateNumber, ref io_ExitOrCont);
            }

            return vehicleToReturn;
        }

        private void fillFuelMenu()
        {
            float amountOfFuelToAdd;
            Vehicle vehicle;
            FuelVehicle fuelVehicleToAddTo;
            FuelVehicle.eFuel typeOfFuelToAdd;
            eExitOrCont exitOrCont = eExitOrCont.Continue;
            Console.WriteLine("Please enter license plate number for car to add fuel, or press -1 to go back to the main menu");
            vehicle = getValidLicensePlateNumberAndGetVehicle(ref exitOrCont);
            while (!m_Garage.IsFuelType(vehicle, out fuelVehicleToAddTo) && exitOrCont != eExitOrCont.Exit)
            {
                Console.WriteLine("The vehicle you entered is not fuel type, please try again , or press -1 to go back to the main menu");
                vehicle = getValidLicensePlateNumberAndGetVehicle(ref exitOrCont);
            }

            if (exitOrCont != eExitOrCont.Exit)
            {
                typeOfFuelToAdd = getFuelFromUser(fuelVehicleToAddTo, ref exitOrCont);
                if (exitOrCont != eExitOrCont.Exit)
                {
                    amountOfFuelToAdd = getAmountOfFuelToAdd(fuelVehicleToAddTo, ref exitOrCont);
                    if (exitOrCont != eExitOrCont.Exit)
                    {
                        m_Garage.FillFuel(fuelVehicleToAddTo, typeOfFuelToAdd, amountOfFuelToAdd);
                        Console.WriteLine(string.Format("The fuel was fiiled to vehicle with license plate number of {0}. Current amount of fuel in the vehicle is :{1}! Going back to the main menu", fuelVehicleToAddTo.LicencsePlateNumber, fuelVehicleToAddTo.CurrAmountOfFuel));
                        Thread.Sleep(1500);
                    }
                }
            }
        }

        private float getAmountOfFuelToAdd(FuelVehicle i_FuelVehicleToAdd, ref eExitOrCont io_ExitOrCont)
        {
            string amountOfFuelStr;
            float amountOfFuelToAdd, maxAmountToadd;
            bool isSuccseeded;
            Console.WriteLine("Please enter amount of fuel to add, or press -1 to go back to the main menu");
            amountOfFuelStr = Console.ReadLine();
            putExitIfMinus1(amountOfFuelStr, ref io_ExitOrCont);
            isSuccseeded = float.TryParse(amountOfFuelStr, out amountOfFuelToAdd);
            while ((!m_Garage.CanAddFuel(amountOfFuelToAdd, i_FuelVehicleToAdd, out maxAmountToadd) || !isSuccseeded) && io_ExitOrCont != eExitOrCont.Exit)
            {
                Console.WriteLine("Invalid amount, max amount possible to add is" + maxAmountToadd + " please add valid amount");
                amountOfFuelStr = Console.ReadLine();
                isSuccseeded = float.TryParse(amountOfFuelStr, out amountOfFuelToAdd);
                putExitIfMinus1(amountOfFuelStr, ref io_ExitOrCont);
            }

            return amountOfFuelToAdd;
        }

        private FuelVehicle.eFuel getFuelFromUser(FuelVehicle i_FuelVehicle, ref eExitOrCont io_ExitOrCont)
        {
            string numStr;
            int numOfFuel;
            bool isSuccseeded;
            FuelVehicle.eFuel correctFuelType;
            Console.WriteLine("Please enter type of fuel to add, 0 - soler, 1 - octan95, 2 - octan96, 3 - octan98, or press -1 to go back to the main menu");
            numStr = Console.ReadLine();
            putExitIfMinus1(numStr, ref io_ExitOrCont);
            isSuccseeded = int.TryParse(numStr, out numOfFuel);
            while((!isSuccseeded || !isValidOptionType(numOfFuel) || !m_Garage.IfFuelFits(i_FuelVehicle, (FuelVehicle.eFuel)numOfFuel, out correctFuelType)) && io_ExitOrCont != eExitOrCont.Exit)
            {
                if (!isSuccseeded || !isValidOptionType(numOfFuel))
                {
                    Console.WriteLine("Wrong Choise! Please enter type of fuel to add, 0 - soler, 1 - octan95, 2 - octan96, 3 - octan98, or press -1 to go back to the main menu");
                }
                else
                {
                    m_Garage.IfFuelFits(i_FuelVehicle, (FuelVehicle.eFuel)numOfFuel, out correctFuelType);
                    Console.WriteLine(string.Format("Wrong Choise! The fuel you enterded doesn't fit the car's fuel, the correct fuel type is: {0} please pick the right one," +
                        " or press -1 to go back to the main menu", correctFuelType));
                }

                numStr = Console.ReadLine();
                putExitIfMinus1(numStr, ref io_ExitOrCont);
                isSuccseeded = int.TryParse(numStr, out numOfFuel);
            }

            return (FuelVehicle.eFuel)numOfFuel;
        }

        private bool isValidOptionType(int i_Num)
        {
            return i_Num == 0 || i_Num == 1 || i_Num == 2 || i_Num == 3;
        }

        private void changeStatOfCarMenu()
        {
            Vehicle vehicleToGet;
            eRepairStatus repairStatus;
            StringBuilder outputMess = new StringBuilder();
            eExitOrCont exitOrCont = eExitOrCont.Continue;
            Console.WriteLine("Please enter the license plate number of the vehicle you want to change the status to, or press -1 to go back to the main menu");
            vehicleToGet = getValidLicensePlateNumberAndGetVehicle(ref exitOrCont);
            if (exitOrCont != eExitOrCont.Exit)
            {
                outputMess.Append("What is the new status of the vehicle");
                outputMess.Append("? enter 0- in repair, 1- fixed, 2- was paid. To go back to the main menu press -1");
                Console.WriteLine(outputMess);
                repairStatus = getValidRepairStatus(ref exitOrCont);
                if (exitOrCont != eExitOrCont.Exit)
                {
                    m_Garage.ChangeStatusOfCar(vehicleToGet, repairStatus);
                    Console.Clear();
                    Console.WriteLine(string.Format("The status of {0} was changed to {1}", vehicleToGet.LicencsePlateNumber, repairStatus));
                    Thread.Sleep(1500);
                }
            }
        }

        private eRepairStatus getValidRepairStatus(ref eExitOrCont io_ExitOrCont)
        {
            int repairStatus;
            string repairStatusStr = Console.ReadLine();
            putExitIfMinus1(repairStatusStr, ref io_ExitOrCont);
            while ((!int.TryParse(repairStatusStr, out repairStatus) || !isValidOptionType(repairStatus)) && io_ExitOrCont != eExitOrCont.Exit)
            {
                Console.WriteLine("Invalid choise. please enter digit 0- in repair, 1- fixed, 2- was paid");
            }

            return (eRepairStatus)repairStatus;
        }

        private void addVehicleToGarageMenu()
        {
            Vehicle vehicleToAddGarage, vehicleExists;
            CustomerCard customerInfo;
            Console.WriteLine("Please enter the license plate number");
            string licensePlateNumber = Console.ReadLine();
            if (!m_Garage.IsVehicleExistsInGarage(licensePlateNumber, out vehicleExists))
            {
                vehicleToAddGarage = getVehicle(licensePlateNumber);
                customerInfo = getCustomerInfo();
                m_Garage.AddVehicleToGarage(vehicleToAddGarage, customerInfo);
                Console.Clear();
                Console.WriteLine(string.Format("The vehicle with license plate number of {0} was added to the garage!", vehicleToAddGarage.LicencsePlateNumber));
                Thread.Sleep(1500);
            }        
            else
            {
                m_Garage.ChangeStatusOfCar(vehicleExists, eRepairStatus.InRepair);
                Console.Clear();
                Console.WriteLine(string.Format("The vehicle with license plate number of {0} is already exists in the garage system, status was changed to inRepair", vehicleExists.LicencsePlateNumber));
                Thread.Sleep(1500);
            }
        }

        private Vehicle getVehicle(string i_LicensePlateNumber)
        {
            Vehicle vehicleToAddToGarage;
            CreateNewObjForGarage.eVehicle vehicleType;
            List<string> listOfQuestions, listOfAttributesToGet;
            string model;
            Console.WriteLine("Please enter the vehicle you want to add:");
            printSupportedTypes();
            vehicleType = getValidVehicleType();
            Console.WriteLine("Please enter the model of the vehicle");
            model = Console.ReadLine();
            vehicleToAddToGarage = CreateNewObjForGarage.MakeNewVehicle(vehicleType, model, i_LicensePlateNumber, out listOfQuestions, out listOfAttributesToGet);
            getAndSetInputAccordingToQuestions(vehicleToAddToGarage, listOfQuestions, listOfAttributesToGet);
            return vehicleToAddToGarage;
        }

        private void getAndSetInputAccordingToQuestions(Vehicle i_Vehicle, List<string> i_ListOfQuestions, List<string> i_ListOfAttributesToGet)
        {
            string input;
            for (int i = 0; i < i_ListOfQuestions.Count; i++)
            {
                try
                {
                    Console.WriteLine(i_ListOfQuestions[i] + " or enter -1 to cancel the adding and go back to the main menu");
                    input = Console.ReadLine();
                    i_Vehicle.SetAttribute(i_ListOfAttributesToGet[i], input);
                }
                catch(FormatException)
                {
                    Console.WriteLine("The input you have entered is not in the correct format, please try again");
                    i--;
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }
        }

        private void printSupportedTypes()
        {
            StringBuilder outputMess = new StringBuilder();
            CreateNewObjForGarage.eVehicle[] vehicleTypes = CreateNewObjForGarage.GetSupportedTypes();
            for (int i = 0; i < vehicleTypes.Length; i++)
            {
                outputMess.Append("for " + vehicleTypes[i]);
                outputMess.AppendLine(" press " + (int)vehicleTypes[i] + " ");
            }

            Console.WriteLine(outputMess);
        }

        private CreateNewObjForGarage.eVehicle getValidVehicleType()
        {
            CreateNewObjForGarage.eVehicle[] vehicleTypes = CreateNewObjForGarage.GetSupportedTypes();
            string vehicleTypeStr = Console.ReadLine();
            int vehicleType;
            while(!int.TryParse(vehicleTypeStr, out vehicleType) || !isCorrectTypeOfVehicle(vehicleType))
            {
                Console.WriteLine("Please enter a digit from the options");
                vehicleTypeStr = Console.ReadLine();
            }

            return (CreateNewObjForGarage.eVehicle)vehicleType;
        }

        private bool isCorrectTypeOfVehicle(int i_VehicleType)
        {
            CreateNewObjForGarage.eVehicle[] vehicleTypes = CreateNewObjForGarage.GetSupportedTypes();
            bool isCorrect = false;
            for (int i = 0; i < vehicleTypes.Length; i++)
            {
                if ((int)vehicleTypes[i] == i_VehicleType)
                {
                    isCorrect = true;
                }
            }

            return isCorrect;
        }

        private CustomerCard getCustomerInfo()
        {
            string inputName, inputPhone;
            Console.WriteLine("Please enter car owner name:");
            inputName = Console.ReadLine();
            Console.WriteLine("Please enter car owner phone number:");
            inputPhone = Console.ReadLine();
           return new CustomerCard(inputName, inputPhone);
        }

        private void printMenu()
        {
            StringBuilder menuMsg = new StringBuilder();
            menuMsg.AppendFormat(@"Select an option from the following options:
1.Add new car to to garage system
2.Show all licanse plate numebr of cars with filters
3.Change repair status for car
4,Pump wheels for vehicle
5.Fill fuel in vehicle
6.Charge electric vehicle
7.Show information about all cars
8.Exit
");
            Console.WriteLine(menuMsg);
        }
    }
}
