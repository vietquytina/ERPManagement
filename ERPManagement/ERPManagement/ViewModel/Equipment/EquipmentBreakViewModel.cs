using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentBreakDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private DateTime breakDownDate;
        private String note, advise;
        private Int32 statusID;
        #endregion

        #region Properties
        public DateTime BreakDownDate
        {
            get { return breakDownDate; }
            set
            {
                if (breakDownDate != value)
                {
                    breakDownDate = value;
                    RaisePropertyChanged("BreakDownDate");
                }
            }
        }

        public String Note
        {
            get { return note; }
            set
            {
                if (note != value)
                {
                    note = value;
                    RaisePropertyChanged("Note");
                }
            }
        }

        public Int32 StatusID
        {
            get { return statusID; }
            set
            {
                if (statusID != value)
                {
                    statusID = value;
                    RaisePropertyChanged("StatusID");
                }
            }
        }

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
        #endregion

        public EquipmentBreakDetailViewModel() : base()
        {
            BreakDownDate = DateTime.Now;
        }
    }

    class EquipmentBreakViewModel : EquipmentViewModel
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
                equipmentBreakvm.Date = equipmentBreak.Date;
                equipmentBreakvm.CompanyID = equipmentBreak.CompanyID;
                equipmentBreakvm.EmployeeID = equipmentBreak.EmployeeID;
                equipmentBreakvm.StatusID = equipmentBreak.StatusID;
                equipmentBreakvm.Result = equipmentBreak.Result;
                equipmentBreakvm.Advise = equipmentBreak.Advise;
                equipmentBreakvm.Assignment = equipmentBreak.Assignment;
                equipmentBreakvm.Repairer = equipmentBreak.Repairer;
                equipmentBreakvm.RecvInfoDate = equipmentBreak.RecvInfoDate;
                equipmentBreakvm.RepairDate = equipmentBreak.RepairDate;
                foreach (var detail in equipmentBreak.EquipmentBreakDetails)
                {
                    EquipmentBreakDetailViewModel detailvm = new EquipmentBreakDetailViewModel();
                    detailvm.DetailID = detail.DetailID;
                    detailvm.Index = detail.Index;
                    detailvm.EquipmentID = detail.EquipmentID;
                    detailvm.Note = detail.Note;
                    detailvm.Advise = detail.Advise;
                    equipmentBreakvm.Details.Add(detailvm);
                }
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
            equipmentBreakvm.Date = equipmentBreak.Date;
            equipmentBreakvm.CompanyID = equipmentBreak.CompanyID;
            equipmentBreakvm.EmployeeID = equipmentBreak.EmployeeID;
            equipmentBreakvm.StatusID = equipmentBreak.StatusID;
            equipmentBreakvm.Result = equipmentBreak.Result;
            equipmentBreakvm.Advise = equipmentBreak.Advise;
            equipmentBreakvm.Assignment = equipmentBreak.Assignment;
            equipmentBreakvm.Repairer = equipmentBreak.Repairer;
            equipmentBreakvm.RecvInfoDate = equipmentBreak.RecvInfoDate;
            equipmentBreakvm.RepairDate = equipmentBreak.RepairDate;
            foreach (var detail in equipmentBreak.EquipmentBreakDetails)
            {
                EquipmentBreakDetailViewModel detailvm = new EquipmentBreakDetailViewModel();
                detailvm.DetailID = detail.DetailID;
                detailvm.Index = detail.Index;
                detailvm.EquipmentID = detail.EquipmentID;
                detailvm.Note = detail.Note;
                detailvm.Advise = detail.Advise;
                equipmentBreakvm.Details.Add(detailvm);
            }
            equipmentBreakvm.isInserted = false;
            return equipmentBreakvm;
        }

        #region Variables
        private Int32 id;
        private Int32 companyID, assignment, repairer;
        private DateTime? recvInfoDate, repairDate;
        private String advise;
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
        
        public ObservableCollection<EquipmentBreakDetailViewModel> Details { get; set; }
        #endregion

        public EquipmentBreakViewModel() : base()
        {
            RepairDate = DateTime.Now;
            Details = new ObservableCollection<EquipmentBreakDetailViewModel>();
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
                eqBreak.Date = Date;
                eqBreak.CompanyID = CompanyID;
                eqBreak.EmployeeID = EmployeeID;
                eqBreak.StatusID = StatusID;
                eqBreak.Result = Result;
                eqBreak.Advise = Advise;
                eqBreak.Assignment = Assignment;
                eqBreak.Repairer = Repairer;
                eqBreak.RecvInfoDate = RecvInfoDate;
                eqBreak.RepairDate = RepairDate;
                db.SubmitChanges();
                id = eqBreak.ID;
                SyncIndex(Details);
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

        }
    }
}