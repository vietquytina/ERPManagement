using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    public class EquipmentViewModel : ListViewModel
    {
        public static IEnumerable<EquipmentViewModel> GetEquipments()
        {
            var equipments = from p in db.Equipments
                             select p;
            List<EquipmentViewModel> equipmentvms = new List<EquipmentViewModel>();
            foreach (var equipment in equipments)
            {
                EquipmentViewModel equipmentvm = new EquipmentViewModel();
                equipmentvm.equipmentID = equipment.EquipmentID;
                equipmentvm.Code = equipment.Code;
                equipmentvm.Name = equipment.Name;
                equipmentvm.EquipmentTypeID = equipment.EquipmentTypeID;
                equipmentvm.UnitMeasureID = equipment.UnitMeasureID;
                equipmentvm.Description = equipment.Description;
                equipmentvm.isInserted = false;
                equipmentvms.Add(equipmentvm);
            }
            return equipmentvms;
        }

        public static EquipmentViewModel GetEquipment(Int32 equipmentID)
        {
            EquipmentViewModel equipment = new EquipmentViewModel();
            return equipment;
        }

        #region Variables
        private Int32 equipmentID = 0;
        private String unitMeasureName, equipmentTypeName, number, description;
        private Int32 equipmentTypeID, unitMeasureID;
        #endregion

        #region Properties
        public Int32 EquipmentID
        {
            get { return equipmentID; }
        }

        public Int32 UnitMeasureID
        {
            get { return unitMeasureID; }
            set
            {
                if (unitMeasureID != value)
                {
                    unitMeasureID = value;
                    UnitMeasureName = ConvertCollection.ConvertUnitMeasure(UnitMeasureID);
                    RaisePropertyChanged("UnitMeasureID");
                }
            }
        }

        public String UnitMeasureName
        {
            get { return unitMeasureName; }
            set
            {
                if (unitMeasureName!=value)
                {
                    unitMeasureName = value;
                    RaisePropertyChanged("UnitMeasureName");
                }
            }
        }

        public String Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }

        public Int32 EquipmentTypeID
        {
            get { return equipmentTypeID; }
            set
            {
                if (equipmentTypeID != value)
                {
                    equipmentTypeID = value;
                    EquipmentTypeName = ConvertCollection.ConvertEquipmentType(equipmentTypeID);
                    RaisePropertyChanged("EquipmentTypeID");
                }
            }
        }

        public String EquipmentTypeName
        {
            get { return unitMeasureName; }
            set
            {
                if (unitMeasureName != value)
                {
                    unitMeasureName = value;
                    RaisePropertyChanged("EquipmentTypeName");
                }
            }
        }

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
        #endregion

        public EquipmentViewModel() : base()
        {

        }

        protected override void Save(RadWindow window)
        {

        }

        protected override Boolean Delete()
        {
            try
            {

                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {

        }
    }
}