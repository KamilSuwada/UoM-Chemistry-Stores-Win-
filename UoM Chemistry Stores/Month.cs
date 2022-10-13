using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class Month
    {

        public string name { get; set; }
        public List<OrderLog> logs { get; set; }


        public Month()
        {
            List<OrderLog> logs = new List<OrderLog>();
            this.logs = logs;
        }

    }
}
