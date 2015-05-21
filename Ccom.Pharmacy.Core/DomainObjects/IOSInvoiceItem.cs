using System;

namespace Ccom.Pharmacy.Core.DomainObjects
{
    public class IOSInvoiceItem
    {
        public IOSUniqueId Account { get; set; }

        public IOSAmount Amount { get; set; }

        public IOSUniqueId VatCode { get; set; }

        public string RevenueGroup { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public bool TimeSpecified { get; set; }

        public string Description { get; set; }

        public string TransactionCode { get; set; }

        public string TransactionNo { get; set; }

        public string Supplement { get; set; }

        public string Reference { get; set; }

        public string OriginalRoom { get; set; }



        //This is for tempary use
        public double Credits { get; set; }

        public string CreditsDisplayValue { get; set; }

        public double Charges { get; set; }

        public string ChargesDisplayValue { get; set; }

        public IOSInvoiceItem()
        {
            Account = new IOSUniqueId();
            Amount = new IOSAmount();
            VatCode = new IOSUniqueId();
        }
    }
}
