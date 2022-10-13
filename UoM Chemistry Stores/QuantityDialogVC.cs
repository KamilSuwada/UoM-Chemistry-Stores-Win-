using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoM_Chemistry_Stores
{
    public partial class QuantityDialogVC : Form
    {
        UoMChemistryStores windowVC { get; set; }
        Item selectedItem { get; set; }

        public QuantityDialogVC(UoMChemistryStores windowVC, Item item)
        {
            InitializeComponent();
            this.windowVC = windowVC;
            this.selectedItem = item;
            this.Text = $"{item.quantity}x {item.name}";
        }

        private void quantityTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int quntity = -1;

                if (Int32.TryParse(quantityTextBox.Text, out quntity) == true)
                {
                    if (this.selectedItem != null && this.windowVC != null && quntity != -1)
                    {
                        selectedItem.quantity = quntity;
                        windowVC.refreshAll();
                    }
                    else
                    {
                        MessageBox.Show("OOOPS! Something went wrong...");
                    }
                }
                else
                {
                    MessageBox.Show("That was not a number.");
                }

                this.Close();
            }
        }
    }
}
