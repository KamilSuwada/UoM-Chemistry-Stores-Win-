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
    public partial class UoMChemistryStores : Form
    {
        public AppLogic appLogic { get; set; }

        private bool isSearching = false;
        private List<Item> selectedItemsInBasket = new List<Item>();
        private List<Item> selectedItemsInStores = new List<Item>();

        private bool selectedCategory = false;
        private bool selectedSubcategory = false;
        private int selectedCategoryIndex = 0;
        private int selectedSubcategoryIndex = 0;

        public UoMChemistryStores()
        {
            this.appLogic = new AppLogic(this);
            InitializeComponent();
            this.itemListView.LargeImageList = this.appLogic.imageList;
            this.itemListView.SmallImageList = this.appLogic.imageList;
            this.setUpTreeView();
            this.setUpItemView();
            this.setUpBasketView();
        }


        private void setUpTreeView()
        {
            int j = 0;

            foreach (Category category in this.appLogic.categories)
            {
                TreeNode[] subcategoriesNodes = new TreeNode[category.subcategories.Count];
                int i = 0;

                foreach (Subcategory subcategory in category.subcategories)
                {
                    TreeNode subcategoryNode = new TreeNode(subcategory.name);
                    subcategoryNode.Tag = i;
                    subcategoriesNodes[i] = subcategoryNode;

                    i += 1;
                }

                TreeNode categoryNode = new TreeNode(category.name, subcategoriesNodes);
                categoryNode.Tag = j;

                categoriesTreeView.Nodes.Add(categoryNode);

                if (j == 0)
                {
                    categoriesTreeView.SelectedNode = categoryNode;
                }

                j += 1;
            }
        }


        private void setUpBasketView()
        {
            // BASKET:
            basketListView.View = View.Details;
            basketListView.GridLines = false;
            basketListView.FullRowSelect = true;
            basketListView.LabelWrap = true;

            basketListView.Font = this.appLogic.headerFont;

            basketListView.Columns.Clear();
            basketListView.Items.Clear();

            basketListView.Columns.Add("x");
            basketListView.Columns.Add("Name");

            basketListView.Columns[0].TextAlign = HorizontalAlignment.Left;
            basketListView.Columns[1].TextAlign = HorizontalAlignment.Left;

            if (this.appLogic != null)
            {
                foreach (Item item in appLogic.currentBasket)
                {
                    string[] arr = new string[2];
                    ListViewItem itm;

                    arr[0] = $"{item.quantity}x";
                    arr[1] = item.name;

                    itm = new ListViewItem(arr);
                    itm.Tag = item;
                    itm.Font = appLogic.font;

                    basketListView.Items.Add(itm);
                }
            }
            else
            {
                string[] arr = new string[2];
                ListViewItem itm;

                arr[0] = "";
                arr[1] = "Nothing in the basket.";

                itm = new ListViewItem(arr);
                itm.Font = appLogic.font;

                basketListView.Items.Add(itm);
            }


            basketListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            var width = basketListView.Size.Width - basketListView.Columns[0].Width;
            basketListView.Columns[1].Width = width - 35;


            // PRICE LABEL:

            if (this.appLogic == null)
            {
                totalAmmountLabel.Text = "";
            }
            else
            {
                totalAmmountLabel.Text = appLogic.formattedBasketTotal;
            }
            
        }


        private void setUpItemView()
        {
            switch (appLogic.userSettings.prefferedView)
            {
                case UserSettings.PrefferedView.list:
                    itemListView.View = View.Details;
                    itemListView.HeaderStyle = ColumnHeaderStyle.None;
                    break;
                case UserSettings.PrefferedView.smallImages:
                    itemListView.View = View.Details;
                    itemListView.HeaderStyle = ColumnHeaderStyle.None;
                    break;
                case UserSettings.PrefferedView.largeImages:
                    itemListView.View = View.LargeIcon;
                    itemListView.HeaderStyle = ColumnHeaderStyle.None;
                    break;
            }

            itemListView.GridLines = false;
            itemListView.FullRowSelect = true;
            itemListView.LabelWrap = true;

            itemListView.Font = this.appLogic.headerFont;

            itemListView.Columns.Clear();
            itemListView.Items.Clear();

            switch (appLogic.userSettings.prefferedView)
            {
                case UserSettings.PrefferedView.list:
                    itemListView.Columns.Add("Name");
                    itemListView.Columns.Add("x");
                    itemListView.Columns.Add("£");
                    itemListView.Columns[0].TextAlign = HorizontalAlignment.Left;
                    itemListView.Columns[1].TextAlign = HorizontalAlignment.Left;
                    itemListView.Columns[2].TextAlign = HorizontalAlignment.Right;
                    break;
                case UserSettings.PrefferedView.smallImages:
                    itemListView.Columns.Add("Name");
                    itemListView.Columns[0].TextAlign = HorizontalAlignment.Center;
                    break;
                case UserSettings.PrefferedView.largeImages:
                    itemListView.Columns.Add("Name");
                    itemListView.Columns[0].TextAlign = HorizontalAlignment.Center;
                    break;
            }
        }


        public void refreshAll()
        {
            this.setUpBasketView();
            this.refreshItemList();
        }


        private List<string> findSelection()
        {
            List<string> components = new List<string>();

            if (this.categoriesTreeView.SelectedNode != null)
            {
                string[] temp = this.categoriesTreeView.SelectedNode.FullPath.Split("\\");
                

                foreach (string s in temp)
                {
                    components.Add(s);
                }

                if (components.Count == 1)
                {
                    this.selectedCategory = true;
                    this.selectedSubcategory = false;
                }
                else if (components.Count == 2)
                {
                    this.selectedCategory = true;
                    this.selectedSubcategory = true;
                }
                else
                {
                    this.selectedCategory = false;
                    this.selectedSubcategory = false;
                }

                return components;
            }

            return components;
        }


        private void findSubcategoryIndex(string component)
        {
            int i = 0;

            foreach (Subcategory subcategory in this.appLogic.categories[this.selectedCategoryIndex].subcategories)
            {
                if (subcategory.name == component)
                {
                    selectedSubcategoryIndex = i;
                }

                i += 1;
            }
        }


        private void findCategoryIndex(string component)
        {
            int i = 0;

            foreach (Category category in this.appLogic.categories)
            {
                if (category.name == component)
                {
                    selectedCategoryIndex = i;
                }

                i += 1;
            }
        }


        private void refreshItemList()
        {
            this.setUpItemView();
            List<string> selection = this.findSelection();

            if (isSearching == true)
            {
                foreach (Item item in this.appLogic.searchHits)
                {
                    string[] arr = new string[3];
                    ListViewItem listItem;

                    if (item.quantity == 0)
                    {
                        arr[1] = "";
                    }
                    else
                    {
                        arr[1] = $"{item.quantity}x";
                    }

                    arr[0] = item.name;
                    arr[2] = item.formattedListPrice;

                    listItem = new ListViewItem(arr);
                    listItem.Tag = item;

                    if (item.isFavourite == true)
                    {
                        listItem.Font = this.appLogic.fontForFavourites;
                    }
                    else
                    {
                        listItem.Font = this.appLogic.font;
                    }

                    listItem.ImageKey = item.id;

                    itemListView.Items.Add(listItem);
                }
            }
            else if (isSearching == false)
            {
                if (selectedCategory == false && selectedSubcategory == false)
                {
                    selectedSubcategoryIndex = 0;
                    selectedCategoryIndex = 0;
                }
                else if (selectedCategory == true && selectedSubcategory == false)
                {
                    this.findCategoryIndex(selection[0]);
                    selectedSubcategoryIndex = 0;

                    if (this.appLogic.categories[this.selectedCategoryIndex].name == this.appLogic.categories[0].name)
                    {
                        foreach (Item item in this.appLogic.favourites)
                        {
                            string[] arr = new string[3];
                            ListViewItem listItem;

                            if (item.quantity == 0)
                            {
                                arr[1] = "";
                            }
                            else
                            {
                                arr[1] = $"{item.quantity}x";
                            }

                            arr[0] = item.name;
                            arr[2] = item.formattedListPrice;

                            listItem = new ListViewItem(arr);
                            listItem.Tag = item;

                            if (item.isFavourite == true)
                            {
                                listItem.Font = this.appLogic.fontForFavourites;
                            }
                            else
                            {
                                listItem.Font = this.appLogic.font;
                            }

                            listItem.ImageKey = item.id;

                            itemListView.Items.Add(listItem);
                        }
                    }
                    else
                    {
                        foreach (Subcategory subcategory in this.appLogic.categories[this.selectedCategoryIndex].subcategories)
                        {
                            foreach (Item item in subcategory.items)
                            {
                                string[] arr = new string[3];
                                ListViewItem listItem;

                                if (item.quantity == 0)
                                {
                                    arr[1] = "";
                                }
                                else
                                {
                                    arr[1] = $"{item.quantity}x";
                                }

                                arr[0] = item.name;
                                arr[2] = item.formattedListPrice;

                                listItem = new ListViewItem(arr);
                                listItem.Tag = item;

                                if (item.isFavourite == true)
                                {
                                    listItem.Font = this.appLogic.fontForFavourites;
                                }
                                else
                                {
                                    listItem.Font = this.appLogic.font;
                                }

                                listItem.ImageKey = item.id;

                                itemListView.Items.Add(listItem);
                            }
                        }
                    }
                }
                else if (selectedCategory == true && selectedSubcategory == true)
                {
                    findCategoryIndex(selection[0]);
                    findSubcategoryIndex(selection[1]);

                    foreach (Item item in this.appLogic.categories[this.selectedCategoryIndex].subcategories[this.selectedSubcategoryIndex].items)
                    {
                        string[] arr = new string[3];
                        ListViewItem listItem;

                        if (item.quantity == 0)
                        {
                            arr[1] = "";
                        }
                        else
                        {
                            arr[1] = $"{item.quantity}x";
                        }

                        arr[0] = item.name;
                        arr[2] = item.formattedListPrice;

                        listItem = new ListViewItem(arr);
                        listItem.Tag = item;
                        listItem.Font = this.appLogic.font;

                        listItem.ImageKey = item.id;

                        itemListView.Items.Add(listItem);
                    }
                }
            }

            switch (appLogic.userSettings.prefferedView)
            {
                case UserSettings.PrefferedView.list:

                    itemListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    itemListView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                    var width = itemListView.Size.Width - (itemListView.Columns[1].Width + itemListView.Columns[2].Width);

                    itemListView.Columns[0].Width = width - 35;

                    break;

                case UserSettings.PrefferedView.smallImages:
                    itemListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                    break;

                case UserSettings.PrefferedView.largeImages:
                    break;
            }
        }


        private void searchTextDidChange(object sender, EventArgs e)
        {
            if (searchBox.Text.Length == 0)
            {
                this.isSearching = false;
                this.refreshItemList();
            }
        }


        private void setUsualButton_Click(object sender, EventArgs e)
        {
            if (appLogic.currentBasket.Count > 0)
            {
                appLogic.saveCurrentBasketAsUsualOrder();
                MessageBox.Show("Current basket contents have been saved as usual order.", "Usual Order Saved!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Your basket is empty. Would you like to reset the ususal order insead?", "Usual Order Reset:", MessageBoxButtons.YesNo);


                if (dialogResult == DialogResult.Yes)
                {
                    this.appLogic.resetUsualOrder();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }


        private void orderButton_Click(object sender, EventArgs e)
        {
            if (appLogic.personalData != null)
            {
                if (appLogic.personalData.name != "" && appLogic.personalData.lab != "" && appLogic.personalData.code != "" && appLogic.personalData.ppeCode != "")
                {
                    if (appLogic.currentBasket.Count() > 0)
                    {
                        OrderVC orderVC = new OrderVC();
                        orderVC.windowVC = this;
                        orderVC.order = this.appLogic.generateOrder();
                        orderVC.displayOrder(this.appLogic.userSettings.prefersOrdersAsLists);
                        orderVC.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No items in the basket!");
                    }
                }
                else
                {
                    PersonalDataVC personalDataVC = new PersonalDataVC();
                    personalDataVC.windowVC = this;
                    personalDataVC.personalD = appLogic.personalData;
                    personalDataVC.initialise();
                    personalDataVC.ShowDialog();
                }
            }
            else
            {
                PersonalDataVC personalDataVC = new PersonalDataVC();
                personalDataVC.windowVC = this;
                personalDataVC.ShowDialog();
            }
        }


        private void plusButton_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedIndices.Count > 0)
            {
                this.selectedItemsInStores.Clear();

                foreach (int index in itemListView.SelectedIndices)
                {
                    Item item = itemListView.Items[index].Tag as Item;
                    this.selectedItemsInStores.Add(item);
                }

                appLogic.didTapPlusButtonOn(this.selectedItemsInStores);
            }

            this.refreshAll();

            int inListIndex = 0;

            foreach (ListViewItem listItem in this.itemListView.Items)
            {
                Item inListItem = listItem.Tag as Item;

                foreach (Item selectedItem in this.selectedItemsInStores)
                {
                    if (selectedItem.id == inListItem.id)
                    {
                        itemListView.Items[inListIndex].Selected = true;
                        itemListView.Items[inListIndex].Focused = true;
                        itemListView.Items[inListIndex].EnsureVisible();
                    }
                }

                inListIndex += 1;
            }

            itemListView.Select();
        }


        private void minusButton_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedIndices.Count > 0)
            {
                this.selectedItemsInStores.Clear();

                foreach (int index in itemListView.SelectedIndices)
                {
                    Item item = itemListView.Items[index].Tag as Item;
                    this.selectedItemsInStores.Add(item);
                }

                appLogic.didTapMinusButtonOn(this.selectedItemsInStores);
            }

            this.refreshAll();

            int inListIndex = 0;

            foreach (ListViewItem listItem in this.itemListView.Items)
            {
                Item inListItem = listItem.Tag as Item;

                foreach (Item selectedItem in this.selectedItemsInStores)
                {
                    if (selectedItem.id == inListItem.id)
                    {
                        itemListView.Items[inListIndex].Selected = true;
                        itemListView.Items[inListIndex].Focused = true;
                        itemListView.Items[inListIndex].EnsureVisible();
                    }
                }

                inListIndex += 1;
            }

            itemListView.Select();
        }


        private void orderUsualButton_Click(object sender, EventArgs e)
        {
            if (this.appLogic.numberOfItemsInUsualOrder < 1)
            {
                MessageBox.Show("There are no items set as usual order. Add items to the basket in the desired quantities and press 'Set Usual' button to set the usual order.", "Usual Order is empty!");
                return;
            }

            if (this.appLogic.currentBasket.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Your basket contains some items; Press Yes to replace basket, No to add usual to current, or Cancel to do nothing.", "Usual Order Options:", MessageBoxButtons.YesNoCancel);


                if (dialogResult == DialogResult.Yes)
                {
                    this.appLogic.orderUsual(true);
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.appLogic.orderUsual(false);
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                this.appLogic.orderUsual(false);
            }

            this.refreshAll();
        }


        private void minusButtonForBasket_Click(object sender, EventArgs e)
        {
            if (basketListView.SelectedIndices.Count > 0)
            {
                this.selectedItemsInBasket.Clear();

                foreach (int index in basketListView.SelectedIndices)
                {
                    Item item = basketListView.Items[index].Tag as Item;
                    this.selectedItemsInBasket.Add(item);
                }

                appLogic.didTapMinusButtonOn(this.selectedItemsInBasket);
            }

            this.refreshAll();

            int inListIndex = 0;

            foreach (ListViewItem listItem in this.basketListView.Items)
            {
                Item inListItem = listItem.Tag as Item;

                foreach (Item selectedItem in this.selectedItemsInBasket)
                {
                    if (selectedItem.id == inListItem.id)
                    {
                        basketListView.Items[inListIndex].Selected = true;
                        basketListView.Items[inListIndex].Focused = true;
                        basketListView.Items[inListIndex].EnsureVisible();
                    }
                }

                inListIndex += 1;
            }

            basketListView.Select();
        }


        private void plusButtonForBasket_Click(object sender, EventArgs e)
        {
            if (basketListView.SelectedIndices.Count > 0)
            {
                this.selectedItemsInBasket.Clear();

                foreach (int index in basketListView.SelectedIndices)
                {
                    Item item = basketListView.Items[index].Tag as Item;
                    this.selectedItemsInBasket.Add(item);
                }

                appLogic.didTapPlusButtonOn(this.selectedItemsInBasket);
            }

            this.refreshAll();

            int inListIndex = 0;

            foreach (ListViewItem listItem in this.basketListView.Items)
            {
                Item inListItem = listItem.Tag as Item;

                foreach (Item selectedItem in this.selectedItemsInBasket)
                {
                    if (selectedItem.id == inListItem.id)
                    {
                        basketListView.Items[inListIndex].Selected = true;
                        basketListView.Items[inListIndex].Focused = true;
                        basketListView.Items[inListIndex].EnsureVisible();
                    }
                }

                inListIndex += 1;
            }

            basketListView.Select();
        }


        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure? This cannot be undone.", "Basket Clearing Alert:", MessageBoxButtons.YesNo);


            if (dialogResult == DialogResult.Yes)
            {
                this.appLogic.clearBasket();
                this.refreshAll();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }


        private void categoriesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.searchBox.Text = "";
            this.isSearching = false;
            this.refreshItemList();
        }


        private void favouriteButton_Click(object sender, EventArgs e)
        {
            if (itemListView.SelectedIndices.Count > 0)
            {
                this.selectedItemsInStores.Clear();

                foreach (int index in itemListView.SelectedIndices)
                {
                    Item item = itemListView.Items[index].Tag as Item;
                    this.selectedItemsInStores.Add(item);
                }

                appLogic.didTapFavouriteOn(this.selectedItemsInStores);
            }

            this.refreshAll();

            int inListIndex = 0;

            foreach (ListViewItem listItem in this.itemListView.Items)
            {
                Item inListItem = listItem.Tag as Item;

                foreach (Item selectedItem in this.selectedItemsInStores)
                {
                    if (selectedItem.id == inListItem.id)
                    {
                        itemListView.Items[inListIndex].Selected = true;
                        itemListView.Items[inListIndex].Focused = true;
                        itemListView.Items[inListIndex].EnsureVisible();
                    }
                }

                inListIndex += 1;
            }

            itemListView.Select();
        }


        private void searchBox_Enter(object sender, EventArgs e)
        {
            
        }


        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBox.Text == "")
                {
                    this.isSearching = false;
                    this.appLogic.searchHits.Clear();
                    this.appLogic.cleanUpAfterSearch();
                    this.refreshAll();
                }
                else
                {
                    this.isSearching = true;
                    this.appLogic.searchItems(searchBox.Text);
                    this.appLogic.cleanUpAfterSearch();
                    this.refreshAll();
                }
            }
        }


        private void updateDetailsButton_Click(object sender, EventArgs e)
        {
            PersonalDataVC personalDataVC = new PersonalDataVC();

            personalDataVC.windowVC = this;
            personalDataVC.personalD = appLogic.personalData;
            personalDataVC.initialise();

            personalDataVC.ShowDialog();
        }


        private void UoMChemistryStores_ResizeEnd(object sender, EventArgs e)
        {
            this.refreshAll();
        }


        private void UoMChemistryStores_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            this.refreshAll();
        }


        private void UoMChemistryStores_MaximumSizeChanged(object sender, EventArgs e)
        {
            this.refreshAll();
        }


        private void UoMChemistryStores_SizeChanged(object sender, EventArgs e)
        {
            this.refreshAll();
        }


        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsVC settingsVC = new SettingsVC(this);
            settingsVC.ShowDialog();
        }


        private void UoMChemistryStores_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.appLogic.saveSate();
        }


        private void itemListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 0;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    appLogic.didTapMinusButtonOn(this.selectedItemsInStores);
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.Add)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    appLogic.didTapPlusButtonOn(this.selectedItemsInStores);
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad0)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 0;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad1)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 1;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 2;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad3)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 3;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad4)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 4;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad5)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 5;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad6)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 6;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad7)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 7;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad8)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 8;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad9)
            {
                if (itemListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInStores.Clear();

                    foreach (int index in itemListView.SelectedIndices)
                    {
                        Item item = itemListView.Items[index].Tag as Item;
                        this.selectedItemsInStores.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInStores)
                    {
                        item.quantity = 9;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.itemListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInStores)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            itemListView.Items[inListIndex].Selected = true;
                            itemListView.Items[inListIndex].Focused = true;
                            itemListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                itemListView.Select();
            }
        }


        private void basketListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 0;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    this.appLogic.didTapMinusButtonOn(this.selectedItemsInBasket);
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.Add)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    this.appLogic.didTapPlusButtonOn(this.selectedItemsInBasket);
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad0)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 0;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad1)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 1;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 2;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad3)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 3;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad4)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 4;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad5)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 5;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad6)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 6;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad7)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 7;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad8)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 8;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
            else if (e.KeyCode == Keys.NumPad9)
            {
                if (basketListView.SelectedIndices.Count > 0)
                {
                    this.selectedItemsInBasket.Clear();

                    foreach (int index in basketListView.SelectedIndices)
                    {
                        Item item = basketListView.Items[index].Tag as Item;
                        this.selectedItemsInBasket.Add(item);
                    }

                    foreach (Item item in this.selectedItemsInBasket)
                    {
                        item.quantity = 9;
                    }
                }

                this.refreshAll();

                int inListIndex = 0;

                foreach (ListViewItem listItem in this.basketListView.Items)
                {
                    Item inListItem = listItem.Tag as Item;

                    foreach (Item selectedItem in this.selectedItemsInBasket)
                    {
                        if (selectedItem.id == inListItem.id)
                        {
                            basketListView.Items[inListIndex].Selected = true;
                            basketListView.Items[inListIndex].Focused = true;
                            basketListView.Items[inListIndex].EnsureVisible();
                        }
                    }

                    inListIndex += 1;
                }

                basketListView.Select();
            }
        }


        private void basketListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (basketListView.SelectedIndices.Count > 0)
            {
                this.selectedItemsInBasket.Clear();

                foreach (int index in basketListView.SelectedIndices)
                {
                    Item item = basketListView.Items[index].Tag as Item;
                    this.selectedItemsInBasket.Add(item);
                }

                appLogic.didTapPlusButtonOn(this.selectedItemsInBasket);
            }

            this.refreshAll();

            int inListIndex = 0;

            foreach (ListViewItem listItem in this.basketListView.Items)
            {
                Item inListItem = listItem.Tag as Item;

                foreach (Item selectedItem in this.selectedItemsInBasket)
                {
                    if (selectedItem.id == inListItem.id)
                    {
                        basketListView.Items[inListIndex].Selected = true;
                        basketListView.Items[inListIndex].Focused = true;
                        basketListView.Items[inListIndex].EnsureVisible();
                    }
                }

                inListIndex += 1;
            }

            basketListView.Select();
        }


        private void itemListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (itemListView.SelectedIndices.Count > 0)
            {
                this.selectedItemsInStores.Clear();

                foreach (int index in itemListView.SelectedIndices)
                {
                    Item item = itemListView.Items[index].Tag as Item;
                    this.selectedItemsInStores.Add(item);
                }

                appLogic.didTapPlusButtonOn(this.selectedItemsInStores);
            }

            this.refreshAll();

            int inListIndex = 0;

            foreach (ListViewItem listItem in this.itemListView.Items)
            {
                Item inListItem = listItem.Tag as Item;

                foreach (Item selectedItem in this.selectedItemsInStores)
                {
                    if (selectedItem.id == inListItem.id)
                    {
                        itemListView.Items[inListIndex].Selected = true;
                        itemListView.Items[inListIndex].Focused = true;
                        itemListView.Items[inListIndex].EnsureVisible();
                    }
                }

                inListIndex += 1;
            }

            itemListView.Select();
        }


        private void itemListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {


                var focusedItem = itemListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    Item item = focusedItem.Tag as Item;
                    QuantityDialogVC dialog = new QuantityDialogVC(this, item);
                    dialog.ShowDialog();
                }
            }
        }


        private void basketListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {


                var focusedItem = basketListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    Item item = focusedItem.Tag as Item;
                    QuantityDialogVC dialog = new QuantityDialogVC(this, item);
                    dialog.ShowDialog();
                }
            }
        }


        private void basketListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }


        private void basketListView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


            foreach (string path in files)
            {
                OrderShare sharedItems;

                if (Path.GetExtension(path) != null)
                {
                    if (Path.GetExtension(path) == ".order")
                    {
                        sharedItems = JSONCoder.ReadSharedOrder<OrderShare>(path);
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

                if (sharedItems != null)
                {
                    string message = "";
                    message += $"File: {path}\n\nTrying to add items:\n\n";

                    foreach (ItemInBasket sharedItem in sharedItems.items)
                    {
                        foreach (Item item in this.appLogic.allItems)
                        {
                            if (item.id == sharedItem.id)
                            {
                                message += $"{sharedItem.quantity}x {item.name}\n";
                                break;
                            }
                        }
                    }

                    DialogResult dialogResult = MessageBox.Show(message, "Add to basket:", MessageBoxButtons.YesNo);


                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (ItemInBasket sharedItem in sharedItems.items)
                        {
                            foreach (Item item in this.appLogic.allItems)
                            {
                                if (item.id == sharedItem.id)
                                {
                                    item.quantity += sharedItem.quantity;
                                    break;
                                }
                            }
                        }
                        this.refreshAll();
                    }
                }
            }
        }


        private void UoMChemistryStores_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }


        private void UoMChemistryStores_DragDrop(object sender, DragEventArgs e)
        {
            //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //foreach (string file in files) MessageBox.Show(file);
        }


        private void orderLogsButton_Click(object sender, EventArgs e)
        {
            OrderLogsVC orderLogsVC = new OrderLogsVC(this);

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

            orderLogsVC.dateEntries = logs;
            orderLogsVC.setUpTreeView();
            orderLogsVC.Show();
        }



    }
}
