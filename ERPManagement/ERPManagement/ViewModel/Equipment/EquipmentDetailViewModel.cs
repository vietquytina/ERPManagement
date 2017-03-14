using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    public class EquipmentChangedEventArgs : EventArgs
    {
        public Int32 OldEquipmentID { get; set; }
        public Int32 NewEquipmentID { get; set; }
    }

    public delegate void EquipmentChangedEventHandler(object sender, EquipmentChangedEventArgs e);

    public class EquipmentIndexViewModel : BaseNotify
    {
        public Guid DetailID { get; set; }
        public Int32 Index { get; set; }

        public EquipmentIndexViewModel()
        {
            DetailID = Guid.NewGuid();
            Index = -1;
        }
    }

    public class EquipmentDetailViewModel : EquipmentIndexViewModel
    {
        #region Variables
        private Int32 equipmentID;
        private String equipmentName, unitMeasure, equipmentCode, serial;
        private Int32 restQty = 0;
        #endregion

        #region Event
        public event EquipmentChangedEventHandler EquipmentChanged;
        #endregion

        #region Properties
        public Int32 EquipmentID
        {
            get { return equipmentID; }
            set
            {
                if (equipmentID != value)
                {
                    var oldEquipment = equipmentID;
                    equipmentID = value;
                    EquipmentCode = ConvertCollection.ConvertEquipment(equipmentID, ViewModel.Converter.ConvertInfomation.Code);
                    EquipmentName = ConvertCollection.ConvertEquipment(equipmentID, ViewModel.Converter.ConvertInfomation.Name);
                    UnitMeasure = ConvertCollection.ConvertEquipment(equipmentID, ViewModel.Converter.ConvertInfomation.UnitMeasure);
                    Serial = ConvertCollection.ConvertEquipment(EquipmentID, ViewModel.Converter.ConvertInfomation.Serial);
                    if (EquipmentChanged != null)
                    {
                        EquipmentChanged(this, new EquipmentChangedEventArgs() { OldEquipmentID = oldEquipment, NewEquipmentID = equipmentID });
                    }
                    OnEquipmentChanged(oldEquipment, equipmentID);
                    RaisePropertyChanged("EquipmentID");
                }
            }
        }

        public String EquipmentCode
        {
            get { return equipmentCode; }
            set
            {
                if (equipmentCode != value)
                {
                    equipmentCode = value;
                    RaisePropertyChanged("EquipmentCode");
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

        public String Serial
        {
            get { return serial; }
            set
            {
                if (serial != value)
                {
                    serial = value;
                    RaisePropertyChanged("Serial");
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

        public EquipmentDetailViewModel() : base()
        {
            RestQuantity = 0;
        }

        protected virtual void OnEquipmentChanged(int oldEquipment, int newEquipment)
        {
        }
    }
}