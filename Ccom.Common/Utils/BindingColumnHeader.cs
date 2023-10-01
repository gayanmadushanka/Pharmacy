using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace Ccom.Common.Utils
{
    public class BindingColumnHeader : Behavior<DataGridColumn>
    {
        /// <summary>
        /// The <see cref="Header" /> dependency property's name.
        /// </summary>
        public const string HeaderPropertyName = "Header";

        /// <summary>
        /// Gets or sets the value of the <see cref="Header" />
        /// property. This is a dependency property.
        /// </summary>
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set
            {
                SetValue(HeaderProperty, value);
            }
        }

        /// <summary>
        /// Identifies the <see cref="Header" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            HeaderPropertyName,
            typeof(object),
            typeof(BindingColumnHeader),
            new PropertyMetadata(new PropertyChangedCallback(HandleHeaderBindingChanged)));

        private static void HandleHeaderBindingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var behave = obj as BindingColumnHeader;
            if (behave == null || behave.AssociatedObject == null)
                return;

            behave.AssociatedObject.Header = args.NewValue;
        }

        protected override void OnAttached()
        {
            if (AssociatedObject == null)
                return;

            AssociatedObject.Header = Header;

            base.OnAttached();
        }

        public BindingColumnHeader()
        {
            // Insert code required on object creation below this point.

            //
            // The line of code below sets up the relationship between the command and the function
            // to call. Uncomment the below line and add a reference to Microsoft.Expression.Interactions
            // if you choose to use the commented out version of MyFunction and MyCommand instead of
            // creating your own implementation.
            //
            // The documentation will provide you with an example of a simple command implementation
            // you can use instead of using ActionCommand and referencing the Interactions assembly.
            //
            //this.MyCommand = new ActionCommand(this.MyFunction);
        }
    }
}
