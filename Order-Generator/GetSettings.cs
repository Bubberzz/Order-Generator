using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Order_Generator
{
    public class GetSettings
    {
        // Gets settings from file
        public static List<int> getSettings()
        {
            List<int> settings = new List<int>();
            StreamReader reader = File.OpenText("settings.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string resultString = Regex.Match(line, @"\d+").Value;
                int result = int.Parse(resultString);
                settings.Add(result);
            }
            reader.Close();
            return settings;
        }

        // Sets settings in file
        public static void setSettings(List<int> inputList)
        {
            List<string> settings = new List<string>();
            StreamReader reader = File.OpenText("settings.txt");
            string line;

            for (int i = 0; (line = reader.ReadLine()) != null; i++)
            {
                settings.Add(Regex.Replace(line, Regex.Match(line, @"\d+").Value, inputList[i].ToString()));
            }
            reader.Close();

            using (StreamWriter writer = new StreamWriter("settings.txt"))
            {
                foreach (string x in settings)
                {
                    writer.WriteLine(x);
                }
            }
        }
    }
}
