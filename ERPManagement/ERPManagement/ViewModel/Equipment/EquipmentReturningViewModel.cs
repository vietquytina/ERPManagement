using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentReturningDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private String number, reason, fundingSourceName;
        private Decimal price;
        private Int32 fundingSourceID;
        #endregion

        #region Properties
        public String Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    RaisePropertyChanged("Number");
                }
            }
        }
        public Decimal Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    RaisePropertyChanged("Price");
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
        public Int32 FundingSourceID
        {
            get { return fundingSourceID; }
            set
            {
                if (fundingSourceID != value)
                {
                    fundingSourceID = value;
                    RaisePropertyChanged("FundingSourceID");
                }
            }
        }
        public String FundingSourceName
        {
            get { return fundingSourceName; }
            set
            {
                if (fundingSourceName != value)
                {
                    fundingSourceName = value;
                    RaisePropertyChanged("FundingSourceName");
                }
            }
        }
        #endregion

        public EquipmentReturningDetailViewModel() : base()
        {
        }

        protected override void OnEquipmentChanged(int oldEquipment, int newEquipment)
        {

        }
    }

    class EquipmentReturningViewModel : EquipmentViewModel
    {
        #region Variables
        private Int32 equipmentReturningID = 0;
        #endregion

        #region Properties
        public Int32 EquipmentReturningID
        {
            get { return equipmentReturningID; }
        }
        public ObservableCollection<EquipmentReturningDetailViewModel> Details { get; set; }
        #endregion

        public EquipmentReturningViewModel() : base()
        {
            Details = new ObservableCollection<EquipmentReturningDetailViewModel>();
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