using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    class EquipmentViewModel : ListViewModel
    {
        public static IEnumerable<EquipmentViewModel> GetEquipments()
        {
            List<EquipmentViewModel> equipments = new List<EquipmentViewModel>();
            var eqs = from p in db.Equipments
                      select p;
            foreach (var eq in eqs)
            {
                EquipmentViewModel equipment = new EquipmentViewModel();
                equipment.equipmentID = eq.EquipmentID;
                equipment.Code = eq.Code;
                equipment.Name = eq.Name;
                equipment.UnitMeasure = eq.UnitMeasure;
                equipment.Number = eq.Number;
                equipment.EquipmentTypeID = eq.EquipmentTypeID;
                equipment.SubjectID = eq.SubjectID;
                equipment.Description = eq.Description;
                equipment.NationalID = eq.NationalID;
                equipment.isInserted = false;
                equipments.Add(equipment);
            }
            return equipments;
        }

        public static EquipmentViewModel GetEquipment(Int32 equipmentID)
        {
            var eq = db.Equipments.SingleOrDefault(m => m.EquipmentID == equipmentID);
            if (eq == null)
                return null;
            EquipmentViewModel equipment = new EquipmentViewModel();
            equipment.equipmentID = eq.EquipmentID;
            equipment.Code = eq.Code;
            equipment.Name = eq.Name;
            equipment.UnitMeasure = eq.UnitMeasure;
            equipment.Number = eq.Number;
            equipment.EquipmentTypeID = eq.EquipmentTypeID;
            equipment.SubjectID = eq.SubjectID;
            equipment.Description = eq.Description;
            equipment.NationalID = eq.NationalID;
            equipment.isInserted = false;
            return equipment;
        }

        #region Variables
        private Int32 equipmentID = 0;
        private String code, unitMeasure, number, description;
        private Int32 equipmentTypeID, subjectID, nationalID;
        #endregion

        #region Properties
        public Int32 EquipmentID
        {
            get { return equipmentID; }
        }
        public String Code
        {
            get { return code; }
            set
            {
                if (code != value)
                {
                    code = value;
                    RaisePropertyChanged("Code");
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
                    RaisePropertyChanged("EquipmentTypeID");
                }
            }
        }
        public Int32 SubjectID
        {
            get { return subjectID; }
            set
            {
                if (subjectID != value)
                {
                    subjectID = value;
                    RaisePropertyChanged("SubjectID");
                }
            }
        }
        public Int32 NationalID
        {
            get { return nationalID; }
            set
            {
                if (nationalID != value)
                {
                    nationalID = value;
                    RaisePropertyChanged("NationalID");
                }
            }
        }
        #endregion

        public EquipmentViewModel() : base()
        {

        }

        protected override void Save(RadWindow window)
        {
            ERPManagement.Model.Equipment eq = null;
            if (isInserted)
            {
                eq = new ERPManagement.Model.Equipment();
                db.Equipments.InsertOnSubmit(eq);
            }
            else
            {
                eq = db.Equipments.SingleOrDefault(m => m.EquipmentID == EquipmentID);
            }
            if (eq != null)
            {
                eq.Code = Code;
                eq.Name = Name;
                eq.UnitMeasure = UnitMeasure;
                eq.Number = Number;
                eq.EquipmentType = db.EquipmentTypes.SingleOrDefault(m => m.TypeID == EquipmentTypeID);
                eq.Subject = db.Subjects.SingleOrDefault(m => m.SubjectID == SubjectID);
                eq.Description = Description;
                eq.National = db.Nationals.SingleOrDefault(m => m.NationalID == NationalID);
                db.SubmitChanges();
                equipmentID = eq.EquipmentID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            ERPManagement.Model.Equipment eq = db.Equipments.SingleOrDefault(m => m.EquipmentID == EquipmentID);
            try
            {
                db.Equipments.DeleteOnSubmit(eq);
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