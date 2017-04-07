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
using System.IO;

namespace ERPManagement.View.List
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Telerik.Windows.Controls.RadWindow
    {
        private ViewModel.Employee.EmployeeViewModel employeevm = null;

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
                FileStream fs = File.Open(opDlg.FileName, FileMode.Open);
                BitmapImage bmpSrc = new BitmapImage();
                bmpSrc.BeginInit();
                bmpSrc.StreamSource = fs;
                bmpSrc.EndInit();
                imgAvatar.Source = bmpSrc;
                employeevm.SetAvatar(fs);
                fs.Close();
            }
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            employeevm = DataContext as ViewModel.Employee.EmployeeViewModel;
            if (employeevm != null && employeevm.AvatarBuffer != null)
            {
                MemoryStream ms = new MemoryStream(employeevm.AvatarBuffer);
                BitmapImage bmpSrc = new BitmapImage();
                bmpSrc.BeginInit();
                bmpSrc.StreamSource = ms;
                bmpSrc.EndInit();
                imgAvatar.Source = bmpSrc;
                ms.Close();
            }
        }
    }
}