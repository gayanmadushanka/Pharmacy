
namespace IOS.Common.DomainObjects
{
    public class SaleItemDO
    {
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _price = string.Empty;
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _qty = string.Empty;
        public string Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        private string _amount = string.Empty;
        public string Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
