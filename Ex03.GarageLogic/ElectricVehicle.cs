using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_LeftTimeBattery;
        private readonly float r_MaxTimeBattery;

        public ElectricVehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, float i_MaxBatteryLevel): base(i_ModelName, i_LicensePlateNumber,i_NumOfWheels, i_MaxPressureLevelForWheel)
        {
            r_MaxTimeBattery = i_MaxBatteryLevel;
        }

        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            float leftTimeBattery;
            if (i_WhichAttributeToSet == "LeftTimeBattery")
            {
                leftTimeBattery = float.Parse(i_InputFromUser);//exeption
                if (r_MaxTimeBattery < leftTimeBattery || leftTimeBattery < 0)
                {
                    throw new ValueOutOfRangeException(0, r_MaxTimeBattery);
                }
                LeftTimeBattery = leftTimeBattery;
            }
            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);

        }

        public bool CheckAddEnergyIsValid(float i_EnergyToAdd, out float o_MaxAmountToAdd)
        {
            o_MaxAmountToAdd = r_MaxTimeBattery - m_LeftTimeBattery;
            return m_LeftTimeBattery + i_EnergyToAdd <= r_MaxTimeBattery && i_EnergyToAdd >= 0;
        }
        public override StringBuilder GetAllDetalies()
        {
            StringBuilder detalies = base.GetAllDetalies();
            detalies.AppendLine("Left time battery:" + m_LeftTimeBattery.ToString());

            return detalies;
        }

        public float LeftTimeBattery
        {
            get
            {
                return m_LeftTimeBattery;               
            }
            set
            {
                m_LeftTimeBattery = value;
            }
        }

        public float MaxTimeBattery
        {
            get
            {
                return r_MaxTimeBattery;
            }

        }
        protected new static List<string> getQuestions()
        {
            List<string> questionsToUser = Vehicle.getQuestions();
            questionsToUser.Add("Please enter left battery time: ");

            return questionsToUser;
        }

        protected new static List<string> getAtributes()
        {
            List<string> getAtributes = Vehicle.getAtributes();
            getAtributes.Add("LeftTimeBattery");
            return getAtributes;
        }

        public bool Charge(float i_EnergyToAdd)
        {
            bool isProccessSuccsseeded = false;
            if(i_EnergyToAdd+m_LeftTimeBattery<=r_MaxTimeBattery)
            {
                m_LeftTimeBattery += i_EnergyToAdd;
                isProccessSuccsseeded = true;
            }
            return isProccessSuccsseeded;
        }
    }
}
