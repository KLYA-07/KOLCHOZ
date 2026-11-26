using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FarmerIDEventArgs : EventArgs
    {
        public int ID { get; }

        public FarmerIDEventArgs(int ID)
        {
            this.ID = ID;
        }
    }
}
