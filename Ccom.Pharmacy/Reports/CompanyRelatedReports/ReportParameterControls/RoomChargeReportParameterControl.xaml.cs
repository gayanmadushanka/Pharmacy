using System.Windows;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.Views.Reporting.CompanyRelatedReports.ReportParameterControls
{
    /// <summary>
    /// Interaction logic for RoomChargeReportParameterControl.xaml
    /// </summary>
    public partial class RoomChargeReportParameterControl
    {
        public RoomChargeReportParameterControl()
        {
            InitializeComponent();
        }

        private void BtnFetch_OnClick(object sender, RoutedEventArgs e)
        {
            if (DateFromDatePck.SelectedDate != null)
            {
                var dateFrom = DateFromDatePck.SelectedDate.Value;
                if (DateToDatePck.SelectedDate != null)
                {
                    var dateTo = DateToDatePck.SelectedDate.Value;
                    var reportViewer = new Report();
                    reportViewer.GetRoomChargeList(1, dateFrom, dateTo);
                    NavigationManager.ReportGrid.Children.Clear();
                    NavigationManager.ReportGrid.Children.Add(reportViewer);
                }
                //else
                //{
                //    _nSettings = new NotificationSettings("Error", "Date Range is Empty", "Error");
                //    _notificationWindow = new NotificationWindow(_nSettings);
                //    _notificationWindow.Show();
                //}
            }
            //else
            //{
            //    _nSettings = new NotificationSettings("Error", "Date Range is Empty", "Error");
            //    _notificationWindow = new NotificationWindow(_nSettings);
            //    _notificationWindow.Show();
            //}
        }
    }
}
