using CookieClicker.Helpers;
using CookieClicker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker.Services
{
    public class TestDataService : IDataService
    {
        public List<ItemModel> GetItems()
        {
            List<ItemModel> items = new List<ItemModel>();
            items.Add(new ItemModel() { Name = "Cursor", StartingPrice = 15, Amount = 0, CookieReward = 0.1 });
            items.Add(new ItemModel() { Name = "Grandma", StartingPrice = 100, Amount = 0, CookieReward = 0.5 });
            items.Add(new ItemModel() { Name = "Farm", StartingPrice = 200, Amount = 0, CookieReward = 1 });
            items.Add(new ItemModel() { Name = "Mine", StartingPrice = 500, Amount = 0, CookieReward = 2 });
            items.Add(new ItemModel() { Name = "Factory", StartingPrice = 1000, Amount = 0, CookieReward = 5 });
            items.Add(new ItemModel() { Name = "Bank", StartingPrice = 2000, Amount = 0, CookieReward = 8 });
            items.Add(new ItemModel() { Name = "Temple", StartingPrice = 5000, Amount = 0, CookieReward = 10 });
            items.Add(new ItemModel() { Name = "Wizard tower", StartingPrice = 10000, Amount = 0, CookieReward = 15 });
            items.Add(new ItemModel() { Name = "Shipment", StartingPrice = 25000, Amount = 0, CookieReward = 25 });
            items.Add(new ItemModel() { Name = "Alchemy lab", StartingPrice = 50000, Amount = 0, CookieReward = 50 });
            items.Add(new ItemModel() { Name = "Multiply", StartingPrice = 100, Amount = 1 });
            FileHandler.Serialize("Test1", items);
            return items;
        }
    }
}
