using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker.Helpers
{
    public static class FileHandler
    {

        public static void Serialize(string fileName, object obj)
        {
            string filePath = Environment.CurrentDirectory + $@"\Saves\{fileName}.json";
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(filePath, json);
        }

        public static T Deserialize<T>(string fileName)
        {
            string filePath = Environment.CurrentDirectory + $@"\Saves\{fileName}.json";
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
