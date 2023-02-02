using CookieClicker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker.Services
{
    public interface IDataService
    {
        List<ItemModel> GetItems();
    }
}
