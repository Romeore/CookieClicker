using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker
{
    public static class UserSettings
    {

        public static double Cookies { get; set; }

        public static void SaveUserSettings()
        {
            try
            {
                Properties.Settings.Default["Cookies"] = Cookies;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Properties.Settings.Default.Save();
            }
        }

        public static void LoadUserSettings()
        {
            try
            {
                Cookies = Properties.Settings.Default.Cookies;
            }
            catch (Exception)
            {
            }
        }
    }
}
