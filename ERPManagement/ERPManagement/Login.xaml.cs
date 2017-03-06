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
using System.Windows.Shapes;

namespace ERPManagement
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Telerik.Windows.Controls.RadWindow
    {
        private ViewModel.Login.LoginViewModel lgViewModel = null;

        public Login()
        {
            InitializeComponent();
            lgViewModel = (Content as Grid).DataContext as ViewModel.Login.LoginViewModel;
        }

        private void pw_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lgViewModel.IsVisiblePasswordPlaceHolder = String.IsNullOrEmpty(pw.Password);
            lgViewModel.IsValidate= !String.IsNullOrEmpty(lgViewModel.UserName) && !String.IsNullOrEmpty(pw.Password);
        }
    }
}