using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace UoM_Chemistry_Stores
{
    public class AppLogic
    {
        public List<Category> categories = new List<Category>();
        public Dictionary<string, Bitmap> imagesDictionary { get; set; }
        public ImageList imageList { get; set; }

        public System.Drawing.Font font { get; set; } = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);

        public System.Drawing.Font fontForFavourites { get; set; } = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

        public System.Drawing.Font headerFont { get; set; } = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);

        public System.Drawing.Font nodeFont { get; set; } = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);

        public UserSettings userSettings { get; set; } = new UserSettings();

        public PersonalData personalData { get; set; } = new PersonalData();

        public List<Category> emptyCategories { get; set; }

        public List<Item> searchHits { get; set; } = new List<Item>();

        public Order CurrentOrder { get; set; }

        public double basketTotal
        {
            get
            {
                double total = 0.0;

                foreach (Item item in this.allItems)
                {
                    if (item.quantity > 0)
                    {
                        double chunk = item.quantity * item.price;
                        total += chunk;
                    }
                }

                return total;
            }
        }

        public string formattedBasketTotal
        { get
            {
                string amount = String.Format("{0:0.00}", this.basketTotal);
                return $"£{amount}";
            }
        }

        public List<Item> favourites
        {
            get
            {
                List<Item> output = new List<Item>();

                foreach (Category category in this.categories)
                {
                    foreach (Subcategory subcategory in category.subcategories)
                    {
                        foreach (Item item in subcategory.items)
                        {
                            if (item.isFavourite == true)
                            {
                                output.Add(item);
                            }
                        }
                    }
                }

                return output;
            }
        }

        public List<Item> allItems
        {
            get
            {
                List<Item> output = new List<Item>();

                foreach (Category category in this.categories)
                {
                    foreach (Subcategory subcategory in category.subcategories)
                    {
                        foreach (Item item in subcategory.items)
                        {
                            output.Add(item);
                        }
                    }
                }

                return output;
            }
        }

        public List<Item> currentBasket
        {   get
            {
                List<Item> output = new List<Item>();

                foreach (Category category in this.categories)
                {
                    foreach (Subcategory subcategory in category.subcategories)
                    {
                        foreach (Item item in subcategory.items)
                        {
                            if (item.quantity != 0)
                            {
                                output.Add(item);
                            }
                        }
                    }
                }

                return output;
            }
        }




        public void saveSate()
        {
            JSONCoder.WritePersonalData<PersonalData>(this.personalData);
            JSONCoder.WriteSettings<UserSettings>(this.userSettings);


            List<ItemInBasket> itemsInBasket = new List<ItemInBasket>();

            foreach (Item item in this.currentBasket)
            {
                ItemInBasket itm = new ItemInBasket();
                itm.id = item.id;
                itm.quantity = item.quantity;

                itemsInBasket.Add(itm);
            }

            JSONCoder.WriteCurrentBasket<List<ItemInBasket>>(itemsInBasket);


            List<FavouriteItem> favouriteItems = new List<FavouriteItem>();

            foreach (Item item in this.allItems)
            {
                if (item.isFavourite == true)
                {
                    FavouriteItem itm = new FavouriteItem();
                    itm.id = item.id;

                    favouriteItems.Add(itm);
                }
            }

            JSONCoder.WriteFavourites<List<FavouriteItem>>(favouriteItems);


            List<UsualItem> usualItems = new List<UsualItem>();

            foreach (Item item in this.allItems)
            {
                if (item.isUsual == true)
                {
                    UsualItem itm = new UsualItem();
                    itm.id = item.id;
                    itm.quantity = item.quantity;

                    usualItems.Add(itm);
                }
            }

            JSONCoder.WriteUsualItems<List<UsualItem>>(usualItems);
        }


        public void reloadImages()
        {
            Dictionary<string, Bitmap> imagesDict = new Dictionary<string, Bitmap>();

            foreach (Item item in this.allItems)
            {
                string location = System.Reflection.Assembly.GetEntryAssembly().Location;
                string executableDirectory = System.IO.Path.GetDirectoryName(location);
                string imagesDir = executableDirectory + $"\\Images";
                string path = imagesDir + $"\\{item.imageName}";
                var tempImage = Image.FromFile(path);

                Bitmap pic = new Bitmap(this.userSettings.imageSize, this.userSettings.imageSize);

                using (Graphics g = Graphics.FromImage(pic))
                {
                    g.DrawImage(tempImage, new Rectangle(0, 0, pic.Width, pic.Height)); //redraw larger image
                }

                imagesDict.Add(item.id, pic);
                tempImage.Dispose();
            }

            this.imagesDictionary = imagesDict;
        }


        public void createImageList(Dictionary<string, Bitmap> imageDict)
        {
            int i = 0;
            ImageList imageList = new ImageList();

            imageList.ImageSize = new Size(this.userSettings.imageSize, this.userSettings.imageSize);
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            foreach (Item item in this.allItems)
            {
                imageList.Images.Add(imageDict[item.id]);
                imageList.Images.SetKeyName(i, item.id);
                item.imageIndex = i;

                i += 1;
            }

            this.imageList = imageList;
        }


        public AppLogic(UoMChemistryStores windowVC)
        {

            // Read Stuff:

            PersonalData personalData = JSONCoder.ReadPersonalData<PersonalData>();
            this.personalData = personalData;

            UserSettings userSettings = JSONCoder.ReadSettings<UserSettings>();
            this.userSettings = userSettings;

            Dictionary<string, Bitmap> imagesDict = new Dictionary<string, Bitmap>();

            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string imagesDir = executableDirectory + $"\\Images";

            if (this.categories.Count == 0)
            {
                List<JSONCategory> categories = JSONCoder.ReadDataBase<List<JSONCategory>>();

                foreach (JSONCategory JSONcategory in categories)
                {
                    Category category = new Category();
                    category.name = JSONcategory.name;
                    category.id = JSONcategory.id;

                    foreach (JSONSubcategory JSONsubcategory in JSONcategory.subcategories)
                    {
                        Subcategory subcategory = new Subcategory();
                        subcategory.name = JSONsubcategory.name;
                        subcategory.id = JSONsubcategory.id;

                        foreach (JSONItem JSONitem in JSONsubcategory.items)
                        {
                            Item item = new Item();
                            item.price = JSONitem.price;
                            item.unitIssue = JSONitem.unitIssue;
                            item.name = JSONitem.name;
                            item.code = JSONitem.code;
                            item.id = JSONitem.id;
                            item.isFavourite = JSONitem.isFavourite;
                            item.keywords = JSONitem.keywords;
                            item.isPPE = JSONitem.isPPE;
                            item.isWaste = JSONitem.isWaste;
                            item.imageName = JSONitem.imageName;


                            string path = imagesDir + $"\\{item.imageName}";
                            var tempImage = Image.FromFile(path);
                            Bitmap pic = new Bitmap(this.userSettings.imageSize, this.userSettings.imageSize);

                            using (Graphics g = Graphics.FromImage(pic))
                            {
                                g.DrawImage(tempImage, new Rectangle(0, 0, pic.Width, pic.Height)); //redraw larger image
                            }

                            imagesDict.Add(item.id, pic);
                            tempImage.Dispose();

                            subcategory.items.Add(item);
                        }
                        category.subcategories.Add(subcategory);
                    }
                    this.categories.Add(category);
                }
            }


            List<FavouriteItem> favouriteItems = JSONCoder.ReadFavourites<List<FavouriteItem>>();

            foreach (FavouriteItem favItem in favouriteItems)
            {
                foreach (Item item in this.allItems)
                {
                    if (item.id == favItem.id)
                    {
                        item.isFavourite = true;
                        break;
                    }
                }
            }


            List<UsualItem> usualItems = JSONCoder.ReadUsualItems<List<UsualItem>>();

            foreach (UsualItem usualItem in usualItems)
            {
                foreach (Item item in this.allItems)
                {
                    if (item.id == usualItem.id)
                    {
                        item.isUsual = true;
                        item.usualQuantity = usualItem.quantity;
                        break;
                    }
                }
            }


            List<ItemInBasket> itemsInBasket = JSONCoder.ReadCurrentBasket<List<ItemInBasket>>();

            foreach (ItemInBasket itemInBasket in itemsInBasket)
            {
                foreach (Item item in this.allItems)
                {
                    if (item.id == itemInBasket.id)
                    {
                        item.quantity = itemInBasket.quantity;
                        break;
                    }
                }
            }

            this.font = new System.Drawing.Font("Segoe UI", this.userSettings.fontSize, System.Drawing.FontStyle.Regular);
            this.fontForFavourites = new System.Drawing.Font("Segoe UI", this.userSettings.fontSize, System.Drawing.FontStyle.Bold);
            this.headerFont = new System.Drawing.Font("Segoe UI", (this.userSettings.fontSize + 2), System.Drawing.FontStyle.Bold);
            this.nodeFont = new System.Drawing.Font("Segoe UI", (this.userSettings.fontSize + 4), System.Drawing.FontStyle.Bold);

            this.imagesDictionary = imagesDict;
            this.createImageList(imagesDict);
        }


        public void resetOrderPreference()
        {
            
        }


        public void setOrderPreferenceAs(bool preference)
        {
            this.userSettings.prefersOrdersAsLists = preference;
        }


        public void resetFontSize()
        {
            this.userSettings.fontSize = 10;

            this.font = new System.Drawing.Font("Segoe UI", this.userSettings.fontSize, System.Drawing.FontStyle.Regular);
            this.fontForFavourites = new System.Drawing.Font("Segoe UI", this.userSettings.fontSize, System.Drawing.FontStyle.Bold);
            this.headerFont = new System.Drawing.Font("Segoe UI", (this.userSettings.fontSize + 2), System.Drawing.FontStyle.Bold);
            this.nodeFont = new System.Drawing.Font("Segoe UI", (this.userSettings.fontSize + 4), System.Drawing.FontStyle.Bold);
        }


        public void changeFontSizeTo(int newSize)
        {
            this.userSettings.fontSize = newSize;

            this.font = new System.Drawing.Font("Segoe UI", this.userSettings.fontSize, System.Drawing.FontStyle.Regular);
            this.fontForFavourites = new System.Drawing.Font("Segoe UI", this.userSettings.fontSize, System.Drawing.FontStyle.Bold);
            this.headerFont = new System.Drawing.Font("Segoe UI", (this.userSettings.fontSize + 2), System.Drawing.FontStyle.Bold);
            this.nodeFont = new System.Drawing.Font("Segoe UI", (this.userSettings.fontSize + 4), System.Drawing.FontStyle.Bold);
        }


        public int numberOfItemsInUsualOrder
        {   get
            {
                int count = 0;

                foreach (Category category in this.categories)
                {
                    foreach (Subcategory subcategory in category.subcategories)
                    {
                        foreach (Item item in subcategory.items)
                        {
                            if (item.isUsual == true)
                            {
                                count += 1;
                            }
                        }
                    }
                }

                return count;
            }
        }


        // Methods:


        public void clearBasket()
        {
            foreach (Item item in this.currentBasket)
            {
                if (item.quantity != 0)
                {
                    item.quantity = 0;
                }
            }
        }


        public void searchItems(string searchText)
        {
            Dictionary<string, Item> hits = new Dictionary<string, Item>();
            string[] searchTerms = searchText.Split(" ");


            foreach (string term in searchTerms)
            {
                var nameHits = this.allItems.Where(item => item.name.Contains(term, StringComparison.OrdinalIgnoreCase));
                var codeHits = this.allItems.Where(item => item.code.Contains(term, StringComparison.OrdinalIgnoreCase));
                var keywordsHits = this.allItems.Where(item => item.joinedKeywords.Contains(term, StringComparison.OrdinalIgnoreCase));


                foreach (Item hit in nameHits)
                {
                    hit.occuranceInSearch += 1;

                    try
                    {
                        Item item = hits[hit.id];
                    }
                    catch
                    {
                        hits.Add(hit.id, hit);
                    }
                }


                foreach (Item item in keywordsHits)
                {
                    bool itemFound = false;

                    foreach (KeyValuePair<string, Item> hit in hits)
                    {
                        if (hit.Key == item.id)
                        {
                            itemFound = true;
                            hit.Value.occuranceInSearch += 1;
                            break;
                        }
                    }

                    if (itemFound == false)
                    {
                        item.occuranceInSearch += 1;
                        hits.Add(item.id, item);
                    }
                }


                foreach (Item item in codeHits)
                {
                    bool itemFound = false;

                    foreach (KeyValuePair<string, Item> hit in hits)
                    {
                        if (hit.Key == item.id)
                        {
                            itemFound = true;
                            hit.Value.occuranceInSearch += 1;
                            break;
                        }
                    }

                    if (itemFound == false)
                    {
                        item.occuranceInSearch += 1;
                        hits.Add(item.id, item);
                    }
                }
            }


            var enum2 = from hit in hits
                        orderby hit.Value.occuranceInSearch descending
                        select hit;

            List<Item> output = new List<Item>();

            foreach (KeyValuePair<string, Item> hit in enum2)
            {
                output.Add(hit.Value);
            }

            this.searchHits = output;
        }


        public void cleanUpAfterSearch()
        {
            foreach (Item item in this.allItems)
            {
                if (item.occuranceInSearch != 0)
                {
                    item.occuranceInSearch = 0;
                }
            }
        }


        public Order generateOrder()
        {
            Order order = new Order();

            bool ppeItem = false;

            string listOrder = "";
            string emailOrder = "";

            string orderString = $"Dear Chemistry Stores,\n\nIt is {this.personalData.name} from the {this.personalData.lab}.\n\nI would like to place an order for the following items, using the code: {this.personalData.code}\n\n\n";
            string listString = "";

            foreach (Item item in this.currentBasket)
            {
                if (item.isPPE == false)
                {
                    string line = item.returnFormattedSelf();
                    orderString = orderString + line;
                    listString = listString + line;
                }
                else
                {
                    ppeItem = true;
                }
            }

            if (ppeItem == false)
            {
                orderString = orderString + "\n\n";
            }
            else
            {
                orderString = orderString + "\n\n";

                orderString = orderString + $"Additionally, I would like to add the following PPE items to the to order using code: {this.personalData.ppeCode}: \n\n";

                foreach (Item item in this.currentBasket)
                {
                    if (item.isPPE == true)
                    {
                        string line = item.returnFormattedSelf();
                        orderString = orderString + line;
                        listString = listString + line;
                    }
                }

                orderString = orderString + "\n\n";
            }

            orderString = orderString + $"Thank you for any help with this,\n\nKind Regards\n\n{this.personalData.name}";


            emailOrder = orderString;
            listOrder = listString;

            order.list = listOrder;
            order.email = emailOrder;

            return order;
        }


        public void didTapPlusButtonOn(List<Item> items)
        {
            foreach (Item item in items)
            {
                item.didTapPlusOneButton();
            }
        }


        public void didTapMinusButtonOn(List<Item> items)
        {
            foreach (Item item in items)
            {
                item.didTapMinusOneButton();
            }
        }


        public void didTapFavouriteOn(List<Item> items)
        {
            foreach (Item item in items)
            {
                item.didTapFavouriteButton();
            }
        }


        public void saveCurrentBasketAsUsualOrder()
        {
            foreach (Item item in this.allItems)
            {
                item.isUsual = false;
                item.usualQuantity = 0;
            }

            foreach (Item item in this.currentBasket)
            {
                item.isUsual = true;
                item.usualQuantity = item.quantity;
            }
        }


        public void orderUsual(bool replace)
        {
            if (replace == true)
            {
                foreach (Item item in this.allItems)
                {
                    item.quantity = 0;
                }

                foreach (Item item in this.allItems)
                {
                    if (item.isUsual == true)
                    {
                        item.quantity = item.usualQuantity;
                    }
                }
            }
            else
            {
                foreach (Item item in this.allItems)
                {
                    if (item.isUsual == true)
                    {
                        item.quantity += item.usualQuantity;
                    }
                }
            }
        }


        public void resetUsualOrder()
        {
            foreach (Item item in this.allItems)
            {
                item.isUsual = false;
            }
        }
    }
}
