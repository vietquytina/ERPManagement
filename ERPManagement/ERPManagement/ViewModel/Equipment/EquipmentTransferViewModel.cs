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
    public class EquipmentTransferDetailViewModel : EquipmentHandoverDetailViewModel
    {
        public EquipmentTransferDetailViewModel() : base()
        {

        }
    }

    public class EquipmentTransferPersonViewModel : EquipmentHandoverPersonViewModel
    {
        public EquipmentTransferPersonViewModel() : base()
        {

        }
    }

    [Authorize.Authorize(Method = "EquipmentTransfer")]
    public class EquipmentTransferViewModel : EquipmentViewModel
    {
        #region Get data
        public static IEnumerable<EquipmentTransferViewModel> Gets()
        {
            List<EquipmentTransferViewModel> equipmentTransfervms = new List<EquipmentTransferViewModel>();
            var equipmentTransfers = from p in db.EquipmentTransfers
                                     select p;
            foreach (var equipmentTransfer in equipmentTransfers)
            {
                EquipmentTransferViewModel equipmentTransfervm = new EquipmentTransferViewModel();
                equipmentTransfervm.id = equipmentTransfer.ID;
                equipmentTransfervm.Number = equipmentTransfer.Number;
                equipmentTransfervm.Date = equipmentTransfer.Date;
                equipmentTransfervm.Note = equipmentTransfer.Note;
                foreach (var detail in equipmentTransfer.EquipmentTransferDetails)
                {
                    EquipmentTransferDetailViewModel detailvm = new EquipmentTransferDetailViewModel();
                    detailvm.DetailID = detail.DetailID;
                    detailvm.Index = detail.Index;
                    detailvm.EquipmentID = detail.EquipmentID;
                    detailvm.Quantity = detail.Quantity;
                    detailvm.EquipmentStatusID = detail.EquipmentStatusID;
                    detailvm.Note = detail.Note;
                    equipmentTransfervm.Details.Add(detailvm);
                }
                foreach (var sender in equipmentTransfer.EquipmentTransferSenders)
                {
                    EquipmentTransferPersonViewModel sendervm = new EquipmentTransferPersonViewModel();
                    sendervm.DetailID = sender.DetailID;
                    sendervm.Index = sender.Index;
                    sendervm.EmployeeID = sender.EmployeeID;
                    equipmentTransfervm.Senders.Add(sendervm);
                }
                foreach (var receiver in equipmentTransfer.EquipmentTransferReceivers)
                {
                    EquipmentTransferPersonViewModel receivervm = new EquipmentTransferPersonViewModel();
                    receivervm.DetailID = receiver.DetailID;
                    receivervm.Index = receiver.Index;
                    receivervm.EmployeeID = receiver.EmployeeID;
                    equipmentTransfervm.Receivers.Add(receivervm);
                }
                equipmentTransfervm.isInserted = false;
                equipmentTransfervms.Add(equipmentTransfervm);
            }
            return equipmentTransfervms;
        }

        public static EquipmentTransferViewModel Get(int id)
        {
            var equipmentTransfer = db.EquipmentTransfers.SingleOrDefault(m => m.ID == id);
            if (equipmentTransfer == null)
            {
                return null;
            }
            EquipmentTransferViewModel equipmentTransfervm = new EquipmentTransferViewModel();
            equipmentTransfervm.id = equipmentTransfer.ID;
            equipmentTransfervm.Number = equipmentTransfer.Number;
            equipmentTransfervm.Date = equipmentTransfer.Date;
            equipmentTransfervm.Note = equipmentTransfer.Note;
            foreach (var detail in equipmentTransfer.EquipmentTransferDetails)
            {
                EquipmentTransferDetailViewModel detailvm = new EquipmentTransferDetailViewModel();
                detailvm.DetailID = detail.DetailID;
                detailvm.Index = detail.Index;
                detailvm.EquipmentID = detail.EquipmentID;
                detailvm.Quantity = detail.Quantity;
                detailvm.EquipmentStatusID = detail.EquipmentStatusID;
                detailvm.Note = detail.Note;
                equipmentTransfervm.Details.Add(detailvm);
            }
            foreach (var sender in equipmentTransfer.EquipmentTransferSenders)
            {
                EquipmentTransferPersonViewModel sendervm = new EquipmentTransferPersonViewModel();
                sendervm.DetailID = sender.DetailID;
                sendervm.Index = sender.Index;
                sendervm.EmployeeID = sender.EmployeeID;
                equipmentTransfervm.Senders.Add(sendervm);
            }
            foreach (var receiver in equipmentTransfer.EquipmentTransferReceivers)
            {
                EquipmentTransferPersonViewModel receivervm = new EquipmentTransferPersonViewModel();
                receivervm.DetailID = receiver.DetailID;
                receivervm.Index = receiver.Index;
                receivervm.EmployeeID = receiver.EmployeeID;
                equipmentTransfervm.Receivers.Add(receivervm);
            }
            equipmentTransfervm.isInserted = false;
            return equipmentTransfervm;
        }
        #endregion

        #region Variables
        private int id;
        #endregion

        #region Properties
        public Int32 ID { get { return id; } }
        public ObservableCollection<EquipmentTransferDetailViewModel> Details { get; set; }
        public ObservableCollection<EquipmentTransferPersonViewModel> Senders { get; set; }
        public ObservableCollection<EquipmentTransferPersonViewModel> Receivers { get; set; }
        public ObservableCollection<EquipmentTransferPersonViewModel> ITManagers { get; set; }

        public IEnumerable<List.EquipmentViewModel> Equipments { get; set; }

        public IEnumerable<Employee.EmployeeViewModel> Employees { get; set; }

        public IEnumerable<List.StatusViewModel> Statuses { get; set; }
        #endregion

        public EquipmentTransferViewModel() : base()
        {
            Details = new ObservableCollection<EquipmentTransferDetailViewModel>();
            Senders = new ObservableCollection<EquipmentTransferPersonViewModel>();
            Receivers = new ObservableCollection<EquipmentTransferPersonViewModel>();
            ITManagers = new ObservableCollection<EquipmentTransferPersonViewModel>();
            Employees = (App.Current as App).Employees.Items;
            Equipments = (App.Current as App).Equipments.Items;
            Statuses = (App.Current as App).Statuses.Items;
        }

        protected override void Save(RadWindow window)
        {
            EquipmentTransfer eqTransfer = null;
            if (isInserted)
            {
                eqTransfer = new EquipmentTransfer();
                db.EquipmentTransfers.InsertOnSubmit(eqTransfer);
            }
            else
            {
                eqTransfer = db.EquipmentTransfers.SingleOrDefault(m => m.ID == ID);
            }
            if (eqTransfer != null)
            {
                eqTransfer.Number = Number;
                eqTransfer.Date = Date;
                eqTransfer.Note = Note;
                Sync(Details, eqTransfer.EquipmentTransferDetails);
                Sync(Senders, eqTransfer.EquipmentTransferSenders);
                Sync(Receivers, eqTransfer.EquipmentTransferReceivers);
                Sync(ITManagers, eqTransfer.EquipmentTransferITManagers);
                SyncIndex(eqTransfer.EquipmentTransferDetails);
                SyncIndex(eqTransfer.EquipmentTransferSenders);
                SyncIndex(eqTransfer.EquipmentTransferReceivers);
                SyncIndex(eqTransfer.EquipmentTransferITManagers);
                SyncIndex(Details);
                SyncIndex(Senders);
                SyncIndex(Receivers);
                SyncIndex(ITManagers);
                db.SubmitChanges();
                id = eqTransfer.ID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        #region Sync
        private void Sync(IList<EquipmentTransferDetailViewModel> srcDetails, EntitySet<EquipmentTransferDetail> destDetails)
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
                    destDetails[j].EquipmentID = srcDetails[i].EquipmentID;
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
                EquipmentTransferDetail detail = new EquipmentTransferDetail();
                detail.EquipmentID = srcDetails[i].EquipmentID;
                detail.Quantity = srcDetails[i].Quantity;
                detail.EquipmentStatusID = srcDetails[i].EquipmentStatusID;
                detail.Note = srcDetails[i].Note;
                destDetails.Add(detail);
                i++;
            }
        }

        private void Sync(IList<EquipmentTransferPersonViewModel> srcDetails, EntitySet<EquipmentTransferSender> destDetails)
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
                    destDetails[j].EmployeeID = srcDetails[i].EmployeeID;
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
                EquipmentTransferSender sender = new EquipmentTransferSender();
                sender.EmployeeID = srcDetails[i].EmployeeID;
                destDetails.Add(sender);
                i++;
            }
        }

        private void Sync(IList<EquipmentTransferPersonViewModel> srcDetails, EntitySet<EquipmentTransferReceiver> destDetails)
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
                    destDetails[j].EmployeeID = srcDetails[i].EmployeeID;
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
                EquipmentTransferReceiver receiver = new EquipmentTransferReceiver();
                receiver.EmployeeID = srcDetails[i].EmployeeID;
                destDetails.Add(receiver);
                i++;
            }
        }

        private void Sync(IList<EquipmentTransferPersonViewModel> srcDetails, EntitySet<EquipmentTransferITManager> destDetails)
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
                    destDetails[j].EmployeeID = srcDetails[i].EmployeeID;
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
                EquipmentTransferITManager manager = new EquipmentTransferITManager();
                manager.EmployeeID = srcDetails[i].EmployeeID;
                destDetails.Add(manager);
                i++;
            }
        }
        #endregion

        protected override bool Delete()
        {
            try
            {
                EquipmentTransfer eqTransfer = db.EquipmentTransfers.SingleOrDefault(m => m.ID == ID);
                db.EquipmentTransfers.DeleteOnSubmit(eqTransfer);
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