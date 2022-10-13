using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class Subcategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Item> items { get; } = new List<Item>();
        public Category parentCategory { get; set; }
    }
}
