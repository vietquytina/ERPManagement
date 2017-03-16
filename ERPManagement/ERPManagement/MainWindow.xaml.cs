using ERPManagement.View.List;
using ERPManagement.View.Profession;
using ERPManagement.ViewModel.Authorize;
using System.Windows;

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
                /*if (window.IsAuthorize())
                {
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn chưa được cấp quyền chức năng này!");
                }*/
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

        private void btnEqBreak_Click(object sender, RoutedEventArgs e)
        {
            EquipmentBreakDownList frmEqBreakList = new EquipmentBreakDownList();
            ShowWindow(frmEqBreakList);
        }

        private void btnEqImport_Click(object sender, RoutedEventArgs e)
        {
            EquipmentImportationListView frmEqImportList = new EquipmentImportationListView();
            ShowWindow(frmEqImportList);
        }

        private void btnEqExport_Click(object sender, RoutedEventArgs e)
        {
            EquipmentExportationListView frmEqExportList = new EquipmentExportationListView();
            ShowWindow(frmEqExportList);
        }

        private void btnEqHandover_Click(object sender, RoutedEventArgs e)
        {
            EquipmentHandoverList frmEqHandoverList = new EquipmentHandoverList();
            ShowWindow(frmEqHandoverList);
        }

        private void btnEqStatusNote_Click(object sender, RoutedEventArgs e)
        {
            EquipmentStatusNoteBookListView frmEqStatusNote = new EquipmentStatusNoteBookListView();
            ShowWindow(frmEqStatusNote);
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnEqReturning_Click(object sender, RoutedEventArgs e)
        {
            EquipmentReturningList frmEqReturning = new EquipmentReturningList();
            ShowWindow(frmEqReturning);
        }
    }
}