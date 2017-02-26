using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Employee
{
    public class PermissionViewModel
    {
        public String MethodName { get; set; }
        public Boolean CanRead { get; set; }
        public Boolean CanWrite { get; set; }
        public Boolean CanDelete { get; set; }
    }

    [Authorize.Authorize(Method = "Employee")]
    public class EmployeePermissionViewModel : BaseViewModel
    {
        public Int32 UserID { get; set; }
        public String Name { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }

        public EmployeePermissionViewModel()
        {
            Permissions = new List<PermissionViewModel>();
        }
    }
}