using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Generator
{
    public class FilePaths
    {
        public static string PackOrder { get; set; }
        public static string OrdersFolder { get; set; }
        public static string Settings { get; set; }

        public static void LoadFileLocations()
        {
            PackOrder = Environment.ExpandEnvironmentVariables(@"%appdata%\Order Generator\PackOrder.xlsx");
            OrdersFolder = Environment.ExpandEnvironmentVariables(@"%appdata%\Order Generator\Orders\");
            Settings = Environment.ExpandEnvironmentVariables(@"%appdata%\Order Generator\settings.txt");
            var orderGeneratorFolder = Environment.ExpandEnvironmentVariables(@"%appdata%\Order Generator\");

            if (!File.Exists(PackOrder))
            {
                File.Copy(@"C:\Program Files (x86)\Asos\Order Generator\PackOrder.xlsx", orderGeneratorFolder + "PackOrder.xlsx");
            }

            if (!File.Exists(Settings))
            {
                File.Copy(@"C:\Program Files (x86)\Asos\Order Generator\settings.txt", orderGeneratorFolder + "settings.txt");
            }
        }
    }
}
