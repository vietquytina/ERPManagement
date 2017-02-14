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
        private String equipmentName;
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
                    equipmentID = value;
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
        #endregion

        public EquipmentDetailViewModel()
        {
            DetailID = Guid.NewGuid();
            Index = -1;
        }
    }
}