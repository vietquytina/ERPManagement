using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERPManagement
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ERPManagement"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ERPManagement;assembly=ERPManagement"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:MetroTextBox/>
    ///
    /// </summary>
    public class MetroTextBox : TextBox
    {
        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register("PlaceHolder", typeof(String), typeof(MetroTextBox));

        static MetroTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTextBox), new FrameworkPropertyMetadata(typeof(MetroTextBox)));
        }

        private TextBlock tbPlaceHolder = null;

        public String PlaceHolder
        {
            get { return (String)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            tbPlaceHolder = (TextBlock)Template.FindName("tbPlaceHolder", this);
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == TextProperty)
            {
                if (tbPlaceHolder != null)
                    tbPlaceHolder.Visibility = String.IsNullOrEmpty(Text) ? Visibility.Visible : Visibility.Hidden;
            }
        }
    }
}