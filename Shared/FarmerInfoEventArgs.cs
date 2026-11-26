using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FarmerInfoEventArgs : EventArgs
    {
        public string farmerName { get; }
        public string farmerSurname { get; }
        public string phoneNumber { get; }
        public decimal finacialCapital { get; }
        public float fieldArea { get; }
        public string farmAddress { get; }
        public string farmType { get; }
        public DateTime registrationDate { get; }

        public FarmerInfoEventArgs(string farmerName, string farmerSurname, string phoneNumber, decimal finacialCapital, float fieldArea, string farmAddress, string farmType, DateTime registrationDate)
        {
            this.farmerName = farmerName;
            this.farmerSurname = farmerSurname;
            this.phoneNumber = phoneNumber;
            this.finacialCapital = finacialCapital;
            this.fieldArea = fieldArea;
            this.farmAddress = farmAddress;
            this.farmType = farmType;
            this.registrationDate = registrationDate;
        }
    }
}
