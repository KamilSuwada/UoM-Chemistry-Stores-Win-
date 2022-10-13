using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace UoM_Chemistry_Stores
{
    internal class K
    {

        

        static List<Category> createCategoriesFromJSON()
        {
            List<Category> output = new List<Category>();

            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            string executableDirectory = System.IO.Path.GetDirectoryName(location);

            Console.WriteLine(executableDirectory);

            return output;
        }

    }
}
