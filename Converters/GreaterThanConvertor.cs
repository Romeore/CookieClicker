using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CookieClicker.Converters
{
    public class GreaterThanConverter : IValueConverter
    {
        public static readonly IValueConverter Instance = new GreaterThanConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue = (int)(value);
            int compareToValue = (int)parameter;

            return intValue > compareToValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
