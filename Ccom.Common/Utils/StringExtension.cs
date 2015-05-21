using System.Text;

namespace Ccom.Common.Utils
{
    public static class StringExtension
    {
        public static string GetLast(this string source, int length)
        {
            return length >= source.Length ? source : source.Substring(source.Length - length);
        }

        public static string GetFirst(this string source, int length)
        {
            return (source.Length < length) ? source : source.Substring(0, length);
        }

        public static string ReplaceAt(this string input, int index, char newChar)
        {
            StringBuilder builder = new StringBuilder(input);
            builder[index] = newChar;
            return builder.ToString();
        }

        public static string ReplaceFromTo(this string input, int index, int endIndex, char newChar)
        {
           
            StringBuilder builder = new StringBuilder(input);
            for (; index < input.Length - endIndex; index++)
            {
                builder[index] = newChar;
            }
            return builder.ToString();
        }

        //public static decimal ToTwoDecimalPlaces(this decimal dNum)
        //{
        //    return ((decimal)(Math.Truncate((double)dNum * 100.0) / 100.0));
        //}
    }
}
