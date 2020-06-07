using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle
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

        public static List<string> GetQuestions()
        {
            List<string> questionsToUser = new List<string>();
            questionsToUser.Add("Please enter license type for the motorcycle:press 0 for A,press 1 for A1,press 2 for A4 Or press 3 for B");
            questionsToUser.Add("Please enter engine volume for the motorcycle");
            return questionsToUser;
        }

        public static List<string> GetAtributes()
        {
            List<string> getAtributes = new List<string>();
            getAtributes.Add("LicenseType");
            getAtributes.Add("EngineVolume");
            return getAtributes;
        }

        public string GetAllDetalies()
        {
            return string.Format(@"
License Type:{0}
Engine Volume:{1}", LicenseType.ToString(), m_EngineVolume.ToString());
        }

        public void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            int licenseType;
            if (i_WhichAttributeToSet == "LicenseType")
            {
                licenseType = int.Parse(i_InputFromUser); //// exeption
                if(licenseType > 4 || licenseType < 0)
                {
                    throw new ValueOutOfRangeException(0, 3);
                }

                m_LicenseType = (eLicenseType)licenseType;
            }

            if (i_WhichAttributeToSet == "EngineVolume")
            {
                m_EngineVolume = int.Parse(i_InputFromUser);
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }           
    }
}
