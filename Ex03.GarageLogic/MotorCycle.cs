using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle
    {
        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public static List<string> getQuestions()
        {
            List<string> questionsToUser = new List<string>();
            questionsToUser.Add("Please enter license type for the motorcycle:press 0 for A,press 1 for A1,press 2 for A4 Or press 3 for B");
            questionsToUser.Add("Please enter engine volume for the motorcycle");
            return questionsToUser;
        }

        public static List<string> getAtributes()
        {
            List<string> getAtributes = new List<string>();
            getAtributes.Add("LicenseType");
            getAtributes.Add("EngineVolume");
            return getAtributes;
        }

        public StringBuilder GetAllDetalies()
        {
            StringBuilder detalies = new StringBuilder();
            detalies.AppendLine("License Type: " + LicenseType.ToString());
            detalies.Append("Engine Volume: " + m_EngineVolume.ToString());
            return detalies;
        }

        public void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            int licenseType;
            if (i_WhichAttributeToSet == "LicenseType")
            {
                licenseType = int.Parse(i_InputFromUser);// exeption
                if (4 < licenseType || licenseType < 0)
                {
                    throw new ValueOutOfRangeException(0, 3);
                }
                LicenseType = (eLicenseType)licenseType;
            }

            if (i_WhichAttributeToSet == "EngineVolume")
            {
                EngineVolume = int.Parse(i_InputFromUser);
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }           
    }
}
