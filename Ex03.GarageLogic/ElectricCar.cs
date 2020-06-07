using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private Car m_Car;

        public static new List<string> GetQuestions()
        {
            List<string> questionsToUserElectricVehicle = ElectricVehicle.GetQuestions();
            List<string> questionsToUserCar = Car.GetQuestions();
            foreach (string str in questionsToUserCar)
            {
                questionsToUserElectricVehicle.Add(str);
            }

            return questionsToUserElectricVehicle;
        }

        public static new List<string> GetAtributes()
        {
            List<string> getAtributesFuelVehicle = ElectricVehicle.GetAtributes();
            List<string> getAtributesUserCar = Car.GetAtributes();
            foreach (string str in getAtributesUserCar)
            {
                getAtributesFuelVehicle.Add(str);
            }

            return getAtributesFuelVehicle;
        }

        public ElectricCar(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, float i_MaxBatteryTimeInHours) : base(i_ModelName, i_LicensePlateNumber, i_NumOfWheels, i_MaxPressureLevelForWheel, i_MaxBatteryTimeInHours)
        {
            m_Car = new Car();
        }

        public override string GetAllDetalies()
        {
            return "Vehicle type: Electric Car \n" + base.GetAllDetalies() + m_Car.GetAllDetalies();
        }
        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            m_Car.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }
    }
}
