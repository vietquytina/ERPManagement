using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ERPManagement.View.List;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Telerik.Windows.Controls.RadWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ShowWindow(Telerik.Windows.Controls.RadWindow window)
        {
            try
            {

                window.ShowDialog();
            }
            catch { }
        }

        private void btnCompanies_Click(object sender, RoutedEventArgs e)
        {
            CompanyList companyList = new CompanyList();
            ShowWindow(companyList);
        }

        private void btnDepartments_Click(object sender, RoutedEventArgs e)
        {
            DepartmentList departmentList = new DepartmentList();
            ShowWindow(departmentList);
        }

        private void btnEquipmentTypes_Click(object sender, RoutedEventArgs e)
        {
            EquipmentTypeList eqTypeList = new EquipmentTypeList();
            ShowWindow(eqTypeList);
        }

        private void btnRegencies_Click(object sender, RoutedEventArgs e)
        {
            RegencyList regencyList = new RegencyList();
            ShowWindow(regencyList);
        }

        private void btnUnitMeasure_Click(object sender, RoutedEventArgs e)
        {
            UnitMeasureList unitMeasureList = new UnitMeasureList();
            ShowWindow(unitMeasureList);
        }

        private void btnEmp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}