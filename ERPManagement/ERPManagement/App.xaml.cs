using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ERPManagement.ViewModel.Employee;

namespace ERPManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public EmployeeViewModel Employee { get; set; }
    }
}