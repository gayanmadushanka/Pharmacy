using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Ccom.Common.Utils
{
    public static class Extentions
    {
        public static void SetValidation(this FrameworkElement frameworkElement, string message)
        {
            CustomValidation customValidation = new CustomValidation(message);
            Binding binding = new Binding("ValidationError")
             {
                 Mode = BindingMode.TwoWay,
                 NotifyOnValidationError = true,
                 ValidatesOnExceptions = true,
                 Source = customValidation
             };
            frameworkElement.SetBinding(Control.TagProperty, binding);
        }

        public static void RaiseValidationError(this FrameworkElement frameworkElement)
        {
            BindingExpression b = frameworkElement.GetBindingExpression(Control.TagProperty);
            if (b != null)
            {
                ((CustomValidation)b.DataItem).ShowErrorMessage = true;
                b.UpdateSource();
            }
        }

        public static void ClearValidationError(this FrameworkElement frameworkElement)
        {
            BindingExpression b = frameworkElement.GetBindingExpression(Control.TagProperty);
            if (b != null)
            {
                ((CustomValidation)b.DataItem).ShowErrorMessage = false;
                b.UpdateSource();
            }
        }

        public static bool IsTextValid(this string inputText)
        {
            bool isTextValid = true;

            foreach (char character in inputText)
            {
                if (char.IsWhiteSpace(character) == false)
                {
                    if (char.IsLetterOrDigit(character) == false)
                    {
                        if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                        {
                            isTextValid = false;
                            break;
                        }
                    }
                }
            }
            return isTextValid;
        }

        public static bool IsNumberValid(this string inputNumber)
        {
            bool isNumberValid = true;
            int number;
            if (!Int32.TryParse(inputNumber, out number))
            {
                isNumberValid = false;
            }
            return isNumberValid;
        }

        public static bool IsNumberDigitsValid(this string inputNumber)
        {
            const string number = @"^[0-9]\d*$";
            bool isNumberValid = true;
            Regex re = new Regex(number);
            if (!re.IsMatch(inputNumber))
            {
                isNumberValid = false;
            }
            return isNumberValid;
        }

        public static bool IsEmailValid(this string inputEmail)
        {
            bool isEmailValid = true;
            //  string emailExpression = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            //const string emailExpression = (@"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            
            const string emailExpression =
                      @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
               + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
               + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
               + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            Regex re = new Regex(emailExpression);
            if (!re.IsMatch(inputEmail))
            {
                isEmailValid = false;
            }
            return isEmailValid;
        }

        public static bool IsTelphoneNoValid(this string imputPhoneNo)
        {
            const string phoneNoExpression = @"^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*([\s-./\\])?([0-9]*)([\s-./\\])?([0-9]*)$";

            bool isPhoneNoValid = true;

            Regex re = new Regex(phoneNoExpression);
            if (!re.IsMatch(imputPhoneNo))
            {
                isPhoneNoValid = false;
            }
            return isPhoneNoValid;
        }

        public static bool IsDecimalOrInt(this string strDecimalNumber)
        {
            const string strDecimalRegex = @"^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$";
            Regex re = new Regex(strDecimalRegex);
            if (re.IsMatch(strDecimalNumber))
                return (true);
            else
                return (false);
        }

        public static bool IsBankAccountValid(this string inputBackAccount)
        {
            try
            {
                int sum = 0;
                List<int> wegihts = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 2, 3, 4, 5, 6, 7 };
                string accNo = inputBackAccount.Trim();
                char[] accNos = accNo.ToArray();
                List<int> noList = (from no in accNos where no != ' ' select int.Parse(no.ToString(CultureInfo.InvariantCulture))).ToList();
                noList.Reverse();

                for (int r = 0; r < noList.Count; r++)
                {
                    sum += int.Parse(noList[r].ToString()) * wegihts[r];
                }

                if (sum % 11 == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int PrefixNumberValid(string mobilePhoneNoPrifix)
        {
            int isValid = 0;
            if (!string.IsNullOrEmpty(mobilePhoneNoPrifix) && mobilePhoneNoPrifix.Trim().Length >= 2)
            {
                if (mobilePhoneNoPrifix.Substring(1, mobilePhoneNoPrifix.Trim().Length - 1).IsNumberDigitsValid() && mobilePhoneNoPrifix.Substring(0, 1) == "+")
                {
                    //format is correct
                }
                else
                {
                    isValid = 1;
                }
            }
            else if (!string.IsNullOrEmpty(mobilePhoneNoPrifix))
            {
                isValid = 1;

            }
            return isValid;
        }

        public static bool IsOnlyNumberValid(this string inputNumber)
        {
            const string number = @"^[0-9]\d*$";
            bool isNumberValid = true;
            Regex re = new Regex(number);
            if (!re.IsMatch(inputNumber))
            {
                isNumberValid = false;
            }
            return isNumberValid;
        }

        public static bool IsFaxNumberValid(this string imputPhoneNo)
        {
            const string faxNoExpression = @"^[0-9]\d*$";
            bool isFaxNoValid = true;
            Regex re = new Regex(faxNoExpression);
            if (!re.IsMatch(imputPhoneNo))
            {
                isFaxNoValid = false;
            }
            return isFaxNoValid;
        }

        public static void KeyDownIntValid(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                e.Handled = true;
            }
            if (!((e.Key.GetHashCode() > 67 && e.Key.GetHashCode() < 79) || (e.Key.GetHashCode() > 19 && e.Key.GetHashCode() < 30)))
            {
                e.Handled = true;
            }
        }
    }

    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll)
                c.Add(e);
            return c;
        }
    }

    public class CustomValidation
    {
        #region Private Members
        private readonly string message;
        #endregion
        #region Properties
        public bool ShowErrorMessage
        {
            get;
            set;
        }

        public object ValidationError
        {
            get { return null; }
            set
            {
                if (ShowErrorMessage)
                {
                    throw new Exception(message);
                }
            }
        }
        #endregion

        public CustomValidation(string message)
        {
            this.message = message;
        }
    }
}
