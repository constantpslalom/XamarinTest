using System;
using System.Globalization;
using Xamarin.Forms;

namespace PhonewordBlank
{
    public class IntStrToBoolStrConverter : IValueConverter
    {
        public IntStrToBoolStrConverter()
        {
        }

        // source to target
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int a = 5;

            int val = Int32.Parse((string)value);
            string param = (string)parameter;
            int paramVal = Int32.Parse(param);

            return (val + Triple(paramVal)) > 300;
        }

        // target to source
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int paramValue = Triple(Int32.Parse((string)parameter));
            return (bool)value ? Math.Max(paramValue, 301) : 0;
            // return val.ToString();
        }

        public int Triple(int param) {
            return param * 3;
        }
    }
}
