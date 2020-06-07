using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private Motorcycle m_Motorcycle;

        public ElectricMotorcycle(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, float i_MaxBatteryLevel) : base(i_ModelName, i_LicensePlateNumber,i_NumOfWheels,i_MaxPressureLevelForWheel, i_MaxBatteryLevel)
        {
            m_Motorcycle = new Motorcycle();
        }

        public new static List<string> GetQuestions()
        {
            List<string> questionsToUserElectricVehicle = ElectricVehicle.GetQuestions();
            List<string> questionsToUserMotorcycle = Motorcycle.getQuestions();
            foreach (string str in questionsToUserMotorcycle)
            {
                questionsToUserElectricVehicle.Add(str);
            }

            return questionsToUserElectricVehicle;
        }

        public new static List<string> GetAtributes()
        {
            List<string> getAtributesFuelVehicle = ElectricVehicle.GetAtributes();
            List<string> getAtributesUserCar = Motorcycle.getAtributes();
            foreach (string str in getAtributesUserCar)
            {
                getAtributesFuelVehicle.Add(str);
            }

            return getAtributesFuelVehicle;
        }

        public override StringBuilder GetAllDetalies()
        {
            StringBuilder detaliesCar = m_Motorcycle.GetAllDetalies();
            StringBuilder detaliesElectricMotorcycle = base.GetAllDetalies();
            detaliesElectricMotorcycle.AppendLine(detaliesCar.ToString());
            return detaliesElectricMotorcycle;
        }

        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            m_Motorcycle.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }

        public Motorcycle Electric
        {
            get
            {
                return m_Motorcycle;
            }

            set
            {
                m_Motorcycle = value;
            }
        }       
    }
}
