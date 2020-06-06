using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException: Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

       public ValueOutOfRangeException(float i_MinValue,float i_MaxValue):base("The value that are allowed to enter is between "+ i_MinValue+" to "+ i_MaxValue+"! Please try again!")
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                m_MaxValue = value;
            }
        }
        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                m_MinValue = value;
            }
        }


    }
}
