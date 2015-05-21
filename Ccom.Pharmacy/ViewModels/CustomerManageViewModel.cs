using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.ViewModels
{
    public class CustomerManageViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToManageEntityResponse ToManageEntityResponseEvent;

        #region Properties
        private CustomerEntity _customer = new CustomerEntity();
        public CustomerEntity Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                NotifyPropertyChanged(ConstantManager.Customer);
            }
        }
        #endregion

        public ICommand SavaCustomerCommand { get; set; }
        public ICommand CancelCustomerCommand { get; set; }

        public CustomerManageViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            SavaCustomerCommand = new DelegateCommand<object, object>(ExecuteSavaCustomerCommand);
            CancelCustomerCommand = new DelegateCommand<object, object>(ExecuteCancelCustomerCommand);
        }

        private async void ExecuteSavaCustomerCommand(object obj)
        {
            await PharmacyAPI.AddUpdateCustomerAsync(Customer);
            if (Customer.Id != 0)
            {
                if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(false);
            }
            else
            {
                if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(true);
            }
            //_serviceAgent.AddUpdateCustomer(Customer, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        if (Customer.Id != 0)
            //        {
            //            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(false);
            //        }
            //        else
            //        {
            //            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(true);
            //        }
            //    }
            //});
        }

        private void ExecuteCancelCustomerCommand(object obj)
        {
            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(null);
        }
    }
}
