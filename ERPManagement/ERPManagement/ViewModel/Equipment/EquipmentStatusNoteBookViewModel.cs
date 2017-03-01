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
    public class EquipmentStatusNoteBookDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 equipmentStatusID;
        private String cause, note;
        #endregion

        #region Properties
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

        public String Cause
        {
            get { return cause; }
            set
            {
                if (cause != value)
                {
                    cause = value;
                    RaisePropertyChanged("Cause");
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

        public EquipmentStatusNoteBookDetailViewModel() : base()
        {
        }
    }

    public class EquipmentStatusNoteBookViewModel : EquipmentViewModel
    {
        public static IEnumerable<EquipmentStatusNoteBookViewModel> Gets()
        {
            List<EquipmentStatusNoteBookViewModel> eqNoteBookvms = new List<EquipmentStatusNoteBookViewModel>();
            var eqNoteBooks = from p in db.EquipmentStatusNoteBooks
                              select p;
            foreach (var eqNoteBook in eqNoteBooks)
            {
                EquipmentStatusNoteBookViewModel eqNoteBookvm = new EquipmentStatusNoteBookViewModel();
                eqNoteBookvm.noteID = eqNoteBook.NoteID;
                eqNoteBookvm.Date = eqNoteBook.Date;
                eqNoteBookvm.CompanyID = eqNoteBook.CompanyID;
                eqNoteBookvm.EmployeeID = eqNoteBook.EmployeeID;
                foreach (var detail in eqNoteBook.EquipmentStatusNoteBookDetails)
                {
                    EquipmentStatusNoteBookDetailViewModel detailvm = new EquipmentStatusNoteBookDetailViewModel();
                    detailvm.DetailID = detail.DetailID;
                    detailvm.Index = detail.Index;
                    detailvm.EquipmentID = detail.EquipmentID;
                    detailvm.EquipmentStatusID = detail.EquipmentStatusID;
                    detailvm.Cause = detail.Cause;
                    detailvm.Note = detail.Note;
                    eqNoteBookvm.Details.Add(detailvm);
                }
                eqNoteBookvm.isInserted = false;
                eqNoteBookvms.Add(eqNoteBookvm);
            }
            return eqNoteBookvms;
        }

        public static EquipmentStatusNoteBookViewModel Get(int noteID)
        {
            var eqNoteBook = db.EquipmentStatusNoteBooks.SingleOrDefault(m => m.NoteID == noteID);
            if (eqNoteBook == null)
                return null;
            EquipmentStatusNoteBookViewModel eqNoteBookvm = new EquipmentStatusNoteBookViewModel();
            eqNoteBookvm.noteID = eqNoteBook.NoteID;
            eqNoteBookvm.Date = eqNoteBook.Date;
            eqNoteBookvm.CompanyID = eqNoteBook.CompanyID;
            eqNoteBookvm.EmployeeID = eqNoteBook.EmployeeID;
            foreach (var detail in eqNoteBook.EquipmentStatusNoteBookDetails)
            {
                EquipmentStatusNoteBookDetailViewModel detailvm = new EquipmentStatusNoteBookDetailViewModel();
                detailvm.DetailID = detail.DetailID;
                detailvm.Index = detail.Index;
                detailvm.EquipmentID = detail.EquipmentID;
                detailvm.EquipmentStatusID = detail.EquipmentStatusID;
                detailvm.Cause = detail.Cause;
                detailvm.Note = detail.Note;
                eqNoteBookvm.Details.Add(detailvm);
            }
            eqNoteBookvm.isInserted = false;
            return eqNoteBookvm;
        }

        #region Variables
        private Int32 noteID, employeeID, companyID;
        #endregion

        #region Properties
        public Int32 NoteID
        {
            get { return noteID; }
        }

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

        public Int32 CompanyID
        {
            get { return companyID; }
            set
            {
                if (companyID != value)
                {
                    companyID = value;
                    RaisePropertyChanged("CompanyID");
                }
            }
        }

        public ObservableCollection<EquipmentStatusNoteBookDetailViewModel> Details { get; set; }
        #endregion

        public EquipmentStatusNoteBookViewModel() : base()
        {
            Details = new ObservableCollection<EquipmentStatusNoteBookDetailViewModel>();
        }

        protected override void Save(RadWindow window)
        {
            EquipmentStatusNoteBook eqNoteBook = null;
            if (isInserted)
            {
                eqNoteBook = new EquipmentStatusNoteBook();
                db.EquipmentStatusNoteBooks.InsertOnSubmit(eqNoteBook);
            }
            else
            {
                eqNoteBook = db.EquipmentStatusNoteBooks.SingleOrDefault(m => m.NoteID == NoteID);
            }
            if (eqNoteBook != null)
            {
                eqNoteBook.Date = Date;
                if (!isInserted)
                {
                    eqNoteBook.EmployeeID = EmployeeID;
                }
                Sync(Details, eqNoteBook.EquipmentStatusNoteBookDetails);
                SyncIndex(eqNoteBook.EquipmentStatusNoteBookDetails);
                SyncIndex(Details);
                db.SubmitChanges();
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        private void Sync(IList<EquipmentStatusNoteBookDetailViewModel> srcDetails, EntitySet<EquipmentStatusNoteBookDetail> destDetails)
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
                    destDetails[j].EquipmentStatusID = srcDetails[i].EquipmentStatusID;
                    destDetails[j].Cause = srcDetails[i].Cause;
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
                EquipmentStatusNoteBookDetail detail = new EquipmentStatusNoteBookDetail();
                detail.EquipmentID = srcDetails[i].EquipmentID;
                detail.EquipmentStatusID = srcDetails[i].EquipmentStatusID;
                detail.Cause = srcDetails[i].Cause;
                detail.Note = srcDetails[i].Note;
                destDetails.Add(detail);
                i++;
            }
        }

        protected override bool Delete()
        {
            try
            {
                EquipmentStatusNoteBook eqNoteBook = db.EquipmentStatusNoteBooks.SingleOrDefault(m => m.NoteID == NoteID);
                db.EquipmentStatusNoteBooks.DeleteOnSubmit(eqNoteBook);
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