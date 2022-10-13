using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class Year
    {

        public string value { get; set; }
        public List<Month> months { get; set; }


        public Year()
        {
            List<Month> months = new List<Month>();
            this.months = months;

            string[] monthNames = new string[12];

            monthNames[0] = "January";
            monthNames[1] = "February";
            monthNames[2] = "March";
            monthNames[3] = "April";
            monthNames[4] = "May";
            monthNames[5] = "June";
            monthNames[6] = "July";
            monthNames[7] = "August";
            monthNames[8] = "September";
            monthNames[9] = "October";
            monthNames[10] = "November";
            monthNames[11] = "December";

            foreach (string name in monthNames)
            {
                Month month = new Month();
                month.name = name;
                this.months.Add(month);
            }
        }


        public void cleanUp()
        {
            List<int> monthsToDelete = new List<int>();

            int i = 0;

            foreach (Month month in this.months)
            {
                if (month.logs.Count == 0)
                {
                    monthsToDelete.Add(i);
                }

                i += 1;
            }

            monthsToDelete.Reverse();

            foreach (int j in monthsToDelete)
            {
                this.months.RemoveAt(j);
            }
        }

    }
}
