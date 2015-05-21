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
    public class SupplierViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToChangeVisualStateRequest ToChangeVisualStateRequestEvent;
        public event ToSetManageViewRequest<SupplierManageView> ToSetManageViewRequestEvent;

        private SupplierManageView _supplierManageView;

        #region Supplier Properties
        private ObservableCollection<SupplierEntity> _supplierList = new ObservableCollection<SupplierEntity>();
        public ObservableCollection<SupplierEntity> SupplierList
        {
            get { return _supplierList; }
            set
            {
                _supplierList = value;
                NotifyPropertyChanged(ConstantManager.SupplierList);
            }
        }
        #endregion

        public ICommand AddSupplierCommand { get; set; }
        public ICommand EditSupplierCommand { get; set; }
        public ICommand DeleteSupplierCommand { get; set; }

        public SupplierViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            GetAllSupplier();

            AddSupplierCommand = new DelegateCommand<object, object>(ExecuteAddSupplierCommand);
            EditSupplierCommand = new DelegateCommand<object, object>(ExecuteEditSupplierCommand);
            DeleteSupplierCommand = new DelegateCommand<object, object>(ExecuteDeleteSupplierCommand);
        }

        private async void GetAllSupplier(bool? isSuccess = null, bool isFirst = true)
        {
            SupplierList = new ObservableCollection<SupplierEntity>(await PharmacyAPI.GetAllSupplierAsync());
            if (!isFirst)
            {
                if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            }
            //_serviceAgent.GetAllSupplier((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        SupplierList = e.Result;
            //    }
            //    if (!isFirst)
            //    {
            //        if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            //    }
            //});
        }

        private void ExecuteAddSupplierCommand(object obj)
        {
            _supplierManageView = new SupplierManageView();
            var supplierManageViewModel = _supplierManageView.DataContext as SupplierManageViewModel;
            if (supplierManageViewModel != null)
            {
                supplierManageViewModel.Supplier = new SupplierEntity();
                supplierManageViewModel.ToManageEntityResponseEvent += supplierManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_supplierManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void ExecuteEditSupplierCommand(object obj)
        {
            var selectedSupplier = obj as SupplierEntity;
            _supplierManageView = new SupplierManageView();
            var supplierManageViewModel = _supplierManageView.DataContext as SupplierManageViewModel;
            if (supplierManageViewModel != null)
            {
                supplierManageViewModel.Supplier = selectedSupplier.Clone();
                supplierManageViewModel.ToManageEntityResponseEvent += supplierManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_supplierManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void supplierManageViewModel_ToManageEntityResponseEvent(bool? isSuccess)
        {
            GetAllSupplier(isSuccess, false);
        }

        private void ExecuteDeleteSupplierCommand(object obj)
        {
            if (_supplierManageView == null)
            {
                var selectedSupplier = obj as SupplierEntity;
                if (selectedSupplier != null) DeleteSupplier(selectedSupplier.Id);
            }
            else
            {
                var supplierManageViewModel = _supplierManageView.DataContext as SupplierManageViewModel;
                _supplierManageView = new SupplierManageView();

                var supplier = new SupplierEntity();
                if (supplierManageViewModel != null) supplierManageViewModel.Supplier = supplier.Clone();

                var selectedSupplier = obj as SupplierEntity;
                if (selectedSupplier != null) DeleteSupplier(selectedSupplier.Id);
            }
        }

        private async void DeleteSupplier(int id)
        {
            await PharmacyAPI.DeleteSupplierAsync(id);
            GetAllSupplier();
            //_serviceAgent.DeleteSupplier(id, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        GetAllSupplier();
            //    }
            //});
        }
    }
}
