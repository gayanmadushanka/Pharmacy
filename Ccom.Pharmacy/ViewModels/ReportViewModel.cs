using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;
using Microsoft.Reporting.WinForms;

namespace Ccom.Pharmacy.ViewModels
{
    public class ReportViewModel : INPCBase
    {
        #region Supplier Properties
        private ObservableCollection<ReportTypeEntity> _reportTypeList = new ObservableCollection<ReportTypeEntity>();
        public ObservableCollection<ReportTypeEntity> ReportTypeList
        {
            get { return _reportTypeList; }
            set
            {
                _reportTypeList = value;
                NotifyPropertyChanged(ConstantManager.ReportTypeList);
            }
        }

        private ReportTypeEntity _selectedReportType;
        public ReportTypeEntity SelectedReportType
        {
            get { return _selectedReportType; }
            set
            {
                _selectedReportType = value;
                NotifyPropertyChanged(ConstantManager.SelectedReportType);
            }
        }

        private DateTime _selectedDateFromDatePicker = DateTime.Today.AddDays(-1);
        public DateTime SelectedDateFromDatePicker
        {
            get { return _selectedDateFromDatePicker; }
            set
            {
                _selectedDateFromDatePicker = value;
                NotifyPropertyChanged(ConstantManager.SelectedDateFromDatePicker);
            }
        }

        private DateTime _selectedDateToDatePicker = DateTime.Today;
        public DateTime SelectedDateToDatePicker
        {
            get { return _selectedDateToDatePicker; }
            set
            {
                _selectedDateToDatePicker = value;
                NotifyPropertyChanged(ConstantManager.SelectedDateToDatePicker);
            }
        }
        #endregion

        public ICommand FetchReportCommand { get; set; }
        public ICommand EditSupplierCommand { get; set; }
        public ICommand DeleteSupplierCommand { get; set; }

        public ReportViewModel()
        {
            ReportTypeList.Add(new ReportTypeEntity { Id = 1, Name = "Room Charge Report" });
            ReportTypeList.Add(new ReportTypeEntity { Id = 2, Name = "Transaction Details Report" });

            FetchReportCommand = new DelegateCommand<object, object>(ExecuteFetchReportCommand);
        }

        private void ExecuteFetchReportCommand(object obj)
        {
            if (Equals(SelectedReportType.Name, "Room Charge Report"))
            {
                GetRoomChargeList(1, SelectedDateFromDatePicker, SelectedDateToDatePicker);
            }
            else if (Equals(SelectedReportType.Name, "Transaction Details Report"))
            {
                GetInvoiceList(1, SelectedDateFromDatePicker, SelectedDateToDatePicker);
            }
        }

        private async void GetInvoiceList(int i, DateTime selectedDateFromDatePicker, DateTime selectedDateToDatePicker)
        {
            IEnumerable<InvoiceEntity> invoiceEntities =
               PharmacyAPI.GetInvoiceDetailsByDateRange(new ReportingEntity
               {
                   FromDate = selectedDateFromDatePicker,
                   ToDate = selectedDateToDatePicker
               });
            DisplayCompanyRelatedReport("TransactionDetailsReport", "InvoiceDbDataSet", invoiceEntities);
        }

        public void GetRoomChargeList(int branchId, DateTime startDate, DateTime endDate)
        {
            IEnumerable<RoomChargeForReporting> roomChargeForRepList = PharmacyAPI.GetRoomChargeList(branchId, startDate, endDate);
            DisplayCompanyRelatedReport("RoomChargeReport", "RoomChargeDataSet", roomChargeForRepList);
        }

        public void DisplayCompanyRelatedReport(string reportName, string dataSetName, IEnumerable<object> iEnumerableList)
        {
            NavigationManager.ReportViewer.Reset();
            NavigationManager.ReportViewer.LocalReport.ReportPath = StaticDataManager.ReportPath + "\\" + reportName + ".rdlc";
            NavigationManager.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, iEnumerableList));

            switch (reportName)
            {
                case "RoomChargeReport":
                    NavigationManager.ReportViewer.RefreshReport();
                    break;
                case "TransactionDetailsReport":
                    NavigationManager.ReportViewer.RefreshReport();
                    break;
            }
        }
    }
}
