using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{   
   public abstract class FuelVehicle : Vehicle
    {
        protected readonly float r_MaxAmountOfFuel;
        protected readonly eFuel r_Fuel;
        protected float m_CurrAmountOfFuel;

        public enum eFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public FuelVehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, float i_MaxAmountOfFuel, eFuel i_Fuel) : base(i_ModelName, i_LicensePlateNumber, i_NumOfWheels, i_MaxPressureLevelForWheel)
        {
            r_MaxAmountOfFuel = i_MaxAmountOfFuel;
            r_Fuel = i_Fuel;
        }

        protected static new List<string> GetQuestions()
        {
            List<string> questionsToUser = Vehicle.GetQuestions();
            questionsToUser.Add("Please enter current amount of fuel ");
            return questionsToUser;
        }

        protected static new List<string> GetAtributes()
        {
            List<string> getAtributes = Vehicle.GetAtributes();
            getAtributes.Add("CurrAmountOfFuel");
            return getAtributes;
        }

        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            float currAmountOfFuel;
            if(i_WhichAttributeToSet == "CurrAmountOfFuel")
            {
                currAmountOfFuel = float.Parse(i_InputFromUser);
                CurrAmountOfFuel = currAmountOfFuel;
            }

            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }

        public eFuel Fuel
        {
            get
            {
                return r_Fuel;
            }
        }

        public float CurrAmountOfFuel
        {
            get
            {
                return m_CurrAmountOfFuel;
            }

            set
            {
                if (value > r_MaxAmountOfFuel || value < 0)
                {
                    throw new ValueOutOfRangeException(0, r_MaxAmountOfFuel);
                }

                m_CurrAmountOfFuel = value;
                LeftPercentageOfEnergy = (CurrAmountOfFuel / r_MaxAmountOfFuel) * 100;
            }
        }

        public float MaxAmountOfFuel
        {
            get
            {
                return r_MaxAmountOfFuel;
            }
        }

        public override string GetAllDetalies()
        {
            return base.GetAllDetalies() + string.Format(@"
Type of fuel:{0}
Current amount of fuel:{1}",
Fuel.ToString(), CurrAmountOfFuel);
        }            

        internal bool CheckAddFuel(float i_AmountOfFuelToAdd, out float o_MaxAmountPossibleToAdd)
        {
           o_MaxAmountPossibleToAdd = r_MaxAmountOfFuel - m_CurrAmountOfFuel;
           return i_AmountOfFuelToAdd + m_CurrAmountOfFuel <= r_MaxAmountOfFuel && i_AmountOfFuelToAdd >= 0;
        }

        internal void FillFuel(eFuel i_FuelToFill, float i_HowMuchToFill)
        {
            float maxAmountPossibleToAdd;
            if (i_FuelToFill != r_Fuel)
            {
                throw new ArgumentException("The fuel you entered doesn't fit the vehicle fuel type");
            }

            if (!CheckAddFuel(i_HowMuchToFill, out maxAmountPossibleToAdd))
            {
                throw new ValueOutOfRangeException(0, maxAmountPossibleToAdd);
            }

            CurrAmountOfFuel += i_HowMuchToFill;
        }
    }
}
