using CookieClicker.Helpers;
using CookieClicker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker.Services
{
    public class DataService : IDataService
    {
        public List<ItemModel> GetItems()
        {
            return FileHandler.Deserialize<List<ItemModel>>("Test1");
        }
    }
}
