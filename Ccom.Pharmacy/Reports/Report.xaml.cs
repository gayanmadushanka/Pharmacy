using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Animation;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Managers;
using Microsoft.Reporting.WinForms;

namespace Ccom.Pharmacy.Views.Reporting
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>

    public partial class Report
    {
        public Report()
        {
            InitializeComponent();
            ReportViewer.ZoomMode = ZoomMode.PageWidth;
        }

        #region Animation Methods
        //private void WindowSourceInitialized(object sender, EventArgs e)
        //{
        //    Top = 0;
        //    Left = 0;
        //    Width = SystemParameters.PrimaryScreenWidth;
        //    Height = SystemParameters.PrimaryScreenHeight;


        //    var s = (Storyboard)Resources["LoadAnim"];
        //    ((DoubleAnimation)s.Children[0]).From = SystemParameters.PrimaryScreenWidth;
        //    s.Begin(this);
        //}

        //private void UnloadAnimCompleted(object sender, EventArgs e)
        //{
        //    Close();
        //}
        #endregion

        public void GetRoomChargeList(int branchId, DateTime startDate, DateTime endDate)
        {
            IEnumerable<RoomChargeForReporting> roomChargeForRepList = PharmacyAPI.GetRoomChargeList(branchId, startDate, endDate);
            DisplayCompanyRelatedReport("RoomChargeReport", "RoomChargeDataSet", roomChargeForRepList);
        }

        public void DisplayCompanyRelatedReport(string reportName, string dataSetName, IEnumerable<object> iEnumerableList)
        {
            ReportViewer.Clear();
            ReportViewer.LocalReport.ReportPath = StaticDataManager.ReportPath + "\\CompanyRelatedReports\\" + reportName + ".rdlc";
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, iEnumerableList));

            switch (reportName)
            {
                case "RoomChargeReport":
                    ReportViewer.RefreshReport();
                    break;
            }
        }
    }
}


