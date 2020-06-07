using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using System.Threading;
namespace Ex03.ConsoleUI
{
    public class UI
    {
        private Garage m_Garage;
        public UI()
        {
            m_Garage = new Garage();
            RunUI();
        }
        public void RunUI()
        {
            int input;
            Console.WriteLine("Hello, Welcome to the garage");
            Console.WriteLine("===================================");
            Console.WriteLine("Select an option from the following options:");
            Menu();
            input = GetValidChoise();
            Console.Clear();
            while (input != 8)
            {
                switch (input)
                {
                    case 1:
                        {
                            AddVehicleToGarageMenu();
                            break;
                        }
                    case 2:
                        {
                            ShowVehiclesByLicensePlateNumber();
                            break;
                        }
                    case 3:
                        {
                            ChangeStatOfCarMenu();
                            break;
                        }
                    case 4:
                        {
                            PumpWheelsToMaxMenu();
                            break;
                        }
                    case 5:
                        {
                            FillFuelMenu();
                            break;
                        }
                    case 6:
                        {
                            ChargeEnergyMenu();
                            break;
                        }
                    case 7:
                        {
                            PrintAllVehicles();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("This wasn't a correct choise");
                            break;
                        }
                }
                Console.WriteLine("Select an option from the following options:");
                Menu();
                input = GetValidChoise();
            }
            Console.WriteLine("Have a nice day");
        }
        public void PrintAllVehicles()
        {
            StringBuilder outputMess = m_Garage.GetAllVehicles();
            Console.WriteLine(outputMess);
        }
        public int GetValidChoise()
        {
            int input;
            string inputString = Console.ReadLine();
            while(!int.TryParse(inputString,out input))
            {
                Console.Write("This wasn't correct choise! please pick a digit from the list!");
                inputString = Console.ReadLine();

            }
            return input;
        }
        public void ShowVehiclesByLicensePlateNumber()
        {
            eRepairStatus repairStatus;
            repairStatus = GetValidRepairStatus();
            StringBuilder outputVehicles = m_Garage.GetVehiclesByLicensePlateNumberAndStatus(repairStatus);
            Console.WriteLine(outputVehicles);

        }
        public eRepairStatus GetValidRepairStatus()
        {
            string repairStatusStr;
            int repairStatus;
            Console.WriteLine("Please enter the status of vehicles you want to see:press 0-InRepair, press 1- Fixed, press 2- Paid, press 3- All");
            repairStatusStr = Console.ReadLine();
            while(!int.TryParse(repairStatusStr,out repairStatus)||(repairStatus>4||repairStatus<0))
            {
                Console.WriteLine("Wrong choise!");
                Console.WriteLine("Please enter the status of vehicles you want to see:press 0-InRepair, press 1- Fixed, press 2- Paid, press 3- All");
                repairStatusStr = Console.ReadLine();
            }
            return (eRepairStatus)repairStatus;

        }
        public void ChargeEnergyMenu()
        {
            float amountOfEnergyToFill;
            Vehicle vehicle;
            ElectricVehicle electricVehicleToGet;
            Console.WriteLine("Please enter license plate number for car to add energy to");
            vehicle = GetValidLicensePlateNumberAndGetVehicle();
            while(!m_Garage.IsElectricType(vehicle, out electricVehicleToGet))
            {
                Console.WriteLine("Please enter valid vehicle, this vehicle is not electric");
                vehicle = GetValidLicensePlateNumberAndGetVehicle();
            }
            amountOfEnergyToFill = GetAmountOfEnergyToAdd(electricVehicleToGet);
            m_Garage.ChargeEnergy(electricVehicleToGet, amountOfEnergyToFill);
            Console.WriteLine("The energy was charged! Going back to the main menu");
            Thread.Sleep(1000);
        }

        public float GetAmountOfEnergyToAdd(ElectricVehicle i_vehicle)
        {
            float amountOfEnergyToFill , maxAmountToAdd;
            bool isValid;
            Console.WriteLine("Please enter amount of energy to charge");
            isValid = float.TryParse(Console.ReadLine(), out amountOfEnergyToFill);
            while(!m_Garage.CheckValidEnergyToAdd(i_vehicle,amountOfEnergyToFill, out maxAmountToAdd) || !isValid)
            {
                if(!isValid)
                {
                    Console.WriteLine("Please enter a float number, max float to add is " + maxAmountToAdd);
                    isValid = float.TryParse(Console.ReadLine(), out amountOfEnergyToFill);
                }
                else
                {
                    Console.WriteLine("Please enter a valid eneregy amount to add, min amount is 0 ,max amount possible is " + maxAmountToAdd);
                    isValid = float.TryParse(Console.ReadLine(), out amountOfEnergyToFill);
                }
            }

            return amountOfEnergyToFill;
        }
        public void PumpWheelsToMaxMenu()
        {
            Vehicle vehicle;
            Console.WriteLine("Please enter license plate number for car to pump wheels to max");
            vehicle= GetValidLicensePlateNumberAndGetVehicle();
            m_Garage.FillWheelsOfVehicleToMax(vehicle);
            Console.WriteLine("The wheels was pumped! Going back to the main menu");
            Thread.Sleep(1000);
        }
        public Vehicle GetValidLicensePlateNumberAndGetVehicle()
        {
            string licensePlateNumber = Console.ReadLine();
            Vehicle vehicleToReturn;
            while (!m_Garage.IsCarExists(licensePlateNumber,out vehicleToReturn))
            {
                Console.WriteLine("The car you entered doesn't exist in the garage! please try again");
                licensePlateNumber = Console.ReadLine();
            }
            return vehicleToReturn;

        }
        public void FillFuelMenu()
        {
            float amountOfFuelToAdd;
            Vehicle vehicleToGet;
            FuelVehicle fuelVehicleToGet;
            FuelVehicle.eFuel typeOfFuelToAdd;
            do
            {
                Console.WriteLine("Please enter license plate number for car to add fuel");
                vehicleToGet= GetValidLicensePlateNumberAndGetVehicle();
            }
            while (!m_Garage.IsFuelType(vehicleToGet,out fuelVehicleToGet));
            typeOfFuelToAdd = getFuelFromUser(fuelVehicleToGet);
            amountOfFuelToAdd = GetAmountOfFuelToAdd(fuelVehicleToGet);
            m_Garage.FillFuel(fuelVehicleToGet, typeOfFuelToAdd, amountOfFuelToAdd);
            Console.WriteLine("The fuel was fiiled! Going back to the main menu");
            Thread.Sleep(1000);

        }
        public float GetAmountOfFuelToAdd(FuelVehicle i_FuelVehicleToAdd)
        {
            string amountOfFuelStr;
            float amountOfFuelToAdd, maxAmountToadd;
            bool isSuccseeded;
            Console.WriteLine("Please enter amount of fuel to add");
            amountOfFuelStr = Console.ReadLine();
            isSuccseeded = float.TryParse(amountOfFuelStr, out amountOfFuelToAdd);
            while (!m_Garage.CanAddFuel(amountOfFuelToAdd, i_FuelVehicleToAdd, out maxAmountToadd)||!isSuccseeded)
            {
                Console.WriteLine("Invalid amount, max amount possible to add is" + maxAmountToadd + " please add valid amount");
                amountOfFuelStr = Console.ReadLine();
                isSuccseeded = float.TryParse(amountOfFuelStr, out amountOfFuelToAdd);
            }
            return amountOfFuelToAdd;
        }


        public FuelVehicle.eFuel getFuelFromUser(FuelVehicle i_FuelVehicle)
        {
            string numStr;
            int numOfFuel;
            bool isSuccseeded;
            FuelVehicle.eFuel correctFuelType;
            Console.WriteLine("Please enter type of fuel to add, 0 - soler, 1 - octan95, 2 - octan96, 3 - octan98");
            numStr = Console.ReadLine();
            isSuccseeded = int.TryParse(numStr, out numOfFuel);
            while(!isSuccseeded || !isValidOptionType(numOfFuel) || !m_Garage.IfFuelFits(i_FuelVehicle,(FuelVehicle.eFuel)(numOfFuel),out correctFuelType))
            {
                if (!isSuccseeded || !isValidOptionType(numOfFuel))
                {
                    Console.WriteLine("Wrong Choise! Please enter type of fuel to add, 0 - soler, 1 - octan95, 2 - octan96, 3 - octan98");
                }
                else
                {
                    m_Garage.IfFuelFits(i_FuelVehicle, (FuelVehicle.eFuel)(numOfFuel), out correctFuelType);
                    Console.WriteLine("Wrong Choise! The fuel you enterded doesn't fit the car's fuel, the correct fuel type is: " + correctFuelType);
                }
                numStr = Console.ReadLine();
                isSuccseeded = int.TryParse(numStr, out numOfFuel);
            }
            return (FuelVehicle.eFuel)(numOfFuel);
        }

        public bool isValidOptionType(int i_Num)
        {
            return (i_Num == 0 || i_Num == 1 || i_Num == 2 || i_Num == 3);
        }
        public void ChangeStatOfCarMenu()
        {
            Vehicle vehicleToGet;
            eRepairStatus repairStatus;
            StringBuilder outputMess = new StringBuilder();
            Console.WriteLine("Please enter the license plate number of the vehicle you want to change the status to");
            vehicleToGet = GetValidLicensePlateNumberAndGetVehicle();
            outputMess.Append("What is the new status of the vehicle");
            outputMess.Append("? enter 0- in repair, 1- fixed, 2- was paid");
            Console.WriteLine(outputMess);
            repairStatus = GetValidRepairStstus();
            m_Garage.ChangeStatusOfCar(vehicleToGet, repairStatus);
        }

        public eRepairStatus GetValidRepairStstus()
        {
            int repairStatus;
            string repairStatusStr = Console.ReadLine();
            while(!int.TryParse(repairStatusStr,out repairStatus)|| !isValidOptionType(repairStatus))
            {
                Console.WriteLine("Invalid choise. please enter digit 0- in repair, 1- fixed, 2- was paid");
            }
            return (eRepairStatus)repairStatus;
        }
        public void AddVehicleToGarageMenu()
        {
            Vehicle vehicleToAddGarage, vehicleExists;
            CustomerInfo customerInfo;
            Console.WriteLine("Please enter the license plate number");
            string licensePlateNumber = Console.ReadLine();
            if (!m_Garage.IsVehicleExistsInGarage(licensePlateNumber, out vehicleExists))
            {
                vehicleToAddGarage = GetVehicle(licensePlateNumber);
                customerInfo = GetCustomerInfo();
                m_Garage.AddVehicleToGarage(vehicleToAddGarage, customerInfo);
                Console.WriteLine("The vehicle was added successfully to the garage system");
            }
            else
            {
                m_Garage.ChangeStatusOfCar(vehicleExists, eRepairStatus.InRepair);
                Console.WriteLine("The car is already in the system, status was changed to InRepair");
            }
        }

        public Vehicle GetVehicle(string i_LicensePlateNumber)
        {
            Vehicle vehicleToAddToGarage;
            CreateNewObjForGarage.eVehicle vehicleType;
            List<string> listOfQuestions, listOfAttributesToGet;
            string model;
            Console.WriteLine("Please enter the vehicle you want to add:");
            PrintSupportedTypes();
            vehicleType = GetValidVehicleType();
            Console.WriteLine("Please enter the model of the vehicle");
            model = Console.ReadLine();
            vehicleToAddToGarage = CreateNewObjForGarage.MakeNewVehicle(vehicleType, model, i_LicensePlateNumber, out listOfQuestions, out listOfAttributesToGet);
            GetAndSetInputAccordingToQuestions(vehicleToAddToGarage, listOfQuestions, listOfAttributesToGet);
            return vehicleToAddToGarage;
        }

        public void GetAndSetInputAccordingToQuestions(Vehicle i_Vehicle, List <string> i_ListOfQuestions, List<string> i_ListOfAttributesToGet)
        {
            string input;
            for (int i = 0; i < i_ListOfQuestions.Count; i++)
            {
                try
                {
                    Console.WriteLine(i_ListOfQuestions[i]);
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
        public void PrintSupportedTypes()
        {
            StringBuilder outputMess = new StringBuilder();
            CreateNewObjForGarage.eVehicle[] vehicleTypes = CreateNewObjForGarage.GetSupportedTypes();
            for (int i = 0; i < vehicleTypes.Length; i++)
            {
                outputMess.Append("for "+ vehicleTypes[i]);
                outputMess.AppendLine(" press " + (int)vehicleTypes[i]+" ");
            }
            Console.WriteLine(outputMess);
        }

        public CreateNewObjForGarage.eVehicle GetValidVehicleType()
        {
            CreateNewObjForGarage.eVehicle[] vehicleTypes = CreateNewObjForGarage.GetSupportedTypes();
            string vehicleTypeStr = Console.ReadLine();
            int vehicleType;
            while(!int.TryParse(vehicleTypeStr, out vehicleType)||!IsCorrectTypeOfVehicle(vehicleType))
            {
                Console.WriteLine("Please enter a digit from the options");
                vehicleTypeStr = Console.ReadLine();
            }
            return (CreateNewObjForGarage.eVehicle)vehicleType;
        }
        public bool IsCorrectTypeOfVehicle(int i_VehicleType)
        {
            CreateNewObjForGarage.eVehicle[] vehicleTypes = CreateNewObjForGarage.GetSupportedTypes();
            bool isCorrect = false;
            for (int i = 0; i < vehicleTypes.Length; i++)
            {
                if ((int)vehicleTypes[i] == i_VehicleType)
                    isCorrect = true;
            }
            return isCorrect;
        }
        public CustomerInfo GetCustomerInfo()
        {
            string inputName, inputPhone;
            Console.WriteLine("Please enter car owner name:");
            inputName = Console.ReadLine();
            Console.WriteLine("Please enter car owner phone number:");
            inputPhone = Console.ReadLine();
           return new CustomerInfo(inputName, inputPhone);
        }

        public void Menu()
        {
            StringBuilder menuMsg = new StringBuilder();
            menuMsg.AppendFormat(@"1.Add new car to to garage system
2.Show all licanse plate numebr of cars with filters
3.Change repair status for car
4,Pump wheels for vehicle
5.Fill fuel in vehicle
6.Charge electric vehicle
7.Show information about car
8.Exit
");

            Console.WriteLine(menuMsg);
        }
    }
}
