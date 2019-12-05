using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Order_Generator
{
    public static class GetSettings
    {
        // Gets settings from file
        public static List<int> getSettings()
        {
            var settings = new List<int>();
            var reader = File.OpenText(FilePaths.Settings);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var resultString = Regex.Match(line, @"\d+").Value;
                var result = int.Parse(resultString);
                settings.Add(result);
            }
            reader.Close();
            return settings;
        }

        // Sets settings in file
        public static void setSettings(List<int> inputList)
        {
            var settings = new List<string>();
            var reader = File.OpenText(FilePaths.Settings);
            string line;

            for (var i = 0; (line = reader.ReadLine()) != null; i++)
            {
                settings.Add(Regex.Replace(line, Regex.Match(line, @"\d+").Value, inputList[i].ToString()));
            }
            reader.Close();

            using (var writer = new StreamWriter(FilePaths.Settings))
            {
                foreach (var x in settings)
                {
                    writer.WriteLine(x);
                }
            }
        }
    }
}
