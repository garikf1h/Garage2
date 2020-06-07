using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : FuelVehicle
    {
        private Motorcycle m_Motorcycle;

        public FuelMotorcycle(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, FuelVehicle.eFuel i_FuelType, float i_MaxAmountOfFuel) : base(i_ModelName, i_LicensePlateNumber, i_NumOfWheels, i_MaxPressureLevelForWheel, i_MaxAmountOfFuel, i_FuelType)
        {
            m_Motorcycle = new Motorcycle();
        }

        public static new List<string> GetQuestions()
        {
            List<string> questionsToUserFuelVehicle = FuelVehicle.GetQuestions();
            List<string> questionsToUserCar = Motorcycle.GetQuestions();
            foreach (string str in questionsToUserCar)
            {
                questionsToUserFuelVehicle.Add(str);
            }

            return questionsToUserFuelVehicle;
        }

        public static new List<string> GetAtributes()
        {
            List<string> getAtributesFuelVehicle = FuelVehicle.GetAtributes();
            List<string> getAtributesUserCar = Motorcycle.GetAtributes();
            foreach (string str in getAtributesUserCar)
            {
                getAtributesFuelVehicle.Add(str);
            }

            return getAtributesFuelVehicle;
        }

        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            m_Motorcycle.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }

        public override string GetAllDetalies()
        {
            return "Vehicle type: Fuel Motorcycle \n" + base.GetAllDetalies() + m_Motorcycle.GetAllDetalies();
        }
    }
}
