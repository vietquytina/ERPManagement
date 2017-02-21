using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "Regency")]
    class RegencyViewModel : ListViewModel
    {
        public static IEnumerable<RegencyViewModel> GetRegencies()
        {
            List<RegencyViewModel> regencyvms = new List<RegencyViewModel>();
            var regencies = from p in db.Regencies
                            select p;
            foreach (var regency in regencies)
            {
                RegencyViewModel regencyvm = new RegencyViewModel();
                regencyvm.regencyID = regency.RegencyID;
                regencyvm.isInserted = false;
                regencyvm.Name = regency.Name;
                regencyvm.Note = regency.Note;
                regencyvms.Add(regencyvm);
            }
            return regencyvms;
        }

        public static RegencyViewModel GetRegency(Int32 regencyID)
        {
            var regency = db.Regencies.SingleOrDefault(m => m.RegencyID == regencyID);
            if (regency == null)
                return null;
            RegencyViewModel regencyvm = new RegencyViewModel();
            regencyvm.regencyID = regency.RegencyID;
            regencyvm.isInserted = false;
            regencyvm.Name = regency.Name;
            regencyvm.Note = regency.Note;
            return regencyvm;
        }

        #region Variables
        private Int32 regencyID = 0;
        #endregion

        #region Properties
        public Int32 RegencyID
        {
            get { return regencyID; }
        }
        #endregion

        public RegencyViewModel() : base()
        {

        }

        protected override void Save(RadWindow window)
        {
            Regency regency = null;
            if (isInserted)
            {
                regency = new Regency();
                db.Regencies.InsertOnSubmit(regency);
            }
            else
            {
                regency = db.Regencies.SingleOrDefault(m => m.RegencyID == RegencyID);
            }
            if (regency != null)
            {
                regency.Name = Name;
                regency.Note = Note;
                db.SubmitChanges();
                regencyID = regency.RegencyID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override bool Delete()
        {
            try
            {
                Regency regency = db.Regencies.SingleOrDefault(m => m.RegencyID == RegencyID);
                db.Regencies.DeleteOnSubmit(regency);
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