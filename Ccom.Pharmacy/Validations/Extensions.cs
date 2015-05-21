using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ccom.Pharmacy.Validations
{
    public static class Extentions
    {

        public static void SetValidation(this FrameworkElement frameworkElement, string message)
        {
            CustomValidation customValidation = new CustomValidation(message);
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding("ValidationError")
            {
                Mode = System.Windows.Data.BindingMode.TwoWay,
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
            int number = -1;
            if (!Int32.TryParse(inputNumber, out number))
            {
                isNumberValid = false;
            }
            return isNumberValid;
        }

        public static bool IsEmailValid(this string inputEmail)
        {
            bool isEmailValid = true;
            //  string emailExpression = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            string emailExpression = (@"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            Regex re = new Regex(emailExpression);
            if (!re.IsMatch(inputEmail))
            {
                isEmailValid = false;
            }
            return isEmailValid;
        }
        
        public static bool IsTelphoneNoValid(this string imputPhoneNo)
        {
            string phoneNoExpression = @"^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*([\s-./\\])?([0-9]*)([\s-./\\])?([0-9]*)$";

            bool isPhoneNoValid = true;

            Regex re = new Regex(phoneNoExpression);
            if (!re.IsMatch(imputPhoneNo))
            {
                isPhoneNoValid = false;
            }
            return isPhoneNoValid;
        }

        //public static bool IsIPAddressValid(this string inputIP)
        //{
        //    string IPExpression = @"^(\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b)$";

        //    bool isIPAddressValid = true;

        //    Regex re = new Regex(IPExpression);
        //    if (!re.IsMatch(inputIP))
        //    {
        //        isIPAddressValid = false;
        //    }
        //    return isIPAddressValid;
        //}


        //public static bool IsPortValid(this string inputPort)
        //{
        //    string portExpression = @"^(6553[0-5]|655[0-2]\d|65[0-4]\d{2}|6[0-4]\d{3}|5\d{4}|[0-9]\d{0,3})";

        //    bool isPortValid = true;

        //    Regex re = new Regex(portExpression);
        //    if (!re.IsMatch(inputPort))
        //    {
        //        isPortValid = false;
        //    }
        //    return isPortValid;
        //}

        public static bool IsDecimalOrInt(this string strDecimalNumber)
        {
            const string strDecimalRegex = @"^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$";
            var re = new Regex(strDecimalRegex);
            return re.IsMatch(strDecimalNumber);
        }
    }
    public class CustomValidation
    {
        #region Private Members
        private string message;
        #endregion
        #region Properties

        public bool ShowErrorMessage
        {
            get;
            set;
        }

        public object ValidationError
        {
            get
            {
                return null;
            }
            set
            {
                if (ShowErrorMessage)
                {
                    throw new Exception(message);
                }
            }
        }
        #endregion

        #region Constructor

        public CustomValidation(string message)
        {
            this.message = message;
        }
        #endregion


    }
}
