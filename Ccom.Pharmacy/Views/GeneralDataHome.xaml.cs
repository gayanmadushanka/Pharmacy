using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.Views
{
    /// <summary>
    /// Interaction logic for GeneralDataHome.xaml
    /// </summary>
    public partial class GeneralDataHome
    {
        public GeneralDataHome(ObservableCollection<ModuleEntity> moduleEntities)
        {
            InitializeComponent();
            NavigationManager.FlowView.Push(this);
            if (moduleEntities == null) return;
            foreach (var moduleEntity in moduleEntities)
            {
                SetButtonDynamically(moduleEntity);
            }
            LoadUserControl(moduleEntities.First().PathToLoad);
        }

        private void SetButtonDynamically(ModuleEntity moduleEntity)
        {
            Button button = new Button
            {
                Content = moduleEntity.Name,
                Style = (Style)Application.Current.Resources["MenuButtonStyle"],
                //Height = 30,
                MinWidth = 140,
                Margin = new Thickness(0, 0, 0, 3),
                Tag = moduleEntity.PathToLoad
            };
            button.Click += button_Click;
            StkButtonList.Children.Add(button);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LoadUserControl(((FrameworkElement)(e.Source)).Tag.ToString());
        }

        private void LoadUserControl(string pathToLoad)
        {
            //Assembly assembly = Assembly.LoadFile(@"Ccom.Pharmacy\Ccom.Pharmacy.exe");
            Assembly assembly = Assembly.GetExecutingAssembly();
            UserControl operationControl = (UserControl)assembly.CreateInstance(pathToLoad);
            GrdMainView.Children.Clear();
            if (operationControl != null) GrdMainView.Children.Add(operationControl);
        }
    }
}