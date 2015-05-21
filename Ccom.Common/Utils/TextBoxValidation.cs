using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ccom.Common.Utils
{
    public enum TextBoxFilterType
    {
        None,
        PositiveInteger,
        PositiveDecimal,
        Integer,
        Decimal,
        Alpha,
        Phone
        //    ,
        //PositiveDouble
    }

    public class TextBoxValidation
    {
        // Filter Attached Dependency Property
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.RegisterAttached("Filter", typeof(TextBoxFilterType), typeof(TextBoxValidation), new PropertyMetadata(OnFilterChanged));

        // Gets the Filter property. 
        public static TextBoxFilterType GetFilter(DependencyObject d)
        {
            return (TextBoxFilterType)d.GetValue(FilterProperty);
        }

        // Sets the Filter property.
        public static void SetFilter(DependencyObject d, TextBoxFilterType value)
        {
            d.SetValue(FilterProperty, value);
        }

        public static bool IsNumberValid(string inputNumber)
        {
            bool isNumberValid = true;
            int number = -1;
            if (!Int32.TryParse(inputNumber, out number))
            {
                isNumberValid = false;
            }
            return isNumberValid;
        }

        // Handles changes to the Filter property.
        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = d as TextBox;
            if (TextBoxFilterType.None != (TextBoxFilterType)e.OldValue)
            {
                textBox.KeyDown -= textBox_KeyDown;
            }
            if (TextBoxFilterType.None != (TextBoxFilterType)e.NewValue)
            {
                textBox.KeyDown += textBox_KeyDown;
            }
        }
        //********************************************************************************************
        private static void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // bypass other keys!
            if (IsValidOtherKey(e.Key))
            {
                return;
            }
            TextBoxFilterType filterType = GetFilter((DependencyObject)sender);
            TextBox textBox = sender as TextBox;

            if (null == textBox)
            {
                textBox = e.OriginalSource as TextBox;
            }
            switch (filterType)
            {
                case TextBoxFilterType.PositiveInteger:
                    e.Handled = !IsValidIntegerKey(textBox, e.Key, false);
                    break;
                case TextBoxFilterType.Integer:
                    e.Handled = !IsValidIntegerKey(textBox, e.Key, true);
                    break;
                case TextBoxFilterType.PositiveDecimal:
                    e.Handled = !IsValidDecmialKey(textBox, e.Key, false);
                    break;
                case TextBoxFilterType.Decimal:
                    e.Handled = !IsValidDecmialKey(textBox, e.Key, true);
                    break;
                case TextBoxFilterType.Alpha:
                    e.Handled = !IsValidAlphaKey(e.Key);
                    break;
                case TextBoxFilterType.Phone:
                    e.Handled = !IsValidPhoneNumber(e.Key);
                    break;
                //case TextBoxFilterType.PositiveDouble:
                //    e.Handled = !IsValidDoubleKey(textBox, e.Key, false);
                //    break;
            }
        }

        // Determines whether the specified key is valid other key.
        private static bool IsValidOtherKey(Key key)
        {
            // allow control keys
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                return true;
            }
            // allow
            // Back, Tab, Enter, Shift, Ctrl, Alt, CapsLock, Escape, PageUp, PageDown
            // End, Home, Left, Up, Right, Down, Insert, Delete 
            // except for space!
            // allow all Fx keys
            if (
                (key < Key.D0 && key != Key.Space)
                || (key > Key.Z && key < Key.NumPad0))
            {
                return true;
            }
            // we need to examine all others!
            return false;
        }

        // Determines whether the specified key is valid integer key for the specified text box.
        private static bool IsValidIntegerKey(TextBox textBox, Key key, bool negativeAllowed)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
            {
                return false;
            }
            if (Key.D0 <= key && key <= Key.D9)
            {
                return true;
            }
            if (Key.NumPad0 <= key && key <= Key.NumPad9)
            {
                return true;
            }
            if (negativeAllowed && (key == Key.Subtract))
            {
                return 0 == textBox.Text.Length;
            }
            return false;
        }

        // Determines whether the specified key is valid decmial key for the specified text box.
        private static bool IsValidDecmialKey(TextBox textBox, Key key, bool negativeAllowed)
        {
            if (IsValidIntegerKey(textBox, key, negativeAllowed))
            {
                return true;
            }
            if (key == Key.Decimal)
            {
                return !textBox.Text.Contains(".");
            }
            return false;
        }

        // Determines whether the specified key is valid decmial key for the specified text box.
        //private static bool IsValidDoubleKey(TextBox textBox, Key key, bool negativeAllowed)
        //{
        //    if (IsValidIntegerKey(textBox, key, negativeAllowed))
        //    {
        //        return true;
        //    }
        //    if (key == Key.OemPeriod)
        //    {
        //        return !textBox.Text.Contains(".");
        //    }
        //    return false;
        //}

        // Determines whether the specified key is valid alpha key.
        private static bool IsValidAlphaKey(Key key)
        {
            if (Key.A <= key && key <= Key.Z)
            {
                return true;
            }
            return false;
        }

        // Determines whether the specified key is valid alpha key.
        private static bool IsValidPhoneNumber(Key key)
        {
            if (((Key.D9 >= key && Key.D0 <= key) || Key.Subtract == key) || (Key.NumPad0 <= key && key <= Key.NumPad9) || Key.OemPlus == key)
            {
                return true;
            }
            return false;
        }
    }
}
