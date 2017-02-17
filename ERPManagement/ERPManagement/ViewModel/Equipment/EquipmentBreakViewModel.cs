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
        private Int32 companyID;
        private String companyName;
        private DateTime repairDate;
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
        public String Result { get; set; }
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

        public EquipmentBreakViewModel() : base()
        {
            RepairDate = DateTime.Now;
        }
    }
}