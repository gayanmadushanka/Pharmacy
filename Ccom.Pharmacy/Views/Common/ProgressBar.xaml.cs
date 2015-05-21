using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Ccom.Pharmacy.Views.Common
{
    /// <summary>
    /// Interaction logic for ProgressBar.xaml
    /// </summary>
    public partial class ProgressBar
    {
        private DispatcherTimer timer;
        public ProgressBar(SolidColorBrush color)
        {
            InitializeComponent();
            progressBar.Foreground = color;
        }
        public ProgressBar()
        {
            InitializeComponent();
            btnProgressClose.Visibility = Visibility.Collapsed;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 2, 0);
            timer.Tick += new EventHandler(ShowCloseButton);
            timer.Start();
         
        }

        private void ShowCloseButton(object sender, EventArgs e)
        {
            btnProgressClose.Visibility = Visibility.Visible;
            timer.Stop();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
