using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "UnitMeasure")]
    class UnitMeasureViewModel : ListViewModel
    {
        public static IEnumerable<UnitMeasureViewModel> GetUnitMeasures()
        {
            List<UnitMeasureViewModel> unitMeasurevms = new List<UnitMeasureViewModel>();
            var unitMeasures = from p in db.UnitMeasures
                               select p;
            foreach (var unitMeasure in unitMeasures)
            {
                UnitMeasureViewModel unitMeasurevm = new UnitMeasureViewModel();
                unitMeasurevm.unitMeasureID = unitMeasure.UnitMeasureID;
                unitMeasurevm.Code = unitMeasure.Code;
                unitMeasurevm.Name = unitMeasure.Name;
                unitMeasurevm.Note = unitMeasure.Note;
                unitMeasurevm.isInserted = false;
                unitMeasurevms.Add(unitMeasurevm);
            }
            return unitMeasurevms;
        }

        public static UnitMeasureViewModel GetUnitMeasure(int unitMeasureID)
        {
            var unitMeasure = db.UnitMeasures.SingleOrDefault(m => m.UnitMeasureID == unitMeasureID);
            if (unitMeasure == null)
                return null;
            UnitMeasureViewModel unitMeasurevm = new UnitMeasureViewModel();
            unitMeasurevm.unitMeasureID = unitMeasure.UnitMeasureID;
            unitMeasurevm.Code = unitMeasure.Code;
            unitMeasurevm.Name = unitMeasure.Name;
            unitMeasurevm.Note = unitMeasure.Note;
            unitMeasurevm.isInserted = false;
            return unitMeasurevm;
        }

        #region Variables
        private Int32 unitMeasureID;
        #endregion

        #region Properties
        public Int32 UnitMeasureID
        {
            get { return unitMeasureID; }
        }
        #endregion

        public UnitMeasureViewModel() : base()
        {

        }

        protected override void Save(RadWindow window)
        {
            UnitMeasure unitMeasure = null;
            if (isInserted)
            {
                unitMeasure = new UnitMeasure();
                db.UnitMeasures.InsertOnSubmit(unitMeasure);
            }
            else
            {
                unitMeasure = db.UnitMeasures.SingleOrDefault(m => m.UnitMeasureID == UnitMeasureID);
            }
            if (unitMeasure != null)
            {
                unitMeasure.Code = Code;
                unitMeasure.Name = Name;
                unitMeasure.Note = Note;
                db.SubmitChanges();
                unitMeasureID = unitMeasure.UnitMeasureID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override bool Delete()
        {
            try
            {
                UnitMeasure unitMeasure = db.UnitMeasures.SingleOrDefault(m => m.UnitMeasureID == UnitMeasureID);
                db.UnitMeasures.DeleteOnSubmit(unitMeasure);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
    }
}