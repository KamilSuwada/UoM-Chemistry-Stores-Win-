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
    public partial class OrderVC : Form
    {
        public UoMChemistryStores windowVC { get; set; }
        public Order order { get; set; }

        public OrderVC()
        {
            InitializeComponent();
            logOrder.CheckState = CheckState.Checked;
        }


        public void displayOrder(bool preference)
        {
            if (preference == false)
            {
                this.orderBox.Text = order.email;
            }
            else
            {
                this.orderBox.Text = order.list;
            }
        }


        private void copyOrderButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(order.email);

            if (logOrder.CheckState == CheckState.Checked)
            {
                OrderLog log = new OrderLog();

                List<ItemInBasket> items = new List<ItemInBasket>();

                foreach (Item item in windowVC.appLogic.currentBasket)
                {
                    ItemInBasket logItem = new ItemInBasket();

                    logItem.id = item.id;
                    logItem.quantity = item.quantity;

                    items.Add(logItem);
                }

                log.items = items;
                log.personalData = windowVC.appLogic.personalData;

                DateTime now = DateTime.Now;
                string format = "yyyy-MM-dd_HH-mm-ss";
                log.dateOrderedString = now.ToString(format);

                string fileName = log.dateOrderedString;

                JSONCoder.LogOrder<OrderLog>(log, fileName);
            }

            this.Close();
        }

        private void shareOrderButton_Click(object sender, EventArgs e)
        {
            OrderShare share = new OrderShare();
            List<ItemInBasket> itemsToShare = new List<ItemInBasket>();

            foreach (Item item in windowVC.appLogic.currentBasket)
            {
                ItemInBasket itemToShare = new ItemInBasket();
                itemToShare.id = item.id;
                itemToShare.quantity = item.quantity;
                itemsToShare.Add(itemToShare);
            }

            share.items = itemsToShare;


            string filePath;

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "shared order";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                filePath = savefile.FileName;
                JSONCoder.ShareOrder<OrderShare>(share, filePath);
                this.Close();
            }
        }
    }
}
