namespace Ccom.Common.Utils
{
    public static class DoubleExtension
    {
        public static string FormatDecimalValues(this double value)
        {
            string formateddecimalVal = string.Empty;
            if (value != null)
            {
                string valueString = value.ToString("#.##");
                string[] values = valueString.Split('.');
                if (values.Length >= 2)
                {
                    string decimalVal = values[values.Length - 1];
                    if (!string.IsNullOrEmpty(decimalVal) && decimalVal.Length == 1)
                    {
                        decimalVal = decimalVal + "0";
                    }
                    else if (string.IsNullOrEmpty(decimalVal))
                    {
                        decimalVal = decimalVal + "00";
                    }

                    formateddecimalVal = values[0] + "." + decimalVal;
                }
                else if (!string.IsNullOrEmpty(valueString))
                {
                    formateddecimalVal = valueString + ".00"; ;
                }
            }

            return formateddecimalVal;
        }
    }
}
