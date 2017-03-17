using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    public class NationalViewModel : ListViewModel
    {
        public static IEnumerable<NationalViewModel> GetNationals()
        {
            List<NationalViewModel> nationalvms = new List<NationalViewModel>();
            var nationals = from p in db.Nationals
                            select p;
            foreach (var national in nationals)
            {
                NationalViewModel nationalvm = new NationalViewModel();
                nationalvm.nationalID = national.NationalID;
                nationalvm.Name = national.Name;
                nationalvm.Note = national.Note;
                nationalvm.isInserted = false;
                nationalvms.Add(nationalvm);
            }
            return nationalvms;
        }

        public static NationalViewModel GetNational(Int32 nationalID)
        {
            var national = db.Nationals.SingleOrDefault(m => m.NationalID == nationalID);
            if (national == null)
                return null;
            NationalViewModel nationalvm = new NationalViewModel();
            nationalvm.nationalID = national.NationalID;
            nationalvm.Name = national.Name;
            nationalvm.Note = national.Note;
            nationalvm.isInserted = false;
            return nationalvm;
        }

        #region Variables
        private Int32 nationalID = 0;
        #endregion

        #region Properties
        public Int32 NationalID
        {
            get { return nationalID; }
        }
        #endregion

        protected override void Save(RadWindow window)
        {
            National national = null;
            if (isInserted)
            {
                national = new National();
                db.Nationals.InsertOnSubmit(national);
            }
            else
            {
                national = db.Nationals.SingleOrDefault(m => m.NationalID == NationalID);
            }
            if (national != null)
            {
                national.Name = Name;
                national.Note = Note;
                db.SubmitChanges();
                nationalID = NationalID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            try
            {
                National national = db.Nationals.SingleOrDefault(m => m.NationalID == NationalID);
                db.Nationals.DeleteOnSubmit(national);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            View.List.NationalView frmNational = new View.List.NationalView();
            NationalViewModel nationalvm = GetNational(NationalID);
            nationalvm.ItemAction += new ActionEventHandler(Nationalvm_ItemAction);
            frmNational.DataContext = nationalvm;
            frmNational.ShowDialog();
        }

        private void Nationalvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Edit)
            {
                NationalViewModel nationalvm = (NationalViewModel)sender;
                Name = nationalvm.Name;
                Note = nationalvm.Note;
            }
        }
    }
}