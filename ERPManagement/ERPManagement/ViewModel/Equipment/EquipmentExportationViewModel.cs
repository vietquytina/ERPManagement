using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentExportationDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 quantity, statusID;
        private String statusName, note;
        #endregion

        #region Properties
        public Int32 Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    RaisePropertyChanged("Quantity");
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

        public EquipmentExportationDetailViewModel() : base()
        {

        }
    }

    class EquipmentExportationViewModel : EquipmentViewModel
    {
        #region Variables
        private Int32 sender;
        private String senderName;
        private Int32 equipmentExportationID = 0;
        #endregion

        #region Properties
        public Int32 EquipmentExportationID
        {
            get { return equipmentExportationID; }
        }
        public Int32 Sender
        {
            get { return sender; }
            set
            {
                if (sender != value)
                {
                    sender = value;
                    RaisePropertyChanged("Sender");
                }
            }
        }
        public String SenderName
        {
            get { return senderName; }
            set
            {
                if (senderName != value)
                {
                    senderName = value;
                    RaisePropertyChanged("SenderName");
                }
            }
        }
        public ObservableCollection<EquipmentExportationDetailViewModel> Details { get; set; }
        #endregion

        public EquipmentExportationViewModel()
        {
            Details = new ObservableCollection<EquipmentExportationDetailViewModel>();
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