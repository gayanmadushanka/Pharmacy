using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace IOS.Common.Utils
{
    public class CreditCardNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                string date = (string)value;
                StringBuilder builder = new StringBuilder(date);

                index=
                for (; index < input.Length - endIndex; index++)
                {
                    builder[index] = newChar;
                }
                return builder.ToString();
                return date.Value.ToString(format, CultureInfo.InvariantCulture);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string strValue = value.ToString();
                DateTime resultDateTime;
                if (DateTime.TryParse(strValue, out resultDateTime))
                {
                    return resultDateTime;
                }
            }
            return value;
        }
    }
}

