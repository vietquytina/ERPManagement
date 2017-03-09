using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;
using ERPManagement.View.List;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "Department")]
    public class DepartmentViewModel : ListViewModel
    {
        public static IEnumerable<DepartmentViewModel> GetDepartments()
        {
            var departments = from p in db.Departments
                              select p;
            List<DepartmentViewModel> departmentvms = new List<DepartmentViewModel>();
            foreach (var department in departments)
            {
                DepartmentViewModel departmentvm = new DepartmentViewModel();
                departmentvm.departmentID = department.DepartmentID;
                departmentvm.Code = department.Code;
                departmentvm.Name = department.Name;
                departmentvm.Note = department.Note;
                departmentvm.CompanyID = department.CompanyID;
                departmentvm.isInserted = false;
                departmentvms.Add(departmentvm);
            }
            return departmentvms;
        }

        public static DepartmentViewModel GetDepartment(Int32 departmentID)
        {
            var department = db.Departments.SingleOrDefault(m => m.DepartmentID == departmentID);
            if (department == null)
                return null;
            DepartmentViewModel departmentvm = new DepartmentViewModel();
            departmentvm.departmentID = department.DepartmentID;
            departmentvm.Code = department.Code;
            departmentvm.Name = department.Name;
            departmentvm.Note = department.Note;
            departmentvm.CompanyID = department.CompanyID;
            departmentvm.isInserted = false;
            return departmentvm;
        }

        #region Variables
        private Int32 departmentID, companyID;
        #endregion

        #region Properties
        public Int32 DepartmentID
        {
            get { return departmentID; }
        }

        public Int32 CompanyID
        {
            get { return companyID; }
            set
            {
                if (companyID != value)
                {
                    companyID = value;
                    RaisePropertyChanged("CompanyID");
                }
            }
        }

        public IEnumerable<CompanyViewModel> Companies { get; set; }
        #endregion

        public DepartmentViewModel() : base()
        {
            Companies = (App.Current as App).Companies.Items;
        }

        protected override void Save(RadWindow window)
        {
            Department department = null;
            if(isInserted)
            {
                department = new Department();
                db.Departments.InsertOnSubmit(department);
            }
            else
            {
                department = db.Departments.SingleOrDefault(m => m.DepartmentID == DepartmentID);
            }
            if (department != null)
            {
                department.Code = Code;
                department.Name = Name;
                department.Note = Note;
                department.Company = db.Companies.Single(m => m.CompanyID == CompanyID);
                db.SubmitChanges();
                departmentID = department.DepartmentID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override bool Delete()
        {
            try
            {
                Department department= db.Departments.SingleOrDefault(m => m.DepartmentID == DepartmentID);
                db.Departments.DeleteOnSubmit(department);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            DepartmentView frmDepartment = new DepartmentView();
            DepartmentViewModel departmentvm = GetDepartment(DepartmentID);
            departmentvm.ItemAction += new ActionEventHandler(Departmentvm_ItemAction);
            frmDepartment.DataContext = departmentvm;
            frmDepartment.ShowDialog();
        }

        private void Departmentvm_ItemAction(object sender, ActionEventArgs e)
        {
            DepartmentViewModel departmentvm = (DepartmentViewModel)sender;
            Code = departmentvm.Code;
            Name = departmentvm.Name;
            Note = departmentvm.Note;
            CompanyID = departmentvm.CompanyID;
        }
    }
}