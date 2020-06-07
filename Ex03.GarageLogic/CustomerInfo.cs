using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CustomerInfo
    {
        private readonly string r_CarOwnerName;
        private readonly string r_PhoneNumber;
        private eRepairStatus m_CarRepairStatus;

        public CustomerInfo(string i_CarOwnerName, string i_PhoneNumber)
        {
            r_CarOwnerName = i_CarOwnerName;
            r_PhoneNumber = i_PhoneNumber;
            m_CarRepairStatus = eRepairStatus.InRepair;
        }

        public StringBuilder getDetalies()
        {
            StringBuilder detailsCustomer = new StringBuilder();
            detailsCustomer.AppendLine("Car owner name: " + r_CarOwnerName);
            detailsCustomer.AppendLine("Car owner phone number: " + r_PhoneNumber);
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
                m_CarRepairStatus = value;
            }
        }
    }
}
