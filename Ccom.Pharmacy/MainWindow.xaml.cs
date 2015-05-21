using System.Windows;
using Ccom.Pharmacy.Views;

namespace Ccom.Pharmacy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OperationSelectionView operation = new OperationSelectionView();
            LayoutGrid.Children.Clear();
            LayoutGrid.Children.Add(operation);
        }
    }
}
