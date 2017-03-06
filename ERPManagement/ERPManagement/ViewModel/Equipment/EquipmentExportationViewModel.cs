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
    public class EquipmentExportationDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 quantity, statusID;
        private String statusName, note;
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

        public EquipmentExportationDetailViewModel() : base()
        {

        }
    }

    [Authorize.Authorize(Method = "EquipmentExportation")]
    public class EquipmentExportationViewModel : EquipmentViewModel
    {
        public static IEnumerable<EquipmentExportationViewModel> Gets()
        {
            List<EquipmentExportationViewModel> equipmentExportvms = new List<EquipmentExportationViewModel>();
            var equipmentExports = from p in db.EquipmentExportations
                                   select p;
            foreach (var equipmentExport in equipmentExports)
            {
                EquipmentExportationViewModel equipmentExportvm = new EquipmentExportationViewModel();
                equipmentExportvm.equipmentExportationID = equipmentExport.ID;
                equipmentExportvm.Number = equipmentExport.Number;
                equipmentExportvm.Date = equipmentExport.Date;
                equipmentExportvm.Receiver = equipmentExport.Receiver;
                equipmentExportvm.StatusID = equipmentExport.StatusID;
                foreach (var detail in equipmentExport.EquipmentExportationDetails)
                {
                    EquipmentExportationDetailViewModel detailvm = new EquipmentExportationDetailViewModel();
                    detailvm.DetailID = detail.DetailID;
                    detailvm.Index = detail.Index;
                    detailvm.RestQuantity = detail.RestQuantity;
                    detailvm.Quantity = detail.Quantity;
                    detailvm.StatusID = detail.EquipmentStatusID;
                    detailvm.Note = detail.Note;
                    equipmentExportvm.Details.Add(detailvm);
                }
                equipmentExportvm.isInserted = false;
                equipmentExportvms.Add(equipmentExportvm);
            }
            return equipmentExportvms;
        }

        public static EquipmentExportationViewModel Get(int id)
        {
            var equipmentExport = db.EquipmentExportations.SingleOrDefault(m => m.ID == id);
            if (equipmentExport == null)
                return null;
            EquipmentExportationViewModel equipmentExportvm = new EquipmentExportationViewModel();
            equipmentExportvm.equipmentExportationID = equipmentExport.ID;
            equipmentExportvm.Number = equipmentExport.Number;
            equipmentExportvm.Date = equipmentExport.Date;
            equipmentExportvm.Receiver = equipmentExport.Receiver;
            equipmentExportvm.StatusID = equipmentExport.StatusID;
            foreach (var detail in equipmentExport.EquipmentExportationDetails)
            {
                EquipmentExportationDetailViewModel detailvm = new EquipmentExportationDetailViewModel();
                detailvm.DetailID = detail.DetailID;
                detailvm.Index = detail.Index;
                detailvm.RestQuantity = detail.RestQuantity;
                detailvm.Quantity = detail.Quantity;
                detailvm.StatusID = detail.EquipmentStatusID;
                detailvm.Note = detail.Note;
                equipmentExportvm.Details.Add(detailvm);
            }
            equipmentExportvm.isInserted = false;
            return equipmentExportvm;
        }

        #region Variables
        private Int32 receiver;
        private Int32 equipmentExportationID = 0;
        #endregion

        #region Properties
        public Int32 EquipmentExportationID
        {
            get { return equipmentExportationID; }
        }

        public Int32 Receiver
        {
            get { return receiver; }
            set
            {
                if (receiver != value)
                {
                    receiver = value;
                    RaisePropertyChanged("Receiver");
                }
            }
        }

        public ObservableCollection<EquipmentExportationDetailViewModel> Details { get; set; }
        #endregion

        public EquipmentExportationViewModel()
        {
            Details = new ObservableCollection<EquipmentExportationDetailViewModel>();
        }

        protected override void Save(RadWindow window)
        {
            EquipmentExportation eqExport = null;
            if (isInserted)
            {
                eqExport = new EquipmentExportation();
                db.EquipmentExportations.InsertOnSubmit(eqExport);
            }
            else
            {
                eqExport = db.EquipmentExportations.SingleOrDefault(m => m.ID == EquipmentExportationID);
            }
            if (eqExport != null)
            {
                eqExport.Number = Number;
                eqExport.Date = Date;
                eqExport.StatusID = StatusID;
                eqExport.Receiver = Receiver;
                Sync(Details, eqExport.EquipmentExportationDetails);
                SyncIndex(eqExport.EquipmentExportationDetails);
                SyncIndex(Details);
                db.SubmitChanges();
                equipmentExportationID = eqExport.ID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        private void Sync(IList<EquipmentExportationDetailViewModel> srcDetails, EntitySet<EquipmentExportationDetail> destDetails)
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
                    destDetails[j].RestQuantity = srcDetails[i].RestQuantity;
                    destDetails[j].Quantity = srcDetails[i].Quantity;
                    destDetails[j].EquipmentStatusID = srcDetails[i].StatusID;
                    destDetails[j].Note = srcDetails[i].Note;
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
                EquipmentExportationDetail detail = new EquipmentExportationDetail();
                detail.Equipment = db.Equipments.Single(m => m.EquipmentID == srcDetails[i].EquipmentID);
                detail.RestQuantity = srcDetails[i].RestQuantity;
                detail.Quantity = srcDetails[i].Quantity;
                detail.EquipmentStatusID = srcDetails[i].StatusID;
                detail.Note = srcDetails[i].Note;
                destDetails.Add(detail);
                i++;
            }
        }

        protected override bool Delete()
        {
            try
            {
                EquipmentExportation eqExport = db.EquipmentExportations.SingleOrDefault(m => m.ID == EquipmentExportationID);
                db.EquipmentExportations.DeleteOnSubmit(eqExport);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            View.Profession.EquipmentExportationView frmEquipmentExport = new View.Profession.EquipmentExportationView();
            EquipmentExportationViewModel equipmentExportvm = Get(EquipmentExportationID);
            equipmentExportvm.ItemAction += new ActionEventHandler(EquipmentExportvm_ItemAction);
            frmEquipmentExport.DataContext = equipmentExportvm;
            frmEquipmentExport.ShowDialog();
        }

        private void EquipmentExportvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Edit)
            {
                EquipmentExportationViewModel equipmentExportvm = (EquipmentExportationViewModel)sender;
                Number = equipmentExportvm.Number;
                Date = equipmentExportvm.Date;
                Receiver = equipmentExportvm.Receiver;
                StatusID = equipmentExportvm.StatusID;
                Details.Clear();
                foreach (var detailvm in equipmentExportvm.Details)
                {
                    Details.Add(detailvm);
                }
            }
        }
    }
}