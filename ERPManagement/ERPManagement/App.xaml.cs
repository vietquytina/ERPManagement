using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ERPManagement.ViewModel.Employee;
using ERPManagement.ViewModel.List;
using ERPManagement.ViewModel.Equipment;
using Telerik.Windows.Controls;

namespace ERPManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EmployeePermissionViewModel Employee { get; set; }
        public CompanyListViewModel Companies { get; set; }
        public DepartmentListViewModel Departments { get; set; }
        public EquipmentTypeListViewModel EquipmentTypes { get; set; }
        public RegencyListViewModel Regencies { get; set; }
        public UnitMeasureListViewModel UnitMeasures { get; set; }
        public EmployeeListViewModel Employees { get; set; }
        public EquipmentListViewModel Equipments { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            StyleManager.ApplicationTheme = new Office_BlueTheme();
            Login lgWnd = new Login();
            lgWnd.ShowDialog();
            base.OnStartup(e);
        }
    }
}