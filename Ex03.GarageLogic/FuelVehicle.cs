using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{   
   public class FuelVehicle : Vehicle
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

        protected new static List<string> GetQuestions()
        {
            List<string> questionsToUser = Vehicle.GetQuestions();
            questionsToUser.Add("Please enter current amount of fuel: ");
            return questionsToUser;
        }

        protected new static List<string> GetAtributes()
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
                currAmountOfFuel = float.Parse(i_InputFromUser); ////exeption
                if(r_MaxAmountOfFuel < currAmountOfFuel || currAmountOfFuel < 0)
                {
                    throw new ValueOutOfRangeException(0, r_MaxAmountOfFuel);
                }

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
                m_CurrAmountOfFuel = value;
            }
        }

        public float MaxAmountOfFuel
        {
            get
            {
                return r_MaxAmountOfFuel;
            }
        }

        public override StringBuilder GetAllDetalies()
        {
            StringBuilder detalies = base.GetAllDetalies();
            detalies.AppendLine("Type of fuel: " + Fuel.ToString());
            detalies.AppendLine("Current amount of fuel: " + CurrAmountOfFuel);            
            return detalies;
        }            

        public bool CheckAddFuel(float i_AmountOfFuelToAdd, out float o_MaxAmountPossibleToAdd)
        {
           o_MaxAmountPossibleToAdd = r_MaxAmountOfFuel - m_CurrAmountOfFuel;
           return i_AmountOfFuelToAdd + m_CurrAmountOfFuel <= r_MaxAmountOfFuel && i_AmountOfFuelToAdd >= 0;
        }

        public bool FillFuel(eFuel i_FuelToFill, float i_HowMuchToFill)
        {
            bool isSuccseeded = false;
            if(i_FuelToFill == r_Fuel && i_HowMuchToFill + m_CurrAmountOfFuel <= r_MaxAmountOfFuel)
            {
                m_CurrAmountOfFuel += i_HowMuchToFill;
                isSuccseeded = true;
            }

            return isSuccseeded;
        }
    }
}
