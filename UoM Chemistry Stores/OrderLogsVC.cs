using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UoM_Chemistry_Stores
{
    public partial class OrderLogsVC : Form
    {
        public UoMChemistryStores windowVC { get; set; }
        public List<Year> dateEntries { get; set; }
        public OrderLog selectedOrderLog { get; set; }


        public OrderLogsVC(UoMChemistryStores windowVC)
        {
            InitializeComponent();
            this.windowVC = windowVC;
        }



        public void setUpLabels()
        {
            if (this.selectedOrderLog != null)
            {
                double total = 0.0;

                foreach (ItemInBasket logItem in this.selectedOrderLog.items)
                {
                    foreach (Item item in this.windowVC.appLogic.allItems)
                    {
                        if (logItem.id == item.id)
                        {
                            total += item.price * logItem.quantity;
                            break;
                        }
                    }
                }

                string amount = String.Format("{0:0.00}", total);
                string formatted = $"£{amount}";

                nameLabel.Text = $"Ordered by: {this.selectedOrderLog.personalData.name}";
                codeLabel.Text = $"Main code: {this.selectedOrderLog.personalData.code}";
                labLabel.Text = $"Ordered to: {this.selectedOrderLog.personalData.lab}";
                ppeCodeLabel.Text = $"PPE code: {this.selectedOrderLog.personalData.ppeCode}";
                orderLogTotalLabel.Text = $"Total in order: {formatted}";
            }
            else
            {
                nameLabel.Text = "";
                codeLabel.Text = "";
                labLabel.Text = "";
                ppeCodeLabel.Text = "";
                orderLogTotalLabel.Text = "";
            }
        }



        public void setUpListView()
        {
            itemsListView.View = View.Details;
            itemsListView.GridLines = false;
            itemsListView.FullRowSelect = true;
            itemsListView.LabelWrap = true;

            itemsListView.Font = this.windowVC.appLogic.headerFont;

            itemsListView.Columns.Clear();
            itemsListView.Items.Clear();

            itemsListView.Columns.Add("x");
            itemsListView.Columns.Add("Name");

            itemsListView.Columns[0].TextAlign = HorizontalAlignment.Left;
            itemsListView.Columns[1].TextAlign = HorizontalAlignment.Left;

            if (this.selectedOrderLog != null)
            {
                foreach (ItemInBasket logItem in this.selectedOrderLog.items)
                {
                    foreach (Item item in this.windowVC.appLogic.allItems)
                    {
                        if (logItem.id == item.id)
                        {
                            string[] arr = new string[2];
                            ListViewItem listItem;

                            arr[0] = $"{logItem.quantity}x";
                            arr[1] = item.name;

                            listItem = new ListViewItem(arr);
                            listItem.Tag = item;

                            if (item.isFavourite == true)
                            {
                                listItem.Font = this.windowVC.appLogic.fontForFavourites;
                            }
                            else
                            {
                                listItem.Font = this.windowVC.appLogic.font;
                            }

                            itemsListView.Items.Add(listItem);

                            break;
                        }
                    }
                }

                itemsListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                var width = itemsListView.Size.Width - (itemsListView.Columns[0].Width);
                itemsListView.Columns[1].Width = width - 35;
            }
        }



        public void setUpTreeView()
        {
            dateTreeView.Nodes.Clear();

            dateTreeView.Indent = 8;
            int j = 0;


            foreach (Year year in this.dateEntries)
            {
                TreeNode[] monthNodes = new TreeNode[year.months.Count];
                int i = 0;

                foreach (Month month in year.months)
                {
                    int k = 0;

                    TreeNode[] logNodes = new TreeNode[month.logs.Count];

                    foreach (OrderLog entry in month.logs)
                    {
                        TreeNode logNode = new TreeNode(entry.dateOrderedStringForTreeView);
                        logNode.Tag = entry;
                        logNodes[k] = logNode;

                        k += 1;
                    }

                    TreeNode monthNode = new TreeNode(month.name, logNodes);
                    monthNodes[i] = monthNode;

                    i += 1;
                }

                TreeNode yearNode = new TreeNode(year.value, monthNodes);
                dateTreeView.Nodes.Add(yearNode);

                j += 1;
            }

            dateTreeView.ExpandAll();
            this.selectedOrderLog = null;
        }


        private void refresh()
        {
            //setUpTreeView();
            setUpListView();
            setUpLabels();
        }


        private void dateTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (dateTreeView.SelectedNode != null)
            {
                OrderLog orderLog = dateTreeView.SelectedNode.Tag as OrderLog;

                if (orderLog != null)
                {
                    this.selectedOrderLog = orderLog;
                }
                else
                {
                    this.selectedOrderLog = null;
                }
            }
            else
            {
                this.selectedOrderLog = null;
            }

            setUpLabels();
            setUpListView();
        }

        private void reorderButton_Click(object sender, EventArgs e)
        {
            if (this.selectedOrderLog == null)
            {
                return;
            }

            if (this.windowVC.appLogic.currentBasket.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Your basket contains some items; Press Yes to replace basket, No to add past order to the current, or Cancel to do nothing.", "Past Order Options:", MessageBoxButtons.YesNoCancel);


                if (dialogResult == DialogResult.Yes)
                {
                    foreach (Item item in this.windowVC.appLogic.allItems)
                    {
                        item.quantity = 0;
                    }

                    foreach (ItemInBasket logItem in this.selectedOrderLog.items)
                    {
                        foreach (Item item in this.windowVC.appLogic.allItems)
                        {
                            if (logItem.id == item.id)
                            {
                                item.quantity = logItem.quantity;
                                break;
                            }
                        }
                    }

                    this.windowVC.refreshAll();
                }
                else if (dialogResult == DialogResult.No)
                {
                    foreach (ItemInBasket logItem in this.selectedOrderLog.items)
                    {
                        foreach (Item item in this.windowVC.appLogic.allItems)
                        {
                            if (logItem.id == item.id)
                            {
                                item.quantity += logItem.quantity;
                                break;
                            }
                        }
                    }

                    this.windowVC.refreshAll();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                foreach (ItemInBasket logItem in this.selectedOrderLog.items)
                {
                    foreach (Item item in this.windowVC.appLogic.allItems)
                    {
                        if (logItem.id == item.id)
                        {
                            item.quantity = logItem.quantity;
                            break;
                        }
                    }
                }

                this.windowVC.refreshAll();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dateTreeView.SelectedNode != null)
            {
                OrderLog orderLog = dateTreeView.SelectedNode.Tag as OrderLog;

                if (orderLog != null)
                {
                    string location = System.Reflection.Assembly.GetEntryAssembly().Location;
                    string executableDirectory = System.IO.Path.GetDirectoryName(location);
                    string path = executableDirectory + $"\\Order_Logs\\{orderLog.dateOrderedString}.orderlog";

                    DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete file: {path}? This cannot be undone.", "Confirm deletion:", MessageBoxButtons.OKCancel);

                    if (dialogResult == DialogResult.OK)
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                            this.selectedOrderLog = null;
                            this.recalculateTreeView();
                            this.setUpTreeView();
                            this.refresh();
                        }
                    }
                }
                else
                {
                    this.selectedOrderLog = null;
                }
            }
            else
            {
                this.selectedOrderLog = null;
            }
        }

        private void dateTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void dateTreeView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


            foreach (string path in files)
            {
                OrderLog log;

                if (Path.GetExtension(path) != null)
                {
                    if (Path.GetExtension(path) == ".orderlog")
                    {
                        log = JSONCoder.ReadOrderLogs<OrderLog>(path);
                    }
                    else
                    {
                        MessageBox.Show("This file is not meant to go here, or is corrupted!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("This file is not meant to go here, or is corrupted!");
                    return;
                }


                if (log != null)
                {
                    string message = $"Add order log, file: {path}?";

                    DialogResult dialogResult = MessageBox.Show(message, "Add to logs:", MessageBoxButtons.YesNo);


                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
                            string executableDirectory = System.IO.Path.GetDirectoryName(location);
                            string directory = executableDirectory + $"\\Order_Logs";
                            string name = Path.GetFileNameWithoutExtension(path);
                            string to = directory + $"\\{name}.orderlog";

                            File.Move(path, to);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Error moving file! Please re-start the app and try again.");
                        }

                        this.recalculateTreeView();
                        this.setUpTreeView();
                        this.refresh();
                    }
                }

            }
        }


        private void recalculateTreeView()
        {
            List<Year> logs = new List<Year>();

            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string directory = executableDirectory + $"\\Order_Logs";

            foreach (string file in Directory.EnumerateFiles(directory, "*.orderlog"))
            {
                OrderLog orderLog = JSONCoder.ReadOrderLogs<OrderLog>(file);
                DateTime dateCreated = orderLog.dateOrdered;

                string yearCreated = dateCreated.ToString("yyyy");
                string monthCreated = dateCreated.ToString("MMMM");



                bool foundYear = false;

                foreach (Year year in logs)
                {
                    if (year.value == yearCreated)
                    {
                        foundYear = true;
                        break;
                    }
                }


                if (foundYear == false)
                {
                    Year year = new Year();
                    year.value = yearCreated;

                    foreach (Month month in year.months)
                    {
                        if (monthCreated == month.name)
                        {
                            month.logs.Add(orderLog);
                        }
                    }

                    logs.Add(year);
                }
                else if (foundYear == true)
                {
                    foreach (Year year in logs)
                    {
                        if (year.value == yearCreated)
                        {
                            foreach (Month month in year.months)
                            {
                                if (monthCreated == month.name)
                                {
                                    month.logs.Add(orderLog);
                                }
                            }
                        }
                    }
                }


                foreach (Year year in logs)
                {
                    year.cleanUp();
                }


            }

            foreach (Year year in logs)
            {
                foreach (Month month in year.months)
                {
                    List<OrderLog> sortedList = month.logs.OrderBy(o => o.dateOrdered).ToList();
                    month.logs = sortedList;
                }
            }

            this.dateEntries = logs;
        }

        private void OrderLogsVC_ResizeEnd(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am sorry, this has not been implemented, yet!");
        }
    }
}
