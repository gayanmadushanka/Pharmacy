
namespace Ccom.Pharmacy.Core.DomainObjects
{
    public class IOSAmount
    {
        public string CurrencyCode { get; set; }

        public short Decimals { get; set; }

        public bool DecimalsSpecified { get; set; }

        public string CurrencyText { get; set; }

        public double Value { get; set; }
    }
}
