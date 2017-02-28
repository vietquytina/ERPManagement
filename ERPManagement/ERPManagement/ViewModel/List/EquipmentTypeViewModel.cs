using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "EquipmentType")]
    public class EquipmentTypeViewModel : ListViewModel
    {
        public static IEnumerable<EquipmentTypeViewModel> GetTypes()
        {
            List<EquipmentTypeViewModel> eqTypes = new List<EquipmentTypeViewModel>();
            var equipmentTypes = from p in db.EquipmentTypes
                                 select p;
            foreach (var equipmentType in equipmentTypes)
            {
                EquipmentTypeViewModel eqType = new EquipmentTypeViewModel();
                eqType.typeID = equipmentType.EquipmentTypeID;
                eqType.Name = equipmentType.Name;
                eqType.Note = equipmentType.Note;
                eqType.isInserted = false;
                eqTypes.Add(eqType);
            }
            return eqTypes;
        }

        public static EquipmentTypeViewModel GetTypeByID(Int32 typeID)
        {
            var equipmentType = db.EquipmentTypes.SingleOrDefault(m => m.EquipmentTypeID == typeID);
            if (equipmentType == null)
                return null;
            EquipmentTypeViewModel eqType = new EquipmentTypeViewModel();
            eqType.typeID = equipmentType.EquipmentTypeID;
            eqType.Name = equipmentType.Name;
            eqType.Note = equipmentType.Note;
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
                eqType = db.EquipmentTypes.SingleOrDefault(m => m.EquipmentTypeID == TypeID);
            }
            if (isInserted)
            {
                eqType.Name = Name;
                eqType.Note = Note;
                db.SubmitChanges();
                typeID = eqType.EquipmentTypeID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            try
            {
                EquipmentType eqType = db.EquipmentTypes.SingleOrDefault(m => m.EquipmentTypeID == TypeID);
                db.EquipmentTypes.DeleteOnSubmit(eqType);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            ERPManagement.View.List.EquipmentTypeView frmEqType = new View.List.EquipmentTypeView();
            EquipmentTypeViewModel eqTypevm = GetTypeByID(TypeID);
            eqTypevm.ItemAction += new ActionEventHandler(EqTypevm_ItemAction);
            frmEqType.DataContext = eqTypevm;
            frmEqType.ShowDialog();
        }

        private void EqTypevm_ItemAction(object sender, ActionEventArgs e)
        {
            EquipmentTypeViewModel eqTypevm = (EquipmentTypeViewModel)sender;
            Name = eqTypevm.Name;
            Note = eqTypevm.Note;
        }
    }
}