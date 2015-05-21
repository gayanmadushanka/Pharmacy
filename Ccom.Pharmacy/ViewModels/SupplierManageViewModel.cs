using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.ViewModels
{
    public class SupplierManageViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToManageEntityResponse ToManageEntityResponseEvent;

        #region Properties
        private SupplierEntity _supplier = new SupplierEntity();
        public SupplierEntity Supplier
        {
            get { return _supplier; }
            set
            {
                _supplier = value;
                NotifyPropertyChanged(ConstantManager.Supplier);
            }
        }
        #endregion

        public ICommand SavaSupplierCommand { get; set; }
        public ICommand CancelSupplierCommand { get; set; }

        public SupplierManageViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            SavaSupplierCommand = new DelegateCommand<object, object>(ExecuteSavaSupplierCommand);
            CancelSupplierCommand = new DelegateCommand<object, object>(ExecuteCancelSupplierCommand);
        }

        private async void ExecuteSavaSupplierCommand(object obj)
        {
            await PharmacyAPI.AddUpdateSupplierAsync(Supplier);
            if (Supplier.Id != 0)
            {
                if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(false);
            }
            else
            {
                if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(true);
            }
            //_serviceAgent.AddUpdateSupplier(Supplier, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        if (Supplier.Id != 0)
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

        private void ExecuteCancelSupplierCommand(object obj)
        {
            if (ToManageEntityResponseEvent != null) ToManageEntityResponseEvent(null);
        }
    }
}
