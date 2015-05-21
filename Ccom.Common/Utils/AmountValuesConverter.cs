using System;
using System.Globalization;
using System.Windows.Data;

namespace Ccom.Common.Utils
{
    public class AmountValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? amount = value as double?;
            if (amount == 0)
            {
                return string.Empty;
            }
            return amount.HasValue ? amount.Value.ToString("N2") : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string a = value.ToString();
            if (string.IsNullOrEmpty(a))
            {
                return 0;
            }
            return double.Parse(a);
        }
        //private string _lastConvertBackString;

        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (!(value is double)) return null;

        //    var stringValue = _lastConvertBackString ?? value.ToString();
        //    _lastConvertBackString = null;

        //    return stringValue;
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (!(value is string)) return null;

        //    double result;
        //    if (double.TryParse((string)value, out result))
        //    {
        //        _lastConvertBackString = (string)value;
        //        return result;
        //    }
        //    return null;
        //}
    }
}