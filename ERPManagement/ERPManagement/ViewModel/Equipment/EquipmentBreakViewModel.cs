using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentBreakDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private DateTime breakDownDate;
        private String note, advise, statusName;
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
        public String StatusName
        {
            get { return statusName; }
            set
            {
                if (statusName != value)
                {
                    statusName = value;
                    RaisePropertyChanged("StatusName");
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
        #region Variables
        private Int32 companyID, assignment, repairer;
        private String companyName;
        private DateTime repairDate, recvInfoDate;
        private String advise;
        #endregion

        #region Properties
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

        #region Xử lí của tung tâm
        /// <summary>
        /// Ngày nhận báo hỏng
        /// </summary>
        public DateTime RecvInfoDate
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
        public DateTime RepairDate
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
    }
}