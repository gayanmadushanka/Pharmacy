using System.Collections.Generic;

namespace Ccom.Pharmacy.Core.DomainObjects
{
    public class IOSInvoice
    {
        public IOSGuest Guest { get; set; }
        public List<IOSUniqueId> ProfileIDs { get; set; }
        public IOSUniqueId BillNumber { get; set; }
        public IOSAmount CurrentBalance { get; set; }
        public List<IOSInvoiceItem> InvoiceItemList { get; set; }
        public List<IOSBillTax> BillTaxList { get; set; }

        public IOSInvoice()
        {
            Guest = new IOSGuest();
            ProfileIDs = new List<IOSUniqueId>();
            BillNumber = new IOSUniqueId();
            CurrentBalance = new IOSAmount();
            InvoiceItemList = new List<IOSInvoiceItem>();
            BillTaxList = new List<IOSBillTax>();
        }
    }
}
