using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class JSONCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<JSONSubcategory> subcategories { get; set; }
    }
}
