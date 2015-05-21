using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for LoggingView.xaml
    /// </summary>
    public partial class LoggingView
    {
        public LoggingView()
        {
            InitializeComponent();
            NavigationManager.FlowView.Push(this);
        }
    }
}
