﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : FuelVehicle
    {
        private Car m_Car;
        private bool m_isCarryDangerousMaterial;
        private float m_CarryVolume;
        private const float k_MaxPressureOfWheel = 28;

        public Truck(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, FuelVehicle.eFuel i_FuelType, float i_MaxAmountOfFuel) : base(i_ModelName, i_LicensePlateNumber,i_NumOfWheels,i_MaxPressureLevelForWheel, i_MaxAmountOfFuel,i_FuelType)
        {
            m_Car = new Car();
        }

        public override StringBuilder GetAllDetalies()
        {
            StringBuilder detaliesCar = Car.GetAllDetalies();
            StringBuilder detaliesFuelCar = base.GetAllDetalies();
            detaliesFuelCar.AppendLine(detaliesCar.ToString());
            detaliesFuelCar.AppendLine("Truck carry volume is: " + m_CarryVolume.ToString());
            detaliesFuelCar.AppendLine(" Is carry dangerous material: " + m_isCarryDangerousMaterial.ToString());
            return detaliesFuelCar;
        }
        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            if(i_WhichAttributeToSet == "CarryVolume")
            {
                CarryVolume = float.Parse(i_InputFromUser);
            }

            if (i_WhichAttributeToSet == "IsCarryDangerousMaterial")
            {
                IsCarryDangerousMaterial = bool.Parse(i_InputFromUser);
            }
            m_Car.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }

        public new static List<string> getQuestions()
        {
            List<string> questionsToUserFuelVehicle = FuelVehicle.getQuestions();
            List<string> questionsToUserCar = Car.GetQuestions();
            foreach (string str in questionsToUserCar)
            {
                questionsToUserFuelVehicle.Add(str);
            }
            questionsToUserFuelVehicle.Add("Please enter true if the truck carry dangerous material, or false if doesn't");
            questionsToUserFuelVehicle.Add("Please enter the carry volume of the car");
            return questionsToUserFuelVehicle;
        }

        public new static List<string> getAtributes()
        {
            List<string> atributesFuelVehicle = FuelVehicle.getAtributes();
            List<string> atributesToUserCar = Car.GetAtributes();
            foreach (string str in atributesToUserCar)
            {
                atributesFuelVehicle.Add(str);
            }
            atributesFuelVehicle.Add("IsCarryDangerousMaterial");
            atributesFuelVehicle.Add("CarryVolume");
            return atributesFuelVehicle;
        }
        public float CarryVolume
        {
            get
            {
                return m_CarryVolume;            
            }
            set
            {
                m_CarryVolume = value;
            }
        }

        public Car Car
        {
            get
            {
                return m_Car;
            }
            set
            {
                m_Car = value;
            }
        }

        public bool IsCarryDangerousMaterial
        {
            get
            {
                return m_isCarryDangerousMaterial;
            }
            set
            {
                m_isCarryDangerousMaterial = value;
            }
        }
    }
}