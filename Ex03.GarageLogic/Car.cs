using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car
    {
        public enum eCarColor
        {
            Red,
            White,
            Black,
            Silver
        }
        public enum eNumbersOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five,
        }

        private eCarColor m_Color;
        private eNumbersOfDoors m_NumOfDoors;

        public static List<string> GetQuestions()
        {
            List<string> questionsToUser = new List<string>();
            questionsToUser.Add("Please enter color of the vehicle: enter 0 digit for Red, enter 1 digit for White, enter 2 digit for Black, enter 3 digit for Silver");
            questionsToUser.Add("Please enter how many doors in the vehicle(enter 2-5):Two, Three, Four, Five");
            return questionsToUser;
        }

        public static List<string> GetAtributes()
        {
            List<string> getAtributes = new List<string>();
            getAtributes.Add("Color");
            getAtributes.Add("NumOfDoors");
            return getAtributes;
        }

        public eCarColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public eNumbersOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                m_NumOfDoors = value;
            }
        }

        public  StringBuilder GetAllDetalies()
        {
            StringBuilder detalies = new StringBuilder();
            detalies.AppendLine("Color Of Vehicle: " + Color.ToString());
            detalies.Append("Number Of Doors: " + NumOfDoors.ToString());
            return detalies;
        }
        public void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            int color,numOfDoors;
            if (i_WhichAttributeToSet == "Color")
            {
                color = int.Parse(i_InputFromUser);// exeption
                if (4 < color || color < 0)
                {
                    throw new ValueOutOfRangeException(0, 3);
                }
                Color = (eCarColor)color;
            }
            if (i_WhichAttributeToSet == "NumOfDoors")
            {
                numOfDoors = int.Parse(i_InputFromUser);// exeption
                if (5 < numOfDoors || numOfDoors < 2)
                {
                    throw new ValueOutOfRangeException(2, 5);
                }
                NumOfDoors = (eNumbersOfDoors)numOfDoors;
            }
        }       
    }
}
