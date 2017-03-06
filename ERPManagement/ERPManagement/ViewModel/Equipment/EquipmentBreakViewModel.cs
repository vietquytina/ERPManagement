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
        private String advise, currentStatus, employeeAdvise;
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
                    RaisePropertyChanged("CompanyID");
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

        public Int32 EquipmentID
        {
            get { return equipmentID; }
            set
            {
                if (equipmentID != value)
                {
                    equipmentID = value;
                    RaisePropertyChanged("EquipmentID");
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
                    RaisePropertyChanged("Assignment");
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
                    RaisePropertyChanged("Repairer");
                }
            }
        }
        #endregion
        #endregion

        public EquipmentBreakViewModel() : base()
        {
            RepairDate = DateTime.Now;
        }

        protected override void Save(RadWindow window)
        {
            EquipmentBreak eqBreak = null;
            if (isInserted)
            {
                eqBreak = new EquipmentBreak();
                db.EquipmentBreaks.InsertOnSubmit(eqBreak);
                db.SubmitChanges();
            }
            else
            {
                eqBreak = db.EquipmentBreaks.SingleOrDefault(m => m.ID == ID);
            }
            if (eqBreak != null)
            {
                if (isInserted || eqBreak.EmployeeID == App.Employee.UserID)
                {
                    eqBreak.CompanyID = CompanyID;
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
    }
}