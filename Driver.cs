using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment.Net.OOP3
{
    public class Driver
    {
        public string DriverId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public Driver(string driverId, string fullName, string phoneNumber)
        {
            DriverId = driverId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
    }
}
