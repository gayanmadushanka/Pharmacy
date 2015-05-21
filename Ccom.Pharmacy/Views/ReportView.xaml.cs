using Ccom.Pharmacy.Managers;
using Microsoft.Reporting.WinForms;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportView
    {
        public ReportView()
        {
            InitializeComponent();
            NavigationManager.ReportViewer = ReportViewer;
            ReportViewer.ZoomMode = ZoomMode.PageWidth;
        }
    }
}
