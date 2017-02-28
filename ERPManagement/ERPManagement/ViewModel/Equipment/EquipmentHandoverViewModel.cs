﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;
using System.Data.Linq;

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
                    RaisePropertyChanged("EmployeeID");
                }
            }
        }
        #endregion

        public EquipmentHandoverPersonViewModel() : base()
        {

        }
    }

    public class EquipmentHandoverViewModel : EquipmentViewModel
    {
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
        #endregion

        public EquipmentHandoverViewModel() : base()
        {
            Details = new ObservableCollection<EquipmentHandoverDetailViewModel>();
            Senders = new ObservableCollection<EquipmentHandoverPersonViewModel>();
            Receivers = new ObservableCollection<EquipmentHandoverPersonViewModel>();
        }

        protected override void Save(RadWindow window)
        {
            EquipmentHandOver eqHandover = null;
            if (isInserted)
            {
                eqHandover = new EquipmentHandOver();
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
                    destDetails[j].Quantity = srcDetails[j].Quantity;
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
        }
    }
}