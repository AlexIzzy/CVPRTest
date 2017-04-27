using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CVPRTest.Helpers
{
    public class BoolToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? isSent = value as bool?;
            return System.Convert.ToInt32(isSent);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int a = int.Parse(value as string);
            return System.Convert.ToBoolean(a);
        }
    }
}
