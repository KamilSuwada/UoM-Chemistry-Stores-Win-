using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoM_Chemistry_Stores
{
    public class JSONCoder
    {
        // sharing/reading shared orders:


        public static void ShareOrder<T>(OrderShare data, string filePath)
        {
            string jsonFilePath = filePath + ".order";

            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonFilePath, json);
        }


        public static T ReadSharedOrder<T>(string filePath)
        {
            string jsonFilePath = filePath;

            string text = File.ReadAllText(jsonFilePath);  // string contents of a .json file containing order log
            return JsonSerializer.Deserialize<T>(text);  // method to parse JSON into our custom classes.
        }


        // logging/reading logged orders:


        public static void LogOrder<T>(OrderLog data, string fileName)
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + $"\\Order_Logs\\{fileName}.orderlog";

            string json = JsonSerializer.Serialize(data);

            File.WriteAllText(jsonFilePath, json);
        }


        public static T ReadOrderLogs<T>(string filePath)
        {
            string jsonFilePath = filePath;

            string text = File.ReadAllText(jsonFilePath);  // string contents of a .json file containing order log
            return JsonSerializer.Deserialize<T>(text);  // method to parse JSON into our custom classes.
        }


        // writting Files:

        public static void WriteCurrentBasket<T>(List<ItemInBasket> data)
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\CurrentBasket.json";

            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonFilePath, json);
        }


        public static void WritePersonalData<T>(PersonalData data)
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\PersonalData.json";

            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonFilePath, json);
        }


        public static void WriteSettings<T>(UserSettings data)
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\Settings.json";

            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonFilePath, json);
        }


        public static void WriteFavourites<T>(List<FavouriteItem> data)
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\Favourites.json";

            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonFilePath, json);
        }


        public static void WriteUsualItems<T>(List<UsualItem> data)
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\UsualItems.json";

            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonFilePath, json);
        }


        // reading Files:

        public static T ReadDataBase<T>()
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\Chem_Database.json";

            string text = File.ReadAllText(jsonFilePath);  // string contents of a .json file containing all stores data.
            return JsonSerializer.Deserialize<T>(text);  // method to parse JSON into our custom classes.
        }


        public static T ReadPersonalData<T>()
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\PersonalData.json";

            string text = File.ReadAllText(jsonFilePath);  // string contents of a .json file containing all stores data.
            return JsonSerializer.Deserialize<T>(text);  // method to parse JSON into our custom classes.
        }


        public static T ReadSettings<T>()
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\Settings.json";

            string text = File.ReadAllText(jsonFilePath);  // string contents of a .json file containing all stores data.
            return JsonSerializer.Deserialize<T>(text);  // method to parse JSON into our custom classes.
        }


        public static T ReadFavourites<T>()
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\Favourites.json";

            string text = File.ReadAllText(jsonFilePath);  // string contents of a .json file containing all stores data.
            return JsonSerializer.Deserialize<T>(text);  // method to parse JSON into our custom classes.
        }


        public static T ReadUsualItems<T>()
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\UsualItems.json";

            string text = File.ReadAllText(jsonFilePath);  // string contents of a .json file containing all stores data.
            return JsonSerializer.Deserialize<T>(text);  // method to parse JSON into our custom classes.
        }


        public static T ReadCurrentBasket<T>()
        {
            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);
            string jsonFilePath = executableDirectory + "\\CurrentBasket.json";

            string text = File.ReadAllText(jsonFilePath);  // string contents of a .json file containing all stores data.
            return JsonSerializer.Deserialize<T>(text);  // method to parse JSON into our custom classes.
        }


    }
}
