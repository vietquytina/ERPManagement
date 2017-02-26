using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Employee
{
    class EmployeeListViewModel : ItemListViewModel<EmployeeViewModel>
    {
        public EmployeeListViewModel() : base()
        {
            foreach (var employee in EmployeeViewModel.GetEmployees())
            {
                Items.Add(employee);
                employee.Deleted += new System.Windows.RoutedEventHandler(Employee_Deleted);
            }
        }

        private void Employee_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EmployeeViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.List.EmployeeView frmEmployee = new View.List.EmployeeView();
            EmployeeViewModel employeevm = new EmployeeViewModel();
            employeevm.ItemAction += new ActionEventHandler(Employeevm_ItemAction);
            frmEmployee.DataContext = employeevm;
            frmEmployee.ShowDialog();
        }

        private void Employeevm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((EmployeeViewModel)sender);
            }
        }
    }
}