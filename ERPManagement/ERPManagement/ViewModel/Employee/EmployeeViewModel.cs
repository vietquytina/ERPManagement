using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.Employee
{
    [Authorize.Authorize(Method = "Employee")]
    public class EmployeeViewModel : List.ListViewModel
    {
        public static Boolean Login(String userName, String passWord)
        {
            var emp = db.Employees.SingleOrDefault(m => m.Code == userName && m.Password == passWord);
            if (emp == null)
                return false;
            App.Employee = new EmployeePermissionViewModel();
            App.Employee.UserID = emp.EmployeeID;
            App.Employee.CompanyID = emp.Department.CompanyID;
            App.Employee.Name = emp.FamilyName + " " + emp.Name;
            foreach (var permission in emp.Permissions)
            {
                PermissionViewModel permissionvm = new PermissionViewModel();
                permissionvm.MethodName = permission.Method.Name;
                permissionvm.CanRead = permission.CanRead;
                permissionvm.CanWrite = permission.CanWrite;
                permissionvm.CanAccept = permission.CanAccept;
                App.Employee.Permissions.Add(permissionvm);
            }
            return true;
        }

        public static IEnumerable<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> employeevms = new List<EmployeeViewModel>();
            var employees = from p in db.Employees
                            select p;
            foreach (var employee in employees)
            {
                EmployeeViewModel employeevm = new EmployeeViewModel();
                employeevm.employeeID = employee.EmployeeID;
                employeevm.Code = employee.Code;
                employeevm.FamilyName = employee.FamilyName;
                employeevm.Name = employee.Name;
                employeevm.Sex = employee.Sex ? 0 : 1;
                employeevm.BirthDate = employee.BirthDate;
                employeevm.BirthPlace = employee.BirthPlace;
                employeevm.Ethnic = employee.Ethnic;
                employeevm.PhoneNumber = employee.PhoneNumber;
                employeevm.Email = employee.Email;
                employeevm.RegencyID = employee.RegencyID;
                employeevm.DepartmentID = employee.DepartmentID;
                employeevm.isInserted = false;
                employeevms.Add(employeevm);
            }
            return employeevms;

        }

        public static EmployeeViewModel GetEmployee(Int32 employeeID)
        {
            var employee = db.Employees.SingleOrDefault(m => m.EmployeeID == employeeID);
            if (employee == null)
                return null;
            EmployeeViewModel employeevm = new EmployeeViewModel();
            employeevm.employeeID = employee.EmployeeID;
            employeevm.Code = employee.Code;
            employeevm.FamilyName = employee.FamilyName;
            employeevm.Name = employee.Name;
            employeevm.Sex = employee.Sex ? 0 : 1;
            employeevm.BirthDate = employee.BirthDate;
            employeevm.BirthPlace = employee.BirthPlace;
            employeevm.Ethnic = employee.Ethnic;
            employeevm.PhoneNumber = employee.PhoneNumber;
            employeevm.Email = employee.Email;
            employeevm.RegencyID = employee.RegencyID;
            employeevm.DepartmentID = employee.DepartmentID;
            employeevm.isInserted = false;
            return employeevm;
        }

        #region Variables
        private Int32 employeeID;
        private String familyName, fullName, name, birthPlace, ethnic, phoneNumber, email;
        private Int32 sex, regencyID, departmentID;
        private DateTime birthDate;
        private Byte[] avatarBuff = null;
        #endregion

        #region Properties
        public Int32 EmployeeID
        {
            get { return employeeID; }
        }

        public String FamilyName
        {
            get { return familyName; }
            set
            {
                if (familyName != value)
                {
                    familyName = value;
                    FullName = FamilyName + " " + Name;
                    RaisePropertyChanged("FamilyName");
                }
            }
        }

        public String FullName
        {
            get { return fullName; }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    RaisePropertyChanged("FullName");
                }
            }
        }

        public Int32 Sex
        {
            get { return sex; }
            set
            {
                if (sex != value)
                {
                    sex = value;
                    RaisePropertyChanged("Sex");
                }
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (birthDate != value)
                {
                    birthDate = value;
                    RaisePropertyChanged("BirthDate");
                }
            }
        }

        public String BirthPlace
        {
            get { return birthPlace; }
            set
            {
                if (birthPlace != value)
                {
                    birthPlace = value;
                    RaisePropertyChanged("BirthPlace");
                }
            }
        }

        public String Ethnic
        {
            get { return ethnic; }
            set
            {
                if (ethnic != value)
                {
                    ethnic = value;
                    RaisePropertyChanged("Ethnic");
                }
            }
        }

        public String PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    RaisePropertyChanged("PhoneNumber");
                }
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
                }
            }
        }

        public Int32 RegencyID
        {
            get { return regencyID; }
            set
            {
                if (regencyID != value)
                {
                    regencyID = value;
                    RaisePropertyChanged("RegencyID");
                }
            }
        }

        public Int32 DepartmentID
        {
            get { return departmentID; }
            set
            {
                if (departmentID != value)
                {
                    departmentID = value;
                    RaisePropertyChanged("DepartmentID");
                }
            }
        }

        public IEnumerable<List.RegencyViewModel> Regencies { get; set; }

        public IEnumerable<List.DepartmentViewModel> Departments { get; set; }
        #endregion

        public EmployeeViewModel() : base()
        {
            BirthDate = DateTime.Now;
            Regencies = (App.Current as App).Regencies.Items;
            Departments = (App.Current as App).Departments.Items;
        }

        protected override void Save(RadWindow window)
        {
            Model.Employee emp = null;
            if (isInserted)
            {
                emp = new Model.Employee();
                db.Employees.InsertOnSubmit(emp);
            }
            else
            {
                emp = db.Employees.SingleOrDefault(m => m.EmployeeID == EmployeeID);
            }
            if (emp != null)
            {
                emp.Code = Code;
                emp.FamilyName = FamilyName;
                emp.Name = Name;
                emp.Sex = Sex == 0;
                emp.BirthDate = BirthDate;
                emp.Ethnic = Ethnic;
                emp.PhoneNumber = PhoneNumber;
                emp.Email = Email;
                emp.Regency = db.Regencies.Single(m => m.RegencyID == RegencyID);
                emp.Department = db.Departments.Single(m => m.DepartmentID == DepartmentID);
                if (avatarBuff != null)
                    emp.Avatar = new System.Data.Linq.Binary(avatarBuff);
                db.SubmitChanges();
                employeeID = emp.EmployeeID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override bool Delete()
        {
            try
            {
                Model.Employee emp = db.Employees.SingleOrDefault(m => m.EmployeeID == EmployeeID);
                db.Employees.DeleteOnSubmit(emp);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            View.List.EmployeeView frmEmployee = new View.List.EmployeeView();
            EmployeeViewModel empvm = GetEmployee(EmployeeID);
            empvm.ItemAction += new ActionEventHandler(Empvm_ItemAction);
            frmEmployee.DataContext = empvm;
            frmEmployee.ShowDialog();
        }

        private void Empvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Edit)
            {
                EmployeeViewModel empvm = (EmployeeViewModel)sender;
                Code = empvm.Code;
                Name = empvm.Name;
                Sex = empvm.Sex;
                BirthDate = empvm.BirthDate;
                BirthPlace = empvm.BirthPlace;
                Ethnic = empvm.Ethnic;
                PhoneNumber = empvm.PhoneNumber;
                Email = empvm.Email;
                RegencyID = empvm.RegencyID;
                DepartmentID = empvm.DepartmentID;
            }
        }

        public void SetAvatar(FileStream fs)
        {
            avatarBuff = new Byte[fs.Length];
            fs.Read(avatarBuff, 0, (int)fs.Length);
        }
    }
}