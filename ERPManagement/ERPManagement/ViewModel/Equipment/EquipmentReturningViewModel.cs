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
    public class EquipmentReturningPersonViewModel : EquipmentHandoverPersonViewModel
    {
        public EquipmentReturningPersonViewModel() : base()
        {

        }
    }

    public class EquipmentReturningDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 quantity, equipmentStatusID;
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
        #endregion

        public EquipmentReturningDetailViewModel() : base()
        {

        }

        protected override void OnEquipmentChanged(int oldEquipment, int newEquipment)
        {

        }
    }

    [Authorize.Authorize(Method = "EquipmentReturning")]
    public class EquipmentReturningViewModel : EquipmentViewModel
    {
        public static IEnumerable<EquipmentReturningViewModel> Gets()
        {
            List<EquipmentReturningViewModel> equipmentReturnvms = new List<EquipmentReturningViewModel>();
            var equipmentReturns = from p in db.EquipmentReturnings
                                   select p;
            foreach (var equipmentReturn in equipmentReturns)
            {
                EquipmentReturningViewModel equipmentReturnvm = new EquipmentReturningViewModel();
                equipmentReturnvm.equipmentReturningID = equipmentReturn.ID;
                equipmentReturnvm.Number = equipmentReturn.Number;
                equipmentReturnvm.Date = equipmentReturn.Date;
                equipmentReturnvm.DepartmentID = equipmentReturn.DepartmentID;
                foreach (var detail in equipmentReturn.EquipmentReturningDetails)
                {
                    EquipmentReturningDetailViewModel detailvm = new EquipmentReturningDetailViewModel();
                    detailvm.DetailID = detail.DetailID;
                    detailvm.Index = detail.Index;
                    detailvm.EquipmentID = detail.EquipmentID;
                    detailvm.Quantity = detail.Quantity;
                    detailvm.EquipmentStatusID = detail.EquipmentStatusID;
                    equipmentReturnvm.Details.Add(detailvm);
                }
                foreach (var sender in equipmentReturn.EquipmentReturningSenders)
                {
                    EquipmentReturningPersonViewModel sendervm = new EquipmentReturningPersonViewModel();
                    sendervm.DetailID = sender.DetailID;
                    sendervm.Index = sender.Index;
                    sendervm.EmployeeID = sender.EmployeeID;
                    equipmentReturnvm.Senders.Add(sendervm);
                }
                foreach (var receiver in equipmentReturn.EquipmentReturningReceivers)
                {
                    EquipmentReturningPersonViewModel receivervm = new EquipmentReturningPersonViewModel();
                    receivervm.DetailID = receiver.DetailID;
                    receivervm.Index = receiver.Index;
                    receivervm.EmployeeID = receiver.EmployeeID;
                    equipmentReturnvm.Receivers.Add(receivervm);
                }
                equipmentReturnvm.isInserted = false;
                equipmentReturnvms.Add(equipmentReturnvm);
            }
            return equipmentReturnvms;
        }

        public static EquipmentReturningViewModel Get(int id)
        {
            var equipmentReturn = db.EquipmentReturnings.SingleOrDefault(m => m.ID == id);
            if (equipmentReturn == null)
                return null;
            EquipmentReturningViewModel equipmentReturnvm = new EquipmentReturningViewModel();
            equipmentReturnvm.equipmentReturningID = equipmentReturn.ID;
            equipmentReturnvm.Number = equipmentReturn.Number;
            equipmentReturnvm.Date = equipmentReturn.Date;
            equipmentReturnvm.DepartmentID = equipmentReturn.DepartmentID;
            foreach (var detail in equipmentReturn.EquipmentReturningDetails)
            {
                EquipmentReturningDetailViewModel detailvm = new EquipmentReturningDetailViewModel();
                detailvm.DetailID = detail.DetailID;
                detailvm.Index = detail.Index;
                detailvm.EquipmentID = detail.EquipmentID;
                detailvm.Quantity = detail.Quantity;
                detailvm.EquipmentStatusID = detail.EquipmentStatusID;
                equipmentReturnvm.Details.Add(detailvm);
            }
            foreach (var sender in equipmentReturn.EquipmentReturningSenders)
            {
                EquipmentReturningPersonViewModel sendervm = new EquipmentReturningPersonViewModel();
                sendervm.DetailID = sender.DetailID;
                sendervm.Index = sender.Index;
                sendervm.EmployeeID = sender.EmployeeID;
                equipmentReturnvm.Senders.Add(sendervm);
            }
            foreach (var receiver in equipmentReturn.EquipmentReturningReceivers)
            {
                EquipmentReturningPersonViewModel receivervm = new EquipmentReturningPersonViewModel();
                receivervm.DetailID = receiver.DetailID;
                receivervm.Index = receiver.Index;
                receivervm.EmployeeID = receiver.EmployeeID;
                equipmentReturnvm.Receivers.Add(receivervm);
            }
            equipmentReturnvm.isInserted = false;
            return equipmentReturnvm;
        }

        #region Variables
        private Int32 equipmentReturningID = 0;
        private Int32 departmentID;
        #endregion

        #region Properties
        public Int32 EquipmentReturningID
        {
            get { return equipmentReturningID; }
        }

        public Int32 DepartmentID
        {
            get { return departmentID; }
            set
            {
                if (departmentID != value)
                {
                    departmentID = value;
                    RaisePropertyChanged("DepartmentID");
                }
            }
        }

        public ObservableCollection<EquipmentReturningDetailViewModel> Details { get; set; }
        public ObservableCollection<EquipmentReturningPersonViewModel> Receivers { get; set; }
        public ObservableCollection<EquipmentReturningPersonViewModel> Senders { get; set; }
        #endregion

        public EquipmentReturningViewModel() : base()
        {
            Details = new ObservableCollection<EquipmentReturningDetailViewModel>();
            Receivers = new ObservableCollection<EquipmentReturningPersonViewModel>();
            Senders = new ObservableCollection<EquipmentReturningPersonViewModel>();
        }

        protected override void Save(RadWindow window)
        {
            EquipmentReturning eqReturning = null;
            if (isInserted)
            {
                eqReturning = new EquipmentReturning();
                db.EquipmentReturnings.InsertOnSubmit(eqReturning);
            }
            else
            {
                eqReturning = db.EquipmentReturnings.SingleOrDefault(m => m.ID == EquipmentReturningID);
            }
            if (isInserted)
            {
                eqReturning.Number = Number;
                eqReturning.Date = Date;
                eqReturning.DepartmentID = DepartmentID;
                Sync(Details, eqReturning.EquipmentReturningDetails);
                Sync(Receivers, eqReturning.EquipmentReturningReceivers);
                Sync(Senders, eqReturning.EquipmentReturningSenders);
                SyncIndex(Details);
                SyncIndex(Receivers);
                SyncIndex(Senders);
                SyncIndex(eqReturning.EquipmentReturningDetails);
                SyncIndex(eqReturning.EquipmentReturningReceivers);
                SyncIndex(eqReturning.EquipmentReturningSenders);
                db.SubmitChanges();
                equipmentReturningID = eqReturning.ID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        #region Sync
        private void Sync(IList<EquipmentReturningDetailViewModel> srcDetails, EntitySet<EquipmentReturningDetail> destDetails)
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
                EquipmentReturningDetail detail = new EquipmentReturningDetail();
                detail.EquipmentID = srcDetails[i].EquipmentID;
                detail.Quantity = srcDetails[i].Quantity;
                detail.EquipmentStatusID = srcDetails[i].EquipmentStatusID;
                i++;
            }
        }

        private void Sync(IList<EquipmentReturningPersonViewModel> srcDetails, EntitySet<EquipmentReturningReceiver> destDetails)
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
                EquipmentReturningReceiver receiver = new EquipmentReturningReceiver();
                receiver.EmployeeID = srcDetails[i].EmployeeID;
                destDetails.Add(receiver);
                i++;
            }
        }

        private void Sync(IList<EquipmentReturningPersonViewModel> srcDetails, EntitySet<EquipmentReturningSender> destDetails)
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
                EquipmentReturningSender sender = new EquipmentReturningSender();
                sender.EmployeeID = srcDetails[i].EmployeeID;
                destDetails.Add(sender);
                i++;
            }
        }
        #endregion

        protected override bool Delete()
        {
            try
            {
                var eqReturning = db.EquipmentReturnings.SingleOrDefault(m => m.ID == EquipmentReturningID);
                db.EquipmentReturnings.DeleteOnSubmit(eqReturning);
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