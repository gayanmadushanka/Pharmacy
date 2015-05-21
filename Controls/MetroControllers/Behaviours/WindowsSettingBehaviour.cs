using System.Windows.Interactivity;
using US_MetroControllers.Controls;

namespace US_MetroControllers.Behaviours
{
    public class WindowsSettingBehaviour : Behavior<MetroWindow>
    {
        protected override void OnAttached()
        {
            WindowSettings.SetSave(AssociatedObject, AssociatedObject.SaveWindowPosition);
        }
    }
}