using System.Collections.Generic;

namespace IOS.Common.DomainObjects
{
    public class ReceiptTemplateDO
    {
        private string _branchName = string.Empty;
        public string BranchName
        {
            get { return _branchName; }
            set { _branchName = value; }
        }

        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _postalCode = string.Empty;
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        private string _telNo = string.Empty;
        public string TelNo
        {
            get { return _telNo; }
            set { _telNo = value; }
        }

        private string _memberNo = string.Empty;
        public string MemberNo
        {
            get { return _memberNo; }
            set { _memberNo = value; }
        }

        private string _memberName = string.Empty;
        public string MemberName
        {
            get { return _memberName; }
            set { _memberName = value; }
        }

        private string _invoiceNo = string.Empty;
        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set { _invoiceNo = value; }
        }

        private string _operator = string.Empty;
        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        private List<SaleItemDO> _salesItemList = new List<SaleItemDO>();
        public List<SaleItemDO> SalesItemList
        {
            get { return _salesItemList; }
            set { _salesItemList = value; }
        }

        private string _discount = string.Empty;
        public string Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        private string _total = string.Empty;
        public string Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _subTotal = string.Empty;
        public string SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }

        private string _balance = string.Empty;
        public string Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        private string _message = string.Empty;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
