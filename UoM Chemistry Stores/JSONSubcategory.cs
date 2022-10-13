using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class JSONSubcategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public string imageName { get; set; }
        public List<string> itemsKeywords { get; set; }
        public List<JSONItem> items { get; set; }
    }
}
