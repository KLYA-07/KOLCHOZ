using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FarmTypeEventArgs
    {
        public string farmType;

        public FarmTypeEventArgs(string farmType)
        {
            this.farmType = farmType;
        }
    }
}
