using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;
using System.Data.Linq;
using System.Collections.Specialized;

namespace ERPManagement.ViewModel.Equipment
{
    public class EquipmentHandoverDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 qty, equipmentStatusID;
        private String note;
        #endregion

        #region Properties
        public Int32 Quantity
        {
            get { return qty; }
            set
            {
                if (qty != value)
                {
                    qty = value;
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
                    EquipmentStatusName = ConvertCollection.ConvertStatus(EquipmentStatusID);
                    RaisePropertyChanged("EquipmentStatusID");
                    RaisePropertyChanged("EquipmentStatusName");
                }
            }
        }

        public String EquipmentStatusName { get; set; }

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

        public EquipmentHandoverDetailViewModel() : base()
        {
            Quantity = EquipmentStatusID = 0;
            Note = String.Empty;
        }
    }

    public class EquipmentHandoverPersonViewModel : EquipmentIndexViewModel
    {
        #region Variables
        private Int32 employeeID;
        #endregion

        #region Properties
        public Int32 EmployeeID
        {
            get { return employeeID; }
            set
            {
                if (employeeID != value)
                {
                    employeeID = value;
                    Regency = ConvertCollection.ConvertEmployee(EmployeeID, ViewModel.Converter.EmployeeConvertation.Regency);
                    RaisePropertyChanged("EmployeeID");
                    RaisePropertyChanged("Regency");
                }
            }
        }

        public String Regency { get; set; }
        #endregion

        public EquipmentHandoverPersonViewModel() : base()
        {

        }
    }

    [Authorize.Authorize(Method = "EquipmentHandover")]
    public class EquipmentHandoverViewModel : EquipmentViewModel
    {
        public static IEnumerable<EquipmentHandoverViewModel> Gets()
        {
            List<EquipmentHandoverViewModel> equipmentHandovervms = new List<EquipmentHandoverViewModel>();
            var equipmentHandovers = from p in db.EquipmentHandOvers
                                     select p;
            foreach (var equipmentHandover in equipmentHandovers)
            {
                EquipmentHandoverViewModel equipmentHandovervm = new EquipmentHandoverViewModel();
                equipmentHandovervm.id = equipmentHandover.ID;
                equipmentHandovervm.Number = equipmentHandover.Number;
                equipmentHandovervm.Date = equipmentHandover.Date;
                equipmentHandovervm.Note = equipmentHandover.Note;
                equipmentHandovervm.DepartmentID = equipmentHandover.DepartmentID;
                foreach (var detail in equipmentHandover.EquipmentHandOverDetails)
                {
                    EquipmentHandoverDetailViewModel detailvm = new EquipmentHandoverDetailViewModel();
                    detailvm.DetailID = detail.DetailID;
                    detailvm.Index = detail.Index;
                    detailvm.EquipmentID = detail.EquipmentID;
                    detailvm.Quantity = detail.Quantity;
                    detailvm.EquipmentStatusID = detail.EquipmentStatusID;
                    detailvm.Note = detail.Note;
                    equipmentHandovervm.Details.Add(detailvm);
                }
                foreach (var sender in equipmentHandover.EquipmentHandOverSenders)
                {
                    EquipmentHandoverPersonViewModel sendervm = new EquipmentHandoverPersonViewModel();
                    sendervm.DetailID = sender.DetailID;
                    sendervm.Index = sender.Index;
                    sendervm.EmployeeID = sender.EmployeeID;
                    equipmentHandovervm.Senders.Add(sendervm);
                }
                foreach (var receiver in equipmentHandover.EquipmentHandOverReceivers)
                {
                    EquipmentHandoverPersonViewModel receivervm = new EquipmentHandoverPersonViewModel();
                    receivervm.DetailID = receiver.DetailID;
                    receivervm.Index = receiver.Index;
                    receivervm.EmployeeID = receiver.EmployeeID;
                    equipmentHandovervm.Receivers.Add(receivervm);
                }
                equipmentHandovervm.isInserted = false;
                equipmentHandovervms.Add(equipmentHandovervm);
            }
            return equipmentHandovervms;
        }

        public static EquipmentHandoverViewModel Get(int id)
        {
            var equipmentHandover = db.EquipmentHandOvers.SingleOrDefault(m => m.ID == id);
            if (equipmentHandover == null)
                return null;
            EquipmentHandoverViewModel equipmentHandovervm = new EquipmentHandoverViewModel();
            equipmentHandovervm.id = equipmentHandover.ID;
            equipmentHandovervm.Number = equipmentHandover.Number;
            equipmentHandovervm.Date = equipmentHandover.Date;
            equipmentHandovervm.Note = equipmentHandover.Note;
            equipmentHandovervm.DepartmentID = equipmentHandover.DepartmentID;
            foreach (var detail in equipmentHandover.EquipmentHandOverDetails)
            {
                EquipmentHandoverDetailViewModel detailvm = new EquipmentHandoverDetailViewModel();
                detailvm.DetailID = detail.DetailID;
                detailvm.Index = detail.Index;
                detailvm.EquipmentID = detail.EquipmentID;
                detailvm.Quantity = detail.Quantity;
                detailvm.EquipmentStatusID = detail.EquipmentStatusID;
                detailvm.Note = detail.Note;
                equipmentHandovervm.Details.Add(detailvm);
            }
            foreach (var sender in equipmentHandover.EquipmentHandOverSenders)
            {
                EquipmentHandoverPersonViewModel sendervm = new EquipmentHandoverPersonViewModel();
                sendervm.DetailID = sender.DetailID;
                sendervm.Index = sender.Index;
                sendervm.EmployeeID = sender.EmployeeID;
                equipmentHandovervm.Senders.Add(sendervm);
            }
            foreach (var receiver in equipmentHandover.EquipmentHandOverReceivers)
            {
                EquipmentHandoverPersonViewModel receivervm = new EquipmentHandoverPersonViewModel();
                receivervm.DetailID = receiver.DetailID;
                receivervm.Index = receiver.Index;
                receivervm.EmployeeID = receiver.EmployeeID;
                equipmentHandovervm.Receivers.Add(receivervm);
            }
            equipmentHandovervm.isInserted = false;
            return equipmentHandovervm;
        }

        #region Variables
        private Int32 departmentID;
        private Int32 id;
        #endregion

        #region Properties
        public Int32 ID
        {
            get { return id; }
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

        public ObservableCollection<EquipmentHandoverDetailViewModel> Details { get; set; }

        public ObservableCollection<EquipmentHandoverPersonViewModel> Senders { get; set; }

        public ObservableCollection<EquipmentHandoverPersonViewModel> Receivers { get; set; }

        public IEnumerable<Employee.EmployeeViewModel> Employees { get; set; }

        public IEnumerable<List.EquipmentViewModel> Equipments { get; set; }

        public IEnumerable<List.StatusViewModel> Statuses { get; set; }

        public IEnumerable<List.DepartmentViewModel> Departments { get; set; }
        #endregion

        public EquipmentHandoverViewModel() : base()
        {
            Details = new ObservableCollection<EquipmentHandoverDetailViewModel>();
            Details.CollectionChanged += new NotifyCollectionChangedEventHandler(Details_CollectionChanged);
            Senders = new ObservableCollection<EquipmentHandoverPersonViewModel>();
            Receivers = new ObservableCollection<EquipmentHandoverPersonViewModel>();
            Employees = (App.Current as App).Employees.Items;
            Equipments = (App.Current as App).Equipments.Items;
            Statuses = (App.Current as App).Statuses.Items;
            Departments = (App.Current as App).Departments.Items;
        }

        private void Details_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                EquipmentHandoverDetailViewModel itemDetail = Details[e.NewStartingIndex];
                itemDetail.EquipmentChanged += new EquipmentChangedEventHandler(ItemDetail_EquipmentChanged);
            }
        }

        private void ItemDetail_EquipmentChanged(object sender, EquipmentChangedEventArgs e)
        {
            var subEquipments = Equipments.Where(m => m.ParentEquipmentID == e.NewEquipmentID);
            foreach (var subEquipment in subEquipments)
            {
                EquipmentHandoverDetailViewModel detail = new EquipmentHandoverDetailViewModel();
                detail.EquipmentID = subEquipment.EquipmentID;
                detail.Quantity = 0;
                detail.EquipmentStatusID = 1;
                Details.Add(detail);
            }
        }

        protected override void Save(RadWindow window)
        {
            EquipmentHandOver eqHandover = null;
            if (isInserted)
            {
                eqHandover = new EquipmentHandOver();
                eqHandover.EquipmentHandOverDetails = new EntitySet<EquipmentHandOverDetail>();
                eqHandover.EquipmentHandOverReceivers = new EntitySet<EquipmentHandOverReceiver>();
                eqHandover.EquipmentHandOverSenders = new EntitySet<EquipmentHandOverSender>();
                db.EquipmentHandOvers.InsertOnSubmit(eqHandover);
            }
            else
            {
                eqHandover = db.EquipmentHandOvers.SingleOrDefault(m => m.ID == ID);
            }
            if (eqHandover != null)
            {
                eqHandover.Number = Number;
                eqHandover.Date = Date;
                eqHandover.Note = Note;
                eqHandover.Department = db.Departments.Single(m => m.DepartmentID == DepartmentID);
                Sync(Details, eqHandover.EquipmentHandOverDetails);
                Sync(Senders, eqHandover.EquipmentHandOverSenders);
                Sync(Receivers, eqHandover.EquipmentHandOverReceivers);
                SyncIndex(eqHandover.EquipmentHandOverDetails);
                SyncIndex(eqHandover.EquipmentHandOverReceivers);
                SyncIndex(eqHandover.EquipmentHandOverSenders);
                SyncIndex(Details);
                SyncIndex(Senders);
                SyncIndex(Receivers);
                db.SubmitChanges();
                id = eqHandover.ID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        #region Sync
        private void Sync(IList<EquipmentHandoverDetailViewModel> srcDetails, EntitySet<EquipmentHandOverDetail> destDetails)
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
                EquipmentHandOverDetail detail = new EquipmentHandOverDetail();
                detail.DetailID = srcDetails[i].DetailID;
                detail.Equipment = db.Equipments.Single(m => m.EquipmentID == srcDetails[i].EquipmentID);
                detail.Quantity = srcDetails[i].Quantity;
                detail.EquipmentStatusID = srcDetails[i].EquipmentStatusID;
                detail.Note = srcDetails[i].Note;
                destDetails.Add(detail);
                i++;
            }
        }

        private void Sync(IList<EquipmentHandoverPersonViewModel> srcDetails, EntitySet<EquipmentHandOverReceiver> destDetails)
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
                    destDetails[j].Employee = db.Employees.Single(m => m.EmployeeID == srcDetails[i].EmployeeID);
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
                EquipmentHandOverReceiver detail = new EquipmentHandOverReceiver();
                detail.DetailID = srcDetails[i].DetailID;
                detail.Employee = db.Employees.Single(m => m.EmployeeID == srcDetails[i].EmployeeID);
                destDetails.Add(detail);
                i++;
            }
        }

        private void Sync(IList<EquipmentHandoverPersonViewModel> srcDetails, EntitySet<EquipmentHandOverSender> destDetails)
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
                    destDetails[j].Employee = db.Employees.Single(m => m.EmployeeID == srcDetails[i].EmployeeID);
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
                EquipmentHandOverSender detail = new EquipmentHandOverSender();
                detail.DetailID = srcDetails[i].DetailID;
                detail.Employee = db.Employees.Single(m => m.EmployeeID == srcDetails[i].EmployeeID);
                destDetails.Add(detail);
                i++;
            }
        }
        #endregion

        protected override bool Delete()
        {
            try
            {
                EquipmentHandOver eqHandover = db.EquipmentHandOvers.SingleOrDefault(m => m.ID == ID);
                db.EquipmentHandOvers.DeleteOnSubmit(eqHandover);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            View.Profession.EquipmentHandoverView frmHandover = new View.Profession.EquipmentHandoverView();
            EquipmentHandoverViewModel equipmentHandovervm = Get(ID);
            equipmentHandovervm.ItemAction += new ActionEventHandler(EquipmentHandovervm_ItemAction);
            frmHandover.DataContext = equipmentHandovervm;
            frmHandover.ShowDialog();
        }

        private void EquipmentHandovervm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Edit)
            {
                EquipmentHandoverViewModel equipmentHandovervm = (EquipmentHandoverViewModel)sender;
                Number = equipmentHandovervm.Number;
                Date = equipmentHandovervm.Date;
                Note = equipmentHandovervm.Note;
                DepartmentID = equipmentHandovervm.DepartmentID;
                Details.Clear();
                Senders.Clear();
                Receivers.Clear();
                foreach (var detail in equipmentHandovervm.Details)
                {
                    Details.Add(detail);
                }
                foreach (var sendervm in equipmentHandovervm.Senders)
                {
                    Senders.Add(sendervm);
                }
                foreach (var receivervm in equipmentHandovervm.Receivers)
                {
                    Receivers.Add(receivervm);
                }
            }
        }
    }
}