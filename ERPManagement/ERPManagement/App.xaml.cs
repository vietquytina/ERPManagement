using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ERPManagement.ViewModel.Employee;
using Telerik.Windows.Controls;

namespace ERPManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EmployeeViewModel Employee { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            StyleManager.ApplicationTheme = new Office_BlueTheme();
            base.OnStartup(e);
        }
    }
}