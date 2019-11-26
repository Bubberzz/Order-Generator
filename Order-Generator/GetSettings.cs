using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Generator
{
    class GetSettings
    {
        public static string getSettings()
        {
            var reader = File.OpenText("settings.txt");
            string datasample;
            while ((datasample = reader.ReadLine()) != null)
            {
                int x = int.Parse(reader.ReadLine());
            }

            return "";
        }

        public void setSettings()
        {

        }
    }
}
