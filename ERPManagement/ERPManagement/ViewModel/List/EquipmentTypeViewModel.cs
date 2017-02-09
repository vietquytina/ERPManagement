using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    class EquipmentTypeViewModel : ListViewModel
    {
        public static IEnumerable<EquipmentTypeViewModel> GetTypes()
        {
            List<EquipmentTypeViewModel> eqTypes = new List<EquipmentTypeViewModel>();
            var ts = from p in db.EquipmentTypes
                     select p;
            foreach (var t in ts)
            {
                EquipmentTypeViewModel eqType = new EquipmentTypeViewModel();
                eqType.typeID = t.TypeID;
                eqType.Name = t.Name;
                eqType.Note = t.Note;
                eqType.isInserted = false;
                eqTypes.Add(eqType);
            }
            return eqTypes;
        }

        public static EquipmentTypeViewModel GetTypeByID(Int32 typeID)
        {
            var t = db.EquipmentTypes.SingleOrDefault(m => m.TypeID == typeID);
            if (t == null)
                return null;
            EquipmentTypeViewModel eqType = new EquipmentTypeViewModel();
            eqType.typeID = t.TypeID;
            eqType.Name = t.Name;
            eqType.Note = t.Note;
            eqType.isInserted = false;
            return eqType;
        }

        #region Variables
        private Int32 typeID = 0;
        #endregion

        #region Properties
        public Int32 TypeID
        {
            get { return typeID; }
        }
        #endregion

        public EquipmentTypeViewModel() : base()
        {

        }

        protected override void Save(RadWindow window)
        {
            EquipmentType eqType = null;
            if (isInserted)
            {
                eqType = new EquipmentType();
                db.EquipmentTypes.InsertOnSubmit(eqType);
            }
            else
            {
                eqType = db.EquipmentTypes.SingleOrDefault(m => m.TypeID == TypeID);
                eqType.Name = Name;
                eqType.Note = Note;
                db.SubmitChanges();
                typeID = eqType.TypeID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            try
            {
                EquipmentType eqType = db.EquipmentTypes.SingleOrDefault(m => m.TypeID == TypeID);
                db.EquipmentTypes.DeleteOnSubmit(eqType);
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