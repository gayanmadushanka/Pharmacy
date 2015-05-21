using System;
using System.Globalization;
using System.Windows.Data;

namespace Ccom.Common.Utils
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime? date = (DateTime?)value;
                string format = (string)parameter;
                return date.Value.ToString(format, CultureInfo.InvariantCulture);
            }
            return string.Empty;
        }

        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (value is DateTime)
        //    {
        //        DateTime test = (DateTime)value;
        //        string date = test.ToString("d/M/yyyy");
        //        return (date);
        //    }

        //    return string.Empty;
        //}

        //public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    DateTime? dateValue = value as DateTime?;
        //    if (dateValue.HasValue)
        //    {
        //        if (dateValue.Value == DateTime.MinValue || dateValue.Value == new DateTime(1900, 1, 1))
        //            return string.Empty;
        //        else
        //            return dateValue.Value.ToString(Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern);
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }
        //}

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
