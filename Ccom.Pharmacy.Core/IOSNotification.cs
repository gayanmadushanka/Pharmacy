using System.Windows;

namespace Ccom.Pharmacy.Core
{
    public class IOSNotification
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public Visibility OkBtnVisibility { get; set; }
        public Visibility CancelBtnVisibility { get; set; }
        public Visibility ProgressBarVisibility { get; set; }

        public IOSNotification()
        {
            OkBtnVisibility = Visibility.Collapsed;
            CancelBtnVisibility = Visibility.Collapsed;
            ProgressBarVisibility = Visibility.Collapsed;
        }
    }
}
