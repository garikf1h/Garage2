using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private readonly float r_MaxBatteryTimeInHours;
        private float m_LeftBatteryTimeInHours;

        public ElectricVehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, float i_MaxBatteryTimeInHours) : base(i_ModelName, i_LicensePlateNumber, i_NumOfWheels, i_MaxPressureLevelForWheel)
        {
            r_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
        }

        protected static new List<string> GetQuestions()
        {
            List<string> questionsToUser = Vehicle.GetQuestions();
            questionsToUser.Add("Please enter left battery time: ");
            return questionsToUser;
        }

        protected static new List<string> GetAtributes()
        {
            List<string> getAtributes = Vehicle.GetAtributes();
            getAtributes.Add("LeftTimeBattery");
            return getAtributes;
        }

        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            float leftTimeBattery;
            if (i_WhichAttributeToSet == "LeftTimeBattery")
            {
                leftTimeBattery = float.Parse(i_InputFromUser); ////exeption
                LeftBatteryTimeInHours = leftTimeBattery;
            }

            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }

        public bool CheckAddEnergyIsValid(float i_EnergyToAdd, out float o_MaxAmountToAdd)
        {
            o_MaxAmountToAdd = r_MaxBatteryTimeInHours - m_LeftBatteryTimeInHours;
            return m_LeftBatteryTimeInHours + i_EnergyToAdd <= r_MaxBatteryTimeInHours && i_EnergyToAdd >= 0;
        }

        public override string GetAllDetalies()
        {
            return base.GetAllDetalies() + string.Format(@"
Left time battery:{0}", m_LeftBatteryTimeInHours.ToString());
        }

        public float LeftBatteryTimeInHours
        {
            get
            {
                return m_LeftBatteryTimeInHours;               
            }

            set
            {
                if (r_MaxBatteryTimeInHours < value || value < 0)
                {
                    throw new ValueOutOfRangeException(0, r_MaxBatteryTimeInHours);
                }
                m_LeftBatteryTimeInHours = value;
                LeftPercentageOfEnergy = (LeftBatteryTimeInHours / r_MaxBatteryTimeInHours) * 100;
            }
        }

        public float MaxBatteryTimeInHours
        {
            get
            {
                return r_MaxBatteryTimeInHours;
            }
        }
        
        public bool ChargeEnergy(float i_EnergyToAdd)
        {
            bool isProccessSuccsseeded = false;
            if(i_EnergyToAdd + m_LeftBatteryTimeInHours <= r_MaxBatteryTimeInHours)
            {
                LeftBatteryTimeInHours += i_EnergyToAdd;
                isProccessSuccsseeded = true;
            }

            return isProccessSuccsseeded;
        }
    }
}
