using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car
    {
        internal enum eCarColor
        {
            Red,
            White,
            Black,
            Silver
        }

        internal enum eNumbersOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five,
        }

        private eCarColor m_Color;
        private eNumbersOfDoors m_NumOfDoors;

        internal static List<string> GetQuestions()
        {
            List<string> questionsToUser = new List<string>();
            questionsToUser.Add("Please enter color of the vehicle: enter 0 digit for Red, enter 1 digit for White, enter 2 digit for Black, enter 3 digit for Silver");
            questionsToUser.Add("Please enter how many doors in the vehicle between 2 to 5");
            return questionsToUser;
        }

        internal static List<string> GetAtributes()
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
        }

        public eNumbersOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
        }

        internal string GetAllDetalies()
        {
            return string.Format(@"
Color Of Vehicle:{0}
Number Of Doors:{1}",
Color.ToString(), NumOfDoors.ToString());
        }

        internal void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            int color, numOfDoors;
            if(i_WhichAttributeToSet == "Color")
            {
                color = int.Parse(i_InputFromUser);
                if (color > 4 || color < 0)
                {
                    throw new ValueOutOfRangeException(0, 3);
                }

                m_Color = (eCarColor)color;
            }

            if(i_WhichAttributeToSet == "NumOfDoors")
            {
                numOfDoors = int.Parse(i_InputFromUser);
                if (numOfDoors > 5 || numOfDoors < 2)
                {
                    throw new ValueOutOfRangeException(2, 5);
                }

                m_NumOfDoors = (eNumbersOfDoors)numOfDoors;
            }
        }       
    }
}
