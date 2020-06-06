﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreateNewObjForGarage
    {
        
        public enum eVehicle
        {
            FuelCar,
            FuelMotorcycle,
            ElectricCar,
            ElectricMotorcycle,
            Truck
        }
        private static eVehicle[] s_SupportedTypes = { eVehicle.FuelCar, eVehicle.FuelMotorcycle, eVehicle.ElectricCar, eVehicle.ElectricMotorcycle, eVehicle.Truck };
        public static eVehicle[] GetSupportedTypes()
        {
            return s_SupportedTypes;
        }
       public static Vehicle MakeNewVehicle(eVehicle TypeToCreate, string i_ModelName, string i_LicensePlateNumber, out List<string> o_QuestionsToAsk, out List<string> o_Attributes)
       {
            switch (TypeToCreate)
            {     
                case eVehicle.ElectricCar:
                    {
                        o_QuestionsToAsk = ElectricCar.getQuestions();
                        o_Attributes = ElectricCar.getAtributes();
                        return new ElectricCar(i_ModelName, i_LicensePlateNumber, 4, 32, 2.1f);
                    }
                case eVehicle.FuelCar:
                    {
                        o_QuestionsToAsk = FuelCar.getQuestions();
                        o_Attributes = FuelCar.getAtributes();
                        return new FuelCar(i_ModelName, i_LicensePlateNumber, 4, 32, FuelVehicle.eFuel.Octan96, 60);
                    }
                case eVehicle.ElectricMotorcycle:
                    {
                        o_QuestionsToAsk = ElectricMotorcycle.getQuestions();
                        o_Attributes = ElectricMotorcycle.getAtributes();
                        return new ElectricMotorcycle(i_ModelName, i_LicensePlateNumber,2, 30, 1.2f);
                    }
                case eVehicle.FuelMotorcycle:
                    {
                        o_QuestionsToAsk = FuelMotorcycle.getQuestions();
                        o_Attributes = FuelMotorcycle.getAtributes();

                        return new FuelMotorcycle(i_ModelName, i_LicensePlateNumber, 2, 30, FuelVehicle.eFuel.Octan95, 7);
                    }
                case eVehicle.Truck:
                    {
                        o_QuestionsToAsk = Truck.getQuestions();
                        o_Attributes = Truck.getAtributes();
                        return new Truck(i_ModelName, i_LicensePlateNumber, 16, 28, FuelVehicle.eFuel.Soler, 120);
                    }
                 default:
                    {
                        o_QuestionsToAsk = null;
                        o_Attributes = null;
                        return null;
                    }
            }
       }
    
    }
}