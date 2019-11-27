using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Documents;

namespace Order_Generator
{
    public class GetSettings
    {
        public static List<string> getSettings()
        {
            var settings = new List<string>();
            var reader = File.OpenText("settings.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var resultString = Regex.Match(line, @"\d+").Value;
                //var result = int.Parse(resultString);
                settings.Add(resultString);
            }
            reader.Close();
            return settings;
        }

        public static void setSettings(List<string> inputList)
        {
            using (var outputFile = new StreamWriter("settings.txt"))
            {
                foreach (var line in inputList)
                {
                    outputFile.WriteLine(line);
                }
            }
        }
    }
}
