using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine
{
    public class Patron
    {
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }

        public override string ToString()
        {
            return String.Format("Enter: {0}, Exit: {1}", EnterTime, ExitTime); 
        }
    }
}
