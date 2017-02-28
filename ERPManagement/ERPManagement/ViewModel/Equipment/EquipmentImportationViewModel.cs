using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;
using System.Data.Linq;

namespace ERPManagement.ViewModel.Equipment
{
    public class EquipmentImportationDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 quantity, equipmentStatusID;
        private String note;
        #endregion

        #region Properties
        public Int32 EquipmentImportationID { get; set; }
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
        public Int32 EquipmentStatusID
        {
            get { return equipmentStatusID; }
            set
            {
                if (equipmentStatusID != value)
                {
                    equipmentStatusID = value;
                    RaisePropertyChanged("EquipmentStatusID");
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

        public EquipmentImportationDetailViewModel() : base()
        {
        }
    }

    [Authorize.Authorize(Method = "EquipmentImportation")]
    public class EquipmentImportationViewModel : EquipmentViewModel
    {
        #region Variables
        private Int32 equipmentImportationID;
        private Int32 delivery;
        #endregion

        #region Properties
        public Int32 EquipmentImportationID
        {
            get { return equipmentImportationID; }
        }
        public ObservableCollection<EquipmentImportationDetailViewModel> Details { get; set; }
        public Int32 Delivery
        {
            get { return delivery; }
            set
            {
                if (delivery != value)
                {
                    delivery = value;
                    RaisePropertyChanged("Delivery");
                }
            }
        }
        #endregion

        public EquipmentImportationViewModel() : base()
        {
            Details = new ObservableCollection<EquipmentImportationDetailViewModel>();
        }

        protected override void Save(RadWindow window)
        {
            EquipmentImportation eqImport = null;
            if (isInserted)
            {
                eqImport = new EquipmentImportation();
                db.EquipmentImportations.InsertOnSubmit(eqImport);
            }
            else
            {
                eqImport = db.EquipmentImportations.SingleOrDefault(m => m.ID == EquipmentImportationID);
            }
            if (eqImport != null)
            {
                eqImport.Number = Number;
                eqImport.Date = Date;
                eqImport.StatusID = StatusID;
                eqImport.Employee = db.Employees.Single(m => m.EmployeeID == Delivery);
                Sync(Details, eqImport.EquipmentImportationDetails);
                SyncIndex(Details);
                SyncIndex(eqImport.EquipmentImportationDetails);
                db.SubmitChanges();
                equipmentImportationID = eqImport.ID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        private void Sync(IList<EquipmentImportationDetailViewModel> srcDetails, EntitySet<EquipmentImportationDetail> destDetails)
        {
            int i = 0;
            int j = 0;
            if (srcDetails.Count == 0 || (srcDetails.Count > 0 && srcDetails[0].Index == -1))
            {
                destDetails.Clear();
            }
            while (i < srcDetails.Count && j < destDetails.Count)
            {
                if (srcDetails[i].Index == destDetails[j].Index)
                {
                    destDetails[j].Equipment = db.Equipments.Single(m => m.EquipmentID == srcDetails[i].EquipmentID);
                    destDetails[i].RestQuantity = srcDetails[i].RestQuantity;
                    destDetails[j].Quantity = srcDetails[i].Quantity;
                    destDetails[j].EquipmentStatusID = srcDetails[i].EquipmentStatusID;
                    destDetails[j].Note = srcDetails[i].Note;
                    i++;
                    j++;
                }
                else
                {
                    if (srcDetails[i].Index == -1 || srcDetails[i].Index > destDetails[j].Index)
                    {
                        destDetails.RemoveAt(j);
                    }
                }
            }
            while (j < destDetails.Count)
            {
                destDetails.RemoveAt(j);
            }
            while (i < srcDetails.Count)
            {
                EquipmentImportationDetail detail = new EquipmentImportationDetail();
                detail.Equipment = db.Equipments.Single(m => m.EquipmentID == srcDetails[i].EquipmentID);
                detail.RestQuantity = srcDetails[i].RestQuantity;
                detail.Quantity = srcDetails[i].Quantity;
                detail.EquipmentStatusID = srcDetails[i].EquipmentStatusID;
                detail.Note = srcDetails[i].Note;
                destDetails.Add(detail);
                i++;
            }
        }

        protected override bool Delete()
        {
            try
            {
                EquipmentImportation eqImport = db.EquipmentImportations.SingleOrDefault(m => m.ID == EquipmentImportationID);
                db.EquipmentImportations.DeleteOnSubmit(eqImport);
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