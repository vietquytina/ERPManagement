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

            return equipments;
        }

        public static EquipmentViewModel GetEquipment(Int32 equipmentID)
        {

            EquipmentViewModel equipment = new EquipmentViewModel();
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