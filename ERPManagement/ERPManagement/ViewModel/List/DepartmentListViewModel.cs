using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class DepartmentListViewModel : ItemListViewModel<DepartmentViewModel>
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
    }
}