using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CustomerCard
    {
        private string m_CarOwnerName;
        private string m_PhoneNumber;
        private eRepairStatus m_CarRepairStatus;

        public CustomerCard(string i_CarOwnerName, string i_PhoneNumber)
        {
            m_CarOwnerName = i_CarOwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_CarRepairStatus = eRepairStatus.InRepair;
        }

        public StringBuilder GetDetalies()
        {
            StringBuilder detailsCustomer = new StringBuilder();
            detailsCustomer.AppendLine("Car owner name: " + m_CarOwnerName);
            detailsCustomer.AppendLine("Car owner phone number: " + m_PhoneNumber);
            detailsCustomer.AppendLine("Car status: " + m_CarRepairStatus.ToString());
            return detailsCustomer;
        }

        public eRepairStatus CarRepairStatus
        {
            get
            {
                return m_CarRepairStatus;
            }

            set
            {
                if ((int)value > 2 || (int)value < 0)
                {
                    throw new ValueOutOfRangeException(0, 2);
                }

                m_CarRepairStatus = value;
            }
        }
    }
}
