using System.Collections.ObjectModel;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.Views;

namespace Ccom.Pharmacy.ViewModels
{
    public class CustomerViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToChangeVisualStateRequest ToChangeVisualStateRequestEvent;
        public event ToSetManageViewRequest<CustomerManageView> ToSetManageViewRequestEvent;

        private CustomerManageView _customerManageView;

        #region Customer Properties
        private ObservableCollection<CustomerEntity> _customerList = new ObservableCollection<CustomerEntity>();
        public ObservableCollection<CustomerEntity> CustomerList
        {
            get { return _customerList; }
            set
            {
                _customerList = value;
                NotifyPropertyChanged(ConstantManager.CustomerList);
            }
        }
        #endregion

        public ICommand AddCustomerCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }

        public CustomerViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            GetAllCustomer();

            AddCustomerCommand = new DelegateCommand<object, object>(ExecuteAddCustomerCommand);
            EditCustomerCommand = new DelegateCommand<object, object>(ExecuteEditCustomerCommand);
            DeleteCustomerCommand = new DelegateCommand<object, object>(ExecuteDeleteCustomerCommand);
        }

        private async void GetAllCustomer(bool? isSuccess = null, bool isFirst = true)
        {
            CustomerList = new ObservableCollection<CustomerEntity>(await PharmacyAPI.GetAllCustomerAsync());
            if (!isFirst)
            {
                if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            }
            //_serviceAgent.GetAllCustomer((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        CustomerList = e.Result;
            //    }
            //    if (!isFirst)
            //    {
            //        if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            //    }
            //});
        }

        private void ExecuteAddCustomerCommand(object obj)
        {
            _customerManageView = new CustomerManageView();
            var customerManageViewModel = _customerManageView.DataContext as CustomerManageViewModel;
            if (customerManageViewModel != null)
            {
                customerManageViewModel.Customer = new CustomerEntity();
                customerManageViewModel.ToManageEntityResponseEvent += customerManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_customerManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void ExecuteEditCustomerCommand(object obj)
        {
            var selectedCustomer = obj as CustomerEntity;
            _customerManageView = new CustomerManageView();
            var customerManageViewModel = _customerManageView.DataContext as CustomerManageViewModel;
            if (customerManageViewModel != null)
            {
                customerManageViewModel.Customer = selectedCustomer.Clone();
                customerManageViewModel.ToManageEntityResponseEvent += customerManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_customerManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void customerManageViewModel_ToManageEntityResponseEvent(bool? isSuccess)
        {
            GetAllCustomer(isSuccess, false);
        }

        private void ExecuteDeleteCustomerCommand(object obj)
        {
            if (_customerManageView == null)
            {
                var selectedCustomer = obj as CustomerEntity;
                if (selectedCustomer != null) DeleteCustomer(selectedCustomer.Id);
            }
            else
            {
                var customerManageViewModel = _customerManageView.DataContext as CustomerManageViewModel;
                _customerManageView = new CustomerManageView();

                var customer = new CustomerEntity();
                if (customerManageViewModel != null) customerManageViewModel.Customer = customer.Clone();

                var selectedCustomer = obj as CustomerEntity;
                if (selectedCustomer != null) DeleteCustomer(selectedCustomer.Id);
            }
        }

        private async void DeleteCustomer(int id)
        {
            await PharmacyAPI.DeleteCustomerAsync(id);
            GetAllCustomer();
            //_serviceAgent.DeleteCustomer(id, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        GetAllCustomer();
            //    }
            //});
        }
    }
}
