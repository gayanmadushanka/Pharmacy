using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Ccom.Pharmacy.Views;
using Microsoft.Reporting.WinForms;

namespace Ccom.Pharmacy.Managers
{
    internal static class NavigationManager
    {
        public static Stack<Control> FlowView = new Stack<Control>();
        public static Grid ContentPanel;
        public static ReportViewer ReportViewer;

        public static Control GoBack()
        {
            PopUpManager.GrHeaderContent.Visibility = Visibility.Visible;
            FlowView.Pop();
            Control control = FlowView.Peek();
            AddView(control);
            return control;
        }

        public static void AddView(Control control)
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(control);
        }

        public static void LoadMainView()
        {
            LoggingView operation = new LoggingView();
            PopUpManager.GrHeaderContent.Visibility = Visibility.Collapsed;
            //StaticDataManager.Window.ViewModel.LogOutBtnVisibility = Visibility.Collapsed;
            AddView(operation);
        }
    }
}
