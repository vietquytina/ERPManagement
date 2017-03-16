using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method= "EquipmentBreak")]
    public class EquipmentBreakViewModel : EquipmentViewModel
    {
        public static IEnumerable<EquipmentBreakViewModel> GetEquipmentBreaks()
        {
            List<EquipmentBreakViewModel> equipmentBreakvms = new List<EquipmentBreakViewModel>();
            var equipmentBreaks = from p in db.EquipmentBreaks
                                  select p;
            foreach (var equipmentBreak in equipmentBreaks)
            {
                EquipmentBreakViewModel equipmentBreakvm = new EquipmentBreakViewModel();
                equipmentBreakvm.id = equipmentBreak.ID;
                equipmentBreakvm.isInserted = false;
                equipmentBreakvms.Add(equipmentBreakvm);
            }
            return equipmentBreakvms;
        }

        public static EquipmentBreakViewModel GetEquipmentBreak(Int32 id)
        {
            var equipmentBreak = db.EquipmentBreaks.SingleOrDefault(m => m.ID == id);
            if (equipmentBreak == null)
                return null;
            EquipmentBreakViewModel equipmentBreakvm = new EquipmentBreakViewModel();
            equipmentBreakvm.id = equipmentBreak.ID;

            return equipmentBreakvm;
        }

        #region Variables
        private Int32 id;
        private Int32 companyID, assignment, repairer, departmentID, equipmentID;
        private DateTime? recvInfoDate, repairDate;
        private String companyName, departmentName, equipmentName, empName, advise, currentStatus, employeeAdvise;
        private String assignmentName, repairerName;
        #endregion

        #region Properties
        public Int32 ID
        {
            get { return id; }
        }

        public Int32 EmployeeID { get; set; }

        public Int32 CompanyID
        {
            get { return companyID; }
            set
            {
                if (companyID != value)
                {
                    companyID = value;
                    CompanyName = ConvertCollection.ConvertCompany(companyID);
                    RaisePropertyChanged("CompanyID");
                }
            }
        }

        public String CompanyName
        {
            get { return companyName; }
            set
            {
                if (companyName != value)
                {
                    companyName = value;
                    RaisePropertyChanged("CompanyName");
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
                    DepartmentName = ConvertCollection.ConvertDepartment(departmentID);
                    RaisePropertyChanged("DepartmentID");
                }
            }
        }

        public String DepartmentName
        {
            get { return departmentName; }
            set
            {
                if (departmentName != value)
                {
                    departmentName = value;
                    RaisePropertyChanged("DepartmentName");
                }
            }
        }

        public Int32 EquipmentID
        {
            get { return equipmentID; }
            set
            {
                if (equipmentID != value)
                {
                    equipmentID = value;
                    EquipmentName = ConvertCollection.ConvertEquipment(equipmentID, ViewModel.Converter.ConvertInfomation.Name);
                    Number = ConvertCollection.ConvertEquipment(equipmentID, ViewModel.Converter.ConvertInfomation.Serial);
                    RaisePropertyChanged("EquipmentID");
                }
            }
        }

        public String EquipmentName
        {
            get { return equipmentName; }
            set
            {
                if (equipmentName != value)
                {
                    equipmentName = value;
                    RaisePropertyChanged("EquipmentName");
                }
            }
        }

        public String CurrentStatus
        {
            get { return currentStatus; }
            set
            {
                if (currentStatus != value)
                {
                    currentStatus = value;
                    RaisePropertyChanged("CurrentStatus");
                }
            }
        }

        public String EmployeeAdvise
        {
            get { return employeeAdvise; }
            set
            {
                if (employeeAdvise != value)
                {
                    employeeAdvise = value;
                    RaisePropertyChanged("EmployeeAdvise");
                }
            }
        }

        #region Xử lí của tung tâm
        /// <summary>
        /// Ngày nhận báo hỏng
        /// </summary>
        public DateTime? RecvInfoDate
        {
            get { return recvInfoDate; }
            set
            {
                if (recvInfoDate != value)
                {
                    recvInfoDate = value;
                    RaisePropertyChanged("RecvInfoDate");
                }
            }
        }

        /// <summary>
        /// Ngày xử lý
        /// </summary>
        public DateTime? RepairDate
        {
            get { return repairDate; }
            set
            {
                if (repairDate != value)
                {
                    repairDate = value;
                    RaisePropertyChanged("RepairDate");
                }
            }
        }

        /// <summary>
        /// Kết quả
        /// </summary>
        public String Result { get; set; }
        
        /// <summary>
        /// Đề xuất
        /// </summary>
        public String Advise
        {
            get { return advise; }
            set
            {
                if (advise != value)
                {
                    advise = value;
                    RaisePropertyChanged("Advise");
                }
            }
        }
        
        /// <summary>
        /// Người giao nhiệm vụ
        /// </summary>
        public Int32 Assignment
        {
            get { return assignment; }
            set
            {
                if (assignment != value)
                {
                    assignment = value;
                    AssignmentName = ConvertCollection.ConvertEmployee(Assignment, ViewModel.Converter.EmployeeConvertation.Name);
                    RaisePropertyChanged("Assignment");
                }
            }
        }
        
        public String AssignmentName
        {
            get { return assignmentName; }
            set
            {
                if (assignmentName != value)
                {
                    assignmentName = value;
                    RaisePropertyChanged("AssignmentName");
                }
            }
        }

        /// <summary>
        /// Người thực hiện
        /// </summary>
        public Int32 Repairer
        {
            get { return repairer; }
            set
            {
                if (repairer != value)
                {
                    repairer = value;
                    RepairerName = ConvertCollection.ConvertEmployee(Repairer);
                    RaisePropertyChanged("Repairer");
                }
            }
        }

        public String RepairerName
        {
            get { return repairerName; }
            set
            {
                if (repairerName != value)
                {
                    repairerName = value;
                    RaisePropertyChanged("RepairerName");
                }
            }
        }
        #endregion

        public IEnumerable<List.EquipmentViewModel> Equipments { get; set; }
        public IEnumerable<Employee.EmployeeViewModel> Employees { get; set; }
        #endregion

        public EquipmentBreakViewModel() : base()
        {
            RepairDate = DateTime.Now;
            Equipments = (App.Current as App).Equipments.Items;
            Employees = (App.Current as App).Employees.Items;
        }

        protected override void Save(RadWindow window)
        {
            EquipmentBreak eqBreak = null;
            if (isInserted)
            {
                eqBreak = new EquipmentBreak();
                db.EquipmentBreaks.InsertOnSubmit(eqBreak);
            }
            else
            {
                eqBreak = db.EquipmentBreaks.SingleOrDefault(m => m.ID == ID);
            }
            if (eqBreak != null)
            {
                if (isInserted || eqBreak.EmployeeID == App.Employee.UserID)
                {
                    eqBreak.CompanyID = App.Employee.CompanyID;
                    eqBreak.DepartmentID = App.Employee.DepartmentID;
                    eqBreak.Date = Date;
                    eqBreak.EmployeeID = App.Employee.UserID;
                }
                eqBreak.EquipmentID = EquipmentID;
                eqBreak.EmployeeID = App.Employee.UserID;
                eqBreak.CurrentStatus = CurrentStatus;
                eqBreak.EmployeeAdvise = EmployeeAdvise;
                eqBreak.RecvInfoDate = RecvInfoDate;
                eqBreak.RepairDate = RepairDate;
                eqBreak.Result = Result;
                eqBreak.Advise = Advise;
                eqBreak.StatusID = StatusID;
                db.SubmitChanges();
                id = eqBreak.ID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override bool Delete()
        {
            try
            {
                EquipmentBreak eqBreak = db.EquipmentBreaks.SingleOrDefault(m => m.ID == ID);
                db.EquipmentBreaks.DeleteOnSubmit(eqBreak);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            View.Profession.EquipmentBreakDownView frmEquipmentBreakDown = new View.Profession.EquipmentBreakDownView();
            EquipmentBreakViewModel equipmentBreakvm = GetEquipmentBreak(ID);
            equipmentBreakvm.ItemAction += new ActionEventHandler(EquipmentBreakvm_ItemAction);
            frmEquipmentBreakDown.DataContext = equipmentBreakvm;
            frmEquipmentBreakDown.ShowDialog();
        }

        private void EquipmentBreakvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Edit)
            {
                EquipmentBreakViewModel equipmentBreakvm = (EquipmentBreakViewModel)sender;
                EquipmentID = equipmentBreakvm.EquipmentID;
                CurrentStatus = equipmentBreakvm.CurrentStatus;
                EmployeeAdvise = equipmentBreakvm.EmployeeAdvise;
                Repairer = equipmentBreakvm.Repairer;
                RecvInfoDate = equipmentBreakvm.RecvInfoDate;
                RepairDate = equipmentBreakvm.RepairDate;
                Result = equipmentBreakvm.Result;
                Advise = equipmentBreakvm.Advise;
                StatusID = equipmentBreakvm.StatusID;
            }
        }

        protected override void ExportToReport()
        {
            Data.EquipmentBreak eqBreakDS = new Data.EquipmentBreak();
            ReportWindow rptWnd = new ReportWindow();
            rptWnd.ReportPath = "Report/EquipmentBreak.rdlc";
            String company = ConvertCollection.ConvertCompany(App.Employee.CompanyID);
            String serial = ConvertCollection.ConvertEquipment(EquipmentID, ViewModel.Converter.ConvertInfomation.Serial);
            eqBreakDS._EquipmentBreak.AddEquipmentBreakRow(ID, company, Date, EquipmentName, serial, DateTime.Now, CurrentStatus, EmployeeAdvise, AssignmentName, RepairerName, Result, Advise, RecvInfoDate.HasValue ? RecvInfoDate.Value.ToString("dd/MM/yyyy") : "", RepairDate.HasValue ? RepairDate.Value.ToString("dd/MM/yyyy") : "");
            rptWnd.AddReportSource("EquipmentBreak", eqBreakDS);
            rptWnd.RefreshReport();
            rptWnd.ShowDialog();
        }
    }
}