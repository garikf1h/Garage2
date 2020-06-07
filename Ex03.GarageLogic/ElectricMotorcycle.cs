using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private Motorcycle m_Motorcycle;

        public ElectricMotorcycle(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, float i_MaxBatteryTimeInHours) : base(i_ModelName, i_LicensePlateNumber, i_NumOfWheels, i_MaxPressureLevelForWheel, i_MaxBatteryTimeInHours)
        {
            m_Motorcycle = new Motorcycle();
        }

        public static new List<string> GetQuestions()
        {
            List<string> questionsToUserElectricVehicle = ElectricVehicle.GetQuestions();
            List<string> questionsToUserMotorcycle = Motorcycle.GetQuestions();
            foreach (string str in questionsToUserMotorcycle)
            {
                questionsToUserElectricVehicle.Add(str);
            }

            return questionsToUserElectricVehicle;
        }

        public static new List<string> GetAtributes()
        {
            List<string> getAtributesFuelVehicle = ElectricVehicle.GetAtributes();
            List<string> getAtributesUserCar = Motorcycle.GetAtributes();
            foreach (string str in getAtributesUserCar)
            {
                getAtributesFuelVehicle.Add(str);
            }

            return getAtributesFuelVehicle;
        }

        public override string GetAllDetalies()
        {
            return "Vehicle type: Electric Motorcycle \n" + base.GetAllDetalies() + m_Motorcycle.GetAllDetalies();
        }
        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            m_Motorcycle.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }
    }
}
