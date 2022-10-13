using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class JSONItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string unitIssue { get; set; }
        public double price { get; set; }
        public bool isFavourite { get; set; }
        public int quantity { get; set; }
        public bool isPPE { get; set; }
        public bool isWaste { get; set; }
        public List<string> keywords { get; set; }
        public string imageName { get; set; }
    }
}
