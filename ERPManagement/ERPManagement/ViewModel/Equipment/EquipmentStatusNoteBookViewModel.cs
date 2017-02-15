using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentStatusNoteBookDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 losingBefore, duffBefore, losingAfter, duffAfter, diffBefore, diffAfter;
        private String note;
        #endregion

        #region Properties
        public Int32 LosingBefore
        {
            get { return losingBefore; }
            set
            {
                if (losingBefore != value)
                {
                    losingBefore = value;
                    DiffBefore = LosingAfter - LosingBefore;
                    RaisePropertyChanged("LosingBefore");
                }
            }
        }
        public Int32 DuffBefore
        {
            get { return duffBefore; }
            set
            {
                if (duffBefore != value)
                {
                    duffBefore = value;
                    DiffAfter = DuffAfter - DuffBefore;
                    RaisePropertyChanged("DuffBefore");
                }
            }
        }
        public Int32 LosingAfter
        {
            get { return losingAfter; }
            set
            {
                if (losingAfter != value)
                {
                    losingAfter = value;
                    DiffBefore = LosingAfter - LosingBefore;
                    RaisePropertyChanged("LosingAfter");
                }
            }
        }
        public Int32 DuffAfter
        {
            get { return duffAfter; }
            set
            {
                if (duffAfter != value)
                {
                    duffAfter = value;
                    DiffAfter = DuffAfter - DuffBefore;
                    RaisePropertyChanged("DuffAfter");
                }
            }
        }
        public Int32 DiffBefore
        {
            get { return diffBefore; }
            set
            {
                if (diffBefore != value)
                {
                    diffBefore = value;
                    RaisePropertyChanged("DiffBefore");
                }
            }
        }
        public Int32 DiffAfter
        {
            get { return diffAfter; }
            set
            {
                if (diffAfter != value)
                {
                    diffAfter = value;
                    RaisePropertyChanged("DiffAfter");
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
        #endregion

        public EquipmentStatusNoteBookDetailViewModel() : base()
        {

        }
    }

    class EquipmentStatusNoteBookViewModel : EquipmentViewModel
    {
        #region Variables
        private Int32 noteID, wareHouseID;
        private DateTime noteDate;
        private String wareHouseName;
        #endregion

        #region Properties
        public Int32 NoteID
        {
            get { return noteID; }
        }
        public DateTime NoteDate
        {
            get { return noteDate; }
            set
            {
                if (noteDate != value)
                {
                    noteDate = value;
                    RaisePropertyChanged("NoteDate");
                }
            }
        }
        public Int32 WareHouseID
        {
            get { return wareHouseID; }
            set
            {
                if (wareHouseID != value)
                {
                    wareHouseID = value;
                    RaisePropertyChanged("WareHouseID");
                }
            }
        }
        public String WareHouseName
        {
            get { return wareHouseName; }
            set
            {
                if (wareHouseName != value)
                {
                    wareHouseName = value;
                    RaisePropertyChanged("WareHouseName");
                }
            }
        }
        public ObservableCollection<EquipmentStatusNoteBookDetailViewModel> Details { get; set; }
        #endregion

        public EquipmentStatusNoteBookViewModel() : base()
        {
            NoteDate = DateTime.Now;
            Details = new ObservableCollection<EquipmentStatusNoteBookDetailViewModel>();
        }

        protected override void Save(RadWindow window)
        {
        }

        protected override bool Delete()
        {
            return base.Delete();
        }

        protected override void Edit()
        {

        }
    }
}