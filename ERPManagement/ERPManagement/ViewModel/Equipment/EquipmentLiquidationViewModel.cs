using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentLiquidationDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 quantity, statusID;
        private String reason, statusName;
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
        public String Reason
        {
            get { return reason; }
            set
            {
                if (reason != value)
                {
                    reason = value;
                    RaisePropertyChanged("Reason");
                }
            }
        }
        #endregion

        public EquipmentLiquidationDetailViewModel() : base()
        {
            quantity = 0;
        }
    }

    class EquipmentLiquidationViewModel : EquipmentViewModel
    {
        #region Variables
        private Int32 equipmentLiquidationID;
        private String place = null;
        #endregion

        #region Properties
        public Int32 EquipmentLiquidationID
        {
            get { return equipmentLiquidationID; }
        }
        public String Place
        {
            get { return place; }
            set
            {
                if (place != value)
                {
                    place = value;
                    RaisePropertyChanged("Place");
                }
            }
        }
        public ObservableCollection<EquipmentLiquidationDetailViewModel> Details { get; set; }
        #endregion

        public EquipmentLiquidationViewModel() : base()
        {
            Details = new ObservableCollection<EquipmentLiquidationDetailViewModel>();
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