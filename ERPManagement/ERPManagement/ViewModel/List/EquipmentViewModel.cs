using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "Equipment")]
    public class EquipmentViewModel : ListViewModel
    {
        public static IEnumerable<EquipmentViewModel> GetEquipments(Int32 parentEquipmentID)
        {
            var equipments = from p in db.Equipments
                             where p.ParentEquipmentID == parentEquipmentID
                             select p;
            List<EquipmentViewModel> equipmentvms = new List<EquipmentViewModel>();
            foreach (var equipment in equipments)
            {
                EquipmentViewModel equipmentvm = new EquipmentViewModel();
                equipmentvm.equipmentID = equipment.EquipmentID;
                equipmentvm.Code = equipment.Code;
                equipmentvm.Name = equipment.Name;
                equipmentvm.Number = equipment.Number;
                equipmentvm.EquipmentTypeID = equipment.EquipmentTypeID;
                equipmentvm.UnitMeasureID = equipment.UnitMeasureID;
                equipmentvm.Description = equipment.Description;
                equipmentvm.isInserted = false;
                equipmentvms.Add(equipmentvm);
            }
            return equipmentvms;
        }

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
                equipmentvm.Number = equipment.Number;
                equipmentvm.EquipmentTypeID = equipment.EquipmentTypeID;
                equipmentvm.UnitMeasureID = equipment.UnitMeasureID;
                equipmentvm.Description = equipment.Description;
                equipmentvm.ParentEquipmentID = equipment.ParentEquipmentID;
                equipmentvm.isInserted = false;
                equipmentvms.Add(equipmentvm);
            }
            return equipmentvms;
        }

        public static EquipmentViewModel GetEquipment(Int32 equipmentID)
        {
            var equipment = db.Equipments.SingleOrDefault(m => m.EquipmentID == equipmentID);
            if (equipment == null)
            {
                return null;
            }
            EquipmentViewModel equipmentvm = new EquipmentViewModel();
            equipmentvm.equipmentID = equipment.EquipmentID;
            equipmentvm.Code = equipment.Code;
            equipmentvm.Name = equipment.Name;
            equipmentvm.EquipmentTypeID = equipment.EquipmentTypeID;
            equipmentvm.UnitMeasureID = equipment.UnitMeasureID;
            equipmentvm.Description = equipment.Description;
            equipmentvm.ParentEquipmentID = equipment.ParentEquipmentID;
            equipmentvm.isInserted = false;
            return equipmentvm;
        }

        #region Variables
        private Int32 equipmentID = 0;
        private String unitMeasureName, equipmentTypeName, number, description;
        private Int32 equipmentTypeID, unitMeasureID;
        private Int32? parentEqID;
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
                if (unitMeasureName != value)
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
            get { return equipmentTypeName; }
            set
            {
                if (equipmentTypeName != value)
                {
                    equipmentTypeName = value;
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

        public Int32? ParentEquipmentID
        {
            get { return parentEqID; }
            set
            {
                if (parentEqID != value)
                {
                    parentEqID = value;
                    RaisePropertyChanged("ParentEquipmentID");
                }
            }
        }
        #endregion

        public EquipmentViewModel() : base()
        {

        }

        protected override void Save(RadWindow window)
        {
            Model.Equipment equipment = null;
            if (isInserted)
            {
                equipment = new Model.Equipment();
                db.Equipments.InsertOnSubmit(equipment);
            }
            else
            {
                equipment = db.Equipments.SingleOrDefault(m => m.EquipmentID == EquipmentID);
            }
            if (equipment != null)
            {
                equipment.Code = Code;
                equipment.Name = Name;
                equipment.EquipmentType = db.EquipmentTypes.Single(m => m.EquipmentTypeID == EquipmentTypeID);
                equipment.UnitMeasure = db.UnitMeasures.Single(m => m.UnitMeasureID == UnitMeasureID);
                equipment.Description = Description;
                equipment.ParentEquipmentID = ParentEquipmentID;
                db.SubmitChanges();
                equipmentID = equipment.EquipmentID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            try
            {
                Model.Equipment equipment = db.Equipments.SingleOrDefault(m => m.EquipmentID == EquipmentID);
                db.Equipments.DeleteOnSubmit(equipment);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {

        }
    }
}