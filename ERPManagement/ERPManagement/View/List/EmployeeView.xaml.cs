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
using Microsoft.Win32;

namespace ERPManagement.View.List
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Telerik.Windows.Controls.RadWindow
    {
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void lbChangeAvatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog opDlg = new OpenFileDialog();
            opDlg.CheckFileExists = true;
            opDlg.Filter = "Image(*.JPG, *.PNG, *.BMP)|*.JPG;*.PNG;*.BMP";
            opDlg.FilterIndex = 0;
            var result = opDlg.ShowDialog();
            if (result != null && result.Value)
            {

            }
        }
    }
}