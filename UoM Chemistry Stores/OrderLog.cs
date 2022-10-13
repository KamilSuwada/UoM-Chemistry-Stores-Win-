using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class OrderLog
    {

        public List<ItemInBasket> items { get; set; }
        public string dateOrderedString { get; set; }
        public PersonalData personalData { get; set; }


        public DateTime dateOrdered
        {
            get
            {
                return DateTime.ParseExact(this.dateOrderedString, "yyyy-MM-dd_HH-mm-ss", null);
            }
        }


        public string dateOrderedStringForTreeView
        {
            get
            {
                DateTime date = DateTime.ParseExact(this.dateOrderedString, "yyyy-MM-dd_HH-mm-ss", null);
                return date.ToString("dddd dd, H:mm");
            }
        }
    }
}
