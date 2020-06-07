using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelMotorcycle : FuelVehicle
    {
        private Motorcycle m_Motorcycle;

        public FuelMotorcycle(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, FuelVehicle.eFuel i_FuelType, float i_MaxAmountOfFuel) : base(i_ModelName, i_LicensePlateNumber, i_NumOfWheels, i_MaxPressureLevelForWheel, i_MaxAmountOfFuel, i_FuelType)
        {
            m_Motorcycle = new Motorcycle();
        }

        public new static List<string> GetQuestions()
        {
            List<string> questionsToUserFuelVehicle = FuelVehicle.GetQuestions();
            List<string> questionsToUserCar = Motorcycle.getQuestions();
            foreach (string str in questionsToUserCar)
            {
                questionsToUserFuelVehicle.Add(str);
            }

            return questionsToUserFuelVehicle;
        }

        public new static List<string> GetAtributes()
        {
            List<string> getAtributesFuelVehicle = FuelVehicle.GetAtributes();
            List<string> getAtributesUserCar = Motorcycle.getAtributes();
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

        public override StringBuilder GetAllDetalies()
        {
            StringBuilder detaliesCar = Motorcycle.GetAllDetalies();
            StringBuilder detaliesFuelMotorcycle = base.GetAllDetalies();
            detaliesFuelMotorcycle.AppendLine(detaliesCar.ToString());

            return detaliesFuelMotorcycle;
        }

        public Motorcycle Motorcycle
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
