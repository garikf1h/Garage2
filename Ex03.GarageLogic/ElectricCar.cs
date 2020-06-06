using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricCar : ElectricVehicle
    {
        private Car m_Car;
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

        public ElectricCar(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels,float i_MaxPressureLevelForWheel, float i_MaxBatteryLevel) : base(i_ModelName, i_LicensePlateNumber,i_NumOfWheels,i_MaxPressureLevelForWheel, i_MaxBatteryLevel)
        {
            m_Car = new Car();
        }
        public override StringBuilder GetAllDetalies()
        {
            StringBuilder detaliesCar = Car.GetAllDetalies();
            StringBuilder detaliesElectricCar = base.GetAllDetalies();
            detaliesElectricCar.AppendLine(detaliesCar.ToString());
            

            return detaliesElectricCar;
        }

        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            m_Car.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }

        public new static List<string> getQuestions()
        {
            List<string> questionsToUserElectricVehicle = ElectricVehicle.getQuestions();
            List<string> questionsToUserCar = Car.GetQuestions();
            foreach (string str in questionsToUserCar)
            {
                questionsToUserElectricVehicle.Add(str);
            }
            return questionsToUserElectricVehicle;
        }

        public new static List<string> getAtributes()
        {
            List<string> getAtributesFuelVehicle = ElectricVehicle.getAtributes();
            List<string> getAtributesUserCar = Car.GetAtributes();
            foreach (string str in getAtributesUserCar)
            {
                getAtributesFuelVehicle.Add(str);
            }
            return getAtributesFuelVehicle;
        }
        private float getLeftTimeBatteryFromDictionary(string i_LeftTimeBattery)
        {
            bool valid;
            float LeftTimeBattery;       
            valid = float.TryParse(i_LeftTimeBattery, out LeftTimeBattery);
            return LeftTimeBattery;
        }

        private Car.eCarColor getColorFromDictionary(string i_Color)
        {
            bool valid;
            int color;
            valid = int.TryParse(i_Color, out color);
            return (Car.eCarColor)color;
        }

        private Car.eNumbersOfDoors getNumOfDoorsFromDictionary(string i_NumOfDoorsString)
        {
            bool valid;
            int numOfDoors;
            valid = int.TryParse(i_NumOfDoorsString, out numOfDoors);
            return (Car.eNumbersOfDoors)numOfDoors;
        }
    }
}
