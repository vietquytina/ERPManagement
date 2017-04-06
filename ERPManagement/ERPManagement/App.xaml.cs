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

        public NationalListViewModel Nationals { get; set; }

        public EquipmentImportationListViewModel EquipmentImports { get; set; }

        public EquipmentExportationListViewModel EquipmentExports { get; set; }

        public EquipmentHandoverListViewModel EquipmentHandovers { get; set; }

        public EquipmentReturningListViewModel EquipmentReturnings { get; set; }

        public EquipmentStatusNoteBookListViewModel EquipmentStatusNoteBooks { get; set; }

        public EquipmentBreakListViewModel EquipmentBreaks { get; set; }

        public EquipmentBreakReportListViewModel EquipmentBreakReports { get; set; }

        public EquipmentTransferListViewModel EquipmentTransfers { get; set; }

        public StatusListViewModel Statuses { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            StyleManager.ApplicationTheme = new Office_BlueTheme();
            RadWindow lgWnd = new Login();
            lgWnd.ShowDialog();
            base.OnStartup(e);
        }

        public void Load()
        {
            Companies = new CompanyListViewModel();
            Departments = new DepartmentListViewModel();
            Nationals = new NationalListViewModel();
            Statuses = new StatusListViewModel();
            EquipmentTypes = new EquipmentTypeListViewModel();
            Regencies = new RegencyListViewModel();
            UnitMeasures = new UnitMeasureListViewModel();
            Employees = new EmployeeListViewModel();
            Equipments = new EquipmentListViewModel();
            EquipmentImports = new EquipmentImportationListViewModel();
            this.EquipmentExports = new EquipmentExportationListViewModel();
            this.EquipmentHandovers = new EquipmentHandoverListViewModel();
            this.EquipmentReturnings = new EquipmentReturningListViewModel();
            this.EquipmentStatusNoteBooks = new EquipmentStatusNoteBookListViewModel();
            this.EquipmentBreaks = new EquipmentBreakListViewModel();
            this.EquipmentBreakReports = new EquipmentBreakReportListViewModel();
            this.EquipmentReturnings = new EquipmentReturningListViewModel();
        }
    }
}