using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentDetailViewModel : BaseNotify
    {
        #region Variables
        private Int32 equipmentID;
        private String equipmentName, unitMeasure;
        private Int32 restQty = 0;
        #endregion

        #region Properties
        public Guid DetailID { get; set; }

        public Int32 Index { get; set; }

        public Int32 EquipmentID
        {
            get { return equipmentID; }
            set
            {
                if (equipmentID != value)
                {
                    var oldEquipment = equipmentID;
                    equipmentID = value;
                    OnEquipmentChanged(oldEquipment, equipmentID);
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

        public String UnitMeasure
        {
            get { return unitMeasure; }
            set
            {
                if (unitMeasure != value)
                {
                    unitMeasure = value;
                    RaisePropertyChanged("UnitMeasure");
                }
            }
        }

        public Int32 RestQuantity
        {
            get { return restQty; }
            set
            {
                if (restQty != value)
                {
                    restQty = value;
                    RaisePropertyChanged("RestQuantity");
                }
            }
        }
        #endregion

        public EquipmentDetailViewModel()
        {
            DetailID = Guid.NewGuid();
            Index = -1;
        }

        protected virtual void OnEquipmentChanged(int oldEquipment, int newEquipment)
        {
        }
    }
}