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
    public class InvoiceViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        public event ToChangeVisualStateRequest ToChangeVisualStateRequestEvent;
        public event ToSetManageViewRequest<InvoiceManageView> ToSetManageViewRequestEvent;

        private InvoiceManageView _invoiceManageView;
        //private ProgressBar _progressBar;

        #region Invoice Properties
        private ObservableCollection<InvoiceEntity> _invoiceList = new ObservableCollection<InvoiceEntity>();
        public ObservableCollection<InvoiceEntity> InvoiceList
        {
            get { return _invoiceList; }
            set
            {
                _invoiceList = value;
                NotifyPropertyChanged(ConstantManager.InvoiceList);
            }
        }

        private ObservableCollection<InvoiceItemEntity> _invoiceItemList = new ObservableCollection<InvoiceItemEntity>();
        public ObservableCollection<InvoiceItemEntity> InvoiceItemList
        {
            get { return _invoiceItemList; }
            set
            {
                _invoiceItemList = value;
                NotifyPropertyChanged(ConstantManager.InvoiceItemList);
            }
        }
        #endregion

        public ICommand AddInvoiceCommand { get; set; }
        public ICommand EditInvoiceCommand { get; set; }
        public ICommand ViewInvoiceDetailsCommand { get; set; }
        public ICommand DeleteInvoiceCommand { get; set; }

        public InvoiceViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            GetAllInvoice();

            AddInvoiceCommand = new DelegateCommand<object, object>(ExecuteAddInvoiceCommand);
            EditInvoiceCommand = new DelegateCommand<object, object>(ExecuteEditInvoiceCommand);
            ViewInvoiceDetailsCommand = new DelegateCommand<object, object>(ExecuteViewInvoiceDetailsCommand);
            DeleteInvoiceCommand = new DelegateCommand<object, object>(ExecuteDeleteInvoiceCommand);
        }

        private async void GetAllInvoice()
        {
            //_progressBar = new ProgressBar(new SolidColorBrush(Colors.Blue));
            //_progressBar.Show();
            InvoiceList = new ObservableCollection<InvoiceEntity>(await PharmacyAPI.GetAllInvoiceAsync());
            //_serviceAgent.GetAllInvoice((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        InvoiceList = e.Result;
            //    }
            //    //_progressBar.Close();
            //});
        }

        private void ExecuteAddInvoiceCommand(object obj)
        {
            _invoiceManageView = new InvoiceManageView();
            var invoiceManageViewModel = _invoiceManageView.DataContext as InvoiceManageViewModel;
            if (invoiceManageViewModel != null)
            {
                invoiceManageViewModel.Invoice = new InvoiceEntity();
                invoiceManageViewModel.ToManageEntityResponseEvent += invoiceManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_invoiceManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private void ExecuteEditInvoiceCommand(object obj)
        {
            var selectedInvoice = obj as InvoiceEntity;
            _invoiceManageView = new InvoiceManageView();
            var invoiceManageViewModel = _invoiceManageView.DataContext as InvoiceManageViewModel;
            if (invoiceManageViewModel != null)
            {
                invoiceManageViewModel.Invoice = selectedInvoice.Clone();
                invoiceManageViewModel.ToManageEntityResponseEvent += invoiceManageViewModel_ToManageEntityResponseEvent;
            }
            if (ToSetManageViewRequestEvent != null) ToSetManageViewRequestEvent(_invoiceManageView);
            if (ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateIn);
        }

        private async void ExecuteViewInvoiceDetailsCommand(object obj)
        {
            var selectedInvoice = obj as InvoiceEntity;
            if (selectedInvoice != null)
            {
                InvoiceItemList = new ObservableCollection<InvoiceItemEntity>(await PharmacyAPI.GetInvoiceItemByInvoiceIdAsync(selectedInvoice.Id));
            }
        }

        private void invoiceManageViewModel_ToManageEntityResponseEvent(bool? isSuccess)
        {
            if (isSuccess != true && ToChangeVisualStateRequestEvent != null) ToChangeVisualStateRequestEvent(ConstantManager.VisualStateOut);
            GetAllInvoice();
        }

        private void ExecuteDeleteInvoiceCommand(object obj)
        {
            if (_invoiceManageView == null)
            {
                var selectedInvoice = obj as InvoiceEntity;
                if (selectedInvoice != null) DeleteInvoice(selectedInvoice.Id);
            }
            else
            {
                var invoiceManageViewModel = _invoiceManageView.DataContext as InvoiceManageViewModel;
                _invoiceManageView = new InvoiceManageView();

                var invoice = new InvoiceEntity();
                if (invoiceManageViewModel != null) invoiceManageViewModel.Invoice = invoice.Clone();

                var selectedInvoice = obj as InvoiceEntity;
                if (selectedInvoice != null) DeleteInvoice(selectedInvoice.Id);
            }
        }

        private async void DeleteInvoice(int id)
        {
            await PharmacyAPI.DeleteInvoiceAsync(id);
            GetAllInvoice();

            //_serviceAgent.DeleteInvoice(id, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        GetAllInvoice();
            //    }
            //});
        }
    }
}
