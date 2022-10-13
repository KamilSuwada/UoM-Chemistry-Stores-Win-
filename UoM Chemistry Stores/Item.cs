using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoM_Chemistry_Stores
{
    public class Item
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
        public bool isUsual { get; set; } = false;
        public int usualQuantity { get; set; } = 0;
        public int imageIndex { get; set; }

        public int occuranceInSearch { get; set; } = 0;



        // computed property which generates long string from keywords
        public string joinedKeywords
        {
            get
            {
                string output = "";

                for (int i = 0; i < this.keywords.Count; i++)
                {
                    if (i - 1 == this.keywords.Count)
                    {
                        output += this.keywords[i];
                    }
                    else
                    {
                        output += $"{this.keywords[i]} ";
                    }
                }

                return output;
            }
        }


        // computed property which returns quantity of the item as e.g. x 4
        public string formattedQuantity
        {
            get { return $"x {this.quantity}"; }
        }


        // formatted price returns quantity * price of the selection as e.g. 12.53
        public string formattedPrice
        {
            get
            {
                double amount = this.price * (double)this.quantity;
                return String.Format("{0:0.00}", amount);
            }
        }


        // formatted list price returns price of the selection as e.g. 12.53
        public string formattedListPrice
        {
            get
            {
                return String.Format("{0:0.00}", this.price);
            }
        }


        // method for gneration of a short name: ful name is split into an array by the space character set, then first 4 words are rejoined.
        public string shortName
        {
            get
            {
                string[] words = this.name.Split(' ');
                string result = "";

                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        result = words[i] + " ";
                    }
                    else if (i == 1)
                    {
                        result = result + words[i] + " ";
                    }
                    else
                    {
                        result = result + words[i];
                    }
                }

                return result;
            }
        }


        // method for increasing quantity by 1.
        public void didTapPlusOneButton()
        {
            this.quantity = this.quantity + 1;
        }


        // method for decreasing the quantity by 1. Only called when quantity is greater than zero: we will not order -1 bottles of DCM.
        public void didTapMinusOneButton()
        {
            if (this.quantity > 0)
            {
                this.quantity = this.quantity - 1;
            }
        }


        // method for toggling the selection of an item as favourite, currently unimplemented.
        public void didTapFavouriteButton()
        {
            if (this.isFavourite == true)
            {
                this.isFavourite = false;
            }
            else
            {
                this.isFavourite = true;
            }
        }



        // method for expressing the item as one line, for order.
        public string returnFormattedSelf()
        {
            return $"{this.quantity} x {this.name} - {this.code}\n";
        }



    }
}
