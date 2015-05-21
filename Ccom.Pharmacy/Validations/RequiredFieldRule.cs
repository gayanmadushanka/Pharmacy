using System.Globalization;
using System.Windows.Controls;

namespace Ccom.Pharmacy.Validations
{
    public class RequiredFieldRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Is Required");

            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "Is Required");

            return new ValidationResult(true, null);
        }
    }
}
