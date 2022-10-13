using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class JSONOrderLog
    {
        public List<Item> items { get; set; }
        public Order order { get; set; }
        public string dateOrderedString { get; set; }
        public PersonalData personalData { get; set; }
    }
}
