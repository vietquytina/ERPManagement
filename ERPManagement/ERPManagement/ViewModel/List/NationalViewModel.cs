using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    class NationalViewModel : ListViewModel
    {
        public static IEnumerable<NationalViewModel> GetNationals()
        {
            List<NationalViewModel> nationals = new List<NationalViewModel>();
            var ns = from p in db.Nationals
                     select p;
            foreach (var n in ns)
            {
                NationalViewModel national = new NationalViewModel();
                national.nationalID = n.NationalID;
                national.Name = n.Name;
                national.Note = n.Note;
                national.isInserted = false;
                nationals.Add(national);
            }
            return nationals;
        }

        public static NationalViewModel GetNational(Int32 nationalID)
        {
            var n = db.Nationals.SingleOrDefault(m => m.NationalID == nationalID);
            NationalViewModel national = new NationalViewModel();
            national.nationalID = n.NationalID;
            national.Name = n.Name;
            national.Note = n.Note;
            national.isInserted = false;
            return national;
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
                national = db.Nationals.SingleOrDefault(m => m.NationalID == nationalID);
            }
            if (national != null)
            {
                national.Name = Name;
                national.Note = Note;
                db.SubmitChanges();
                nationalID = national.NationalID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            try
            {
                National national = db.Nationals.SingleOrDefault(m => m.NationalID == nationalID);
                db.Nationals.DeleteOnSubmit(national);
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {

        }
    }
}