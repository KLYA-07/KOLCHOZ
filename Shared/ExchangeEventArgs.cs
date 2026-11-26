using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ExchangeEventArgs : EventArgs
    {
        public int payerFarmerID;
        public int sellerFarmerID;
        public float fieldArea;

        public ExchangeEventArgs(int payerFarmerID, int sellerFarmerID, float fieldArea)
        {
            this.payerFarmerID = payerFarmerID;
            this.sellerFarmerID = sellerFarmerID;
            this.fieldArea = fieldArea;
        }
    }
}
