using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "Department")]
    public class DepartmentListViewModel : ItemListViewModel<DepartmentViewModel>
    {
        public DepartmentListViewModel() : base()
        {
            foreach (var department in DepartmentViewModel.GetDepartments())
            {
                Items.Add(department);
                department.Deleted += new System.Windows.RoutedEventHandler(Department_Deleted);
            }
        }

        private void Department_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((DepartmentViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            ERPManagement.View.List.DepartmentView frmDepartment = new View.List.DepartmentView();
            DepartmentViewModel departmentvm = new DepartmentViewModel();
            departmentvm.ItemAction += new ActionEventHandler(Departmentvm_ItemAction);
            frmDepartment.DataContext = departmentvm;
            frmDepartment.ShowDialog();
        }

        private void Departmentvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Edit)
            {
                DepartmentViewModel departmentvm = (DepartmentViewModel)sender;
                Items.Add(departmentvm);
            }
        }
    }
}