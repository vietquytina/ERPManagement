using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    class FundingSourceViewModel : ListViewModel
    {
        public static IEnumerable<FundingSourceViewModel> GetFundings()
        {
            List<FundingSourceViewModel> fundings = new List<FundingSourceViewModel>();
            var _fundings = from p in db.FundingSources
                            select p;
            foreach (var _funding in _fundings)
            {
                FundingSourceViewModel funding = new FundingSourceViewModel();
                funding.sourceID = _funding.FundingSourceID;
                funding.Name = _funding.Name;
                funding.Note = _funding.Note;
                funding.isInserted = false;
                fundings.Add(funding);
            }
            return fundings;
        }

        public static FundingSourceViewModel GetFunding(Int32 sourceID)
        {
            var _funding = db.FundingSources.SingleOrDefault(m => m.FundingSourceID == sourceID);
            FundingSourceViewModel funding = new FundingSourceViewModel();
            funding.sourceID = _funding.FundingSourceID;
            funding.Name = _funding.Name;
            funding.Note = _funding.Note;
            funding.isInserted = false;
            return funding;
        }

        #region Variables
        private Int32 sourceID = 0;
        #endregion

        #region Properties
        public Int32 SourceID
        {
            get { return sourceID; }
        }
        #endregion

        public FundingSourceViewModel() : base()
        {

        }

        protected override void Save(RadWindow window)
        {
            FundingSource source = null;
            if (isInserted)
            {
                source = new FundingSource();
                db.FundingSources.InsertOnSubmit(source);
            }
            else
            {
                source = db.FundingSources.SingleOrDefault(m => m.FundingSourceID == sourceID);
            }
            if (source != null)
            {
                source.Name = Name;
                source.Note = Note;
                db.SubmitChanges();
                sourceID = source.FundingSourceID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            try
            {
                FundingSource source = db.FundingSources.SingleOrDefault(m => m.FundingSourceID == sourceID);
                db.FundingSources.DeleteOnSubmit(source);
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