﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, CustomerCard> m_ContactInfoDictionary;
        private Dictionary<string, Vehicle> m_Vehicles;

        public Garage()
        {
            m_ContactInfoDictionary = new Dictionary<string, CustomerCard>();
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        public void AddVehicleToGarage(Vehicle i_VehicleToAdd, CustomerCard i_ContactInfo)
        {
            m_Vehicles.Add(i_VehicleToAdd.LicencsePlateNumber, i_VehicleToAdd);
            m_ContactInfoDictionary.Add(i_VehicleToAdd.LicencsePlateNumber, i_ContactInfo);
        }

        public bool CheckValidEnergyToAdd(ElectricVehicle i_VehicleToAdd, float i_EnergyToAdd, out float o_MaxAmountToAdd)
        {
            return i_VehicleToAdd.CheckAddEnergyIsValid(i_EnergyToAdd, out o_MaxAmountToAdd);
        }

        public void ChangeStatusOfCar(Vehicle i_VehicleToChangeStatus, eRepairStatus i_NewRepairStatus)
        {
            CustomerCard customerToGet;
            if (m_ContactInfoDictionary.TryGetValue(i_VehicleToChangeStatus.LicencsePlateNumber, out customerToGet))
            {
                customerToGet.CarRepairStatus = i_NewRepairStatus;
            }
        }

        public void FillWheelsOfVehicleToMax(Vehicle i_Vehicle)
        {
           i_Vehicle.PumpAllWheels();
        }

        public void FillFuel(FuelVehicle i_FuelVehicle, FuelVehicle.eFuel i_Fuel, float i_HowMuchToFill)
        {
            i_FuelVehicle.FillFuel(i_Fuel, i_HowMuchToFill);
        }

        public StringBuilder GetVehiclesByLicensePlateNumberAndStatus(eRepairStatus i_RepairStatus, out bool o_IsEmptyList)
        {
            StringBuilder outputString = new StringBuilder();
            int index = 1;
            bool withoutStatus;
            o_IsEmptyList = true;
            if (i_RepairStatus == (eRepairStatus)3)
            {
                withoutStatus = true;
            }
            else
            {
                withoutStatus = false;
            }

            foreach(KeyValuePair<string, CustomerCard> keyValuePair in m_ContactInfoDictionary)
            {
                if (keyValuePair.Value.CarRepairStatus == i_RepairStatus || withoutStatus)
                {
                    o_IsEmptyList = false;
                    outputString.Append("Car No: " + index.ToString());
                    outputString.Append(", License plate number:" + keyValuePair.Key.ToString());
                    outputString.AppendLine(", Status:" + keyValuePair.Value.CarRepairStatus.ToString());
                    index++;
                }
            }

            return outputString;
        }

        public bool CanAddFuel(float i_AmountOfFuelToAdd, FuelVehicle i_FuelVehicle, out float o_MaxAmountPossibleToAdd)
        {
            return i_FuelVehicle.CheckAddFuel(i_AmountOfFuelToAdd, out o_MaxAmountPossibleToAdd);
        }

        public bool IsElectricType(Vehicle i_Vehicle, out ElectricVehicle o_ElectricVehicleToReturn)
        {
            o_ElectricVehicleToReturn = i_Vehicle as ElectricVehicle;
            return i_Vehicle is ElectricVehicle;
        }

        public bool IfFuelFits(FuelVehicle i_FuelVehicle, FuelVehicle.eFuel i_Fuel, out FuelVehicle.eFuel o_CorrectFuelType)
        {
            o_CorrectFuelType = i_FuelVehicle.Fuel;
            return i_FuelVehicle.Fuel == i_Fuel;
        }

        public bool IsCarExists(string i_LicensePlateNumber, out Vehicle o_Vehicle)
        {
            return m_Vehicles.TryGetValue(i_LicensePlateNumber, out o_Vehicle);
        }

        public bool IsFuelType(Vehicle i_Vehicle, out FuelVehicle o_FuelVehicleToReturn)
        {
            o_FuelVehicleToReturn = i_Vehicle as FuelVehicle;
            return i_Vehicle is FuelVehicle;
        }

        public bool IsFuelFit(FuelVehicle.eFuel i_Fuel, Vehicle i_Vehicle)
        {
            FuelVehicle fuelVehicle = i_Vehicle as FuelVehicle;
            return fuelVehicle.Fuel == i_Fuel;
        }

        public bool IsVehicleExistsInGarage(string i_LicensePlateNumber, out Vehicle o_VehicleInGarage)
        {
           return m_Vehicles.TryGetValue(i_LicensePlateNumber, out o_VehicleInGarage);
        }

        public StringBuilder GetAllVehicles(out bool o_IsListEmpty)
        {
            StringBuilder outputAllVehicles = new StringBuilder();
            CustomerCard customerInfo;
            int i = 1;
            o_IsListEmpty = true;
            foreach (KeyValuePair<string, Vehicle> keyValuePair in m_Vehicles)
            {
                o_IsListEmpty = false;
                outputAllVehicles.AppendLine("Car No:" + i);
                outputAllVehicles.AppendLine("===============================");
                outputAllVehicles.AppendLine(keyValuePair.Value.GetAllDetalies());
                m_ContactInfoDictionary.TryGetValue(keyValuePair.Key, out customerInfo);
                outputAllVehicles.AppendLine(customerInfo.GetDetalies().ToString());
                i++;
            }

            return outputAllVehicles;
        }

        public void ChargeEnergy(ElectricVehicle i_VehicleToAddEnregy, float i_MinutesToCharge)
        {
            i_VehicleToAddEnregy.ChargeEnergy(i_MinutesToCharge);
        }
    }
}
