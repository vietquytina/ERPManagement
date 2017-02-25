using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "WareHouse")]
    class WareHouseViewModel : ListViewModel
    {
        public static IEnumerable<WareHouseViewModel> GetWareHouses()
        {
            List<WareHouseViewModel> wareHousevms = new List<WareHouseViewModel>();
            var wareHouses = from p in db.WareHouses
                             select p;
            foreach (var wareHouse in wareHouses)
            {
                WareHouseViewModel wareHousevm = new WareHouseViewModel();
                wareHousevm.warehouseID = wareHouse.WareHouseID;
                wareHousevm.Code = wareHouse.Code;
                wareHousevm.Name = wareHouse.Name;
                wareHousevm.Note = wareHouse.Note;
                wareHousevm.isInserted = false;
                wareHousevms.Add(wareHousevm);
            }
            return wareHousevms;
        }

        public static WareHouseViewModel GetWareHouse(Int32 warehouseID)
        {
            WareHouse wareHouse = db.WareHouses.SingleOrDefault(m => m.WareHouseID == warehouseID);
            if (wareHouse == null)
                return null;
            WareHouseViewModel wareHousevm = new WareHouseViewModel();
            wareHousevm.warehouseID = wareHouse.WareHouseID;
            wareHousevm.Code = wareHouse.Code;
            wareHousevm.Name = wareHouse.Name;
            wareHousevm.Note = wareHouse.Note;
            wareHousevm.isInserted = false;
            return wareHousevm;
        }

        #region Variables
        private Int32 warehouseID = 0;
        #endregion

        #region Properties
        public Int32 WareHouseID
        {
            get { return warehouseID; }
        }
        #endregion

        protected override void Save(RadWindow window)
        {
            WareHouse wareHouse = null;
            if (isInserted)
            {
                wareHouse = new WareHouse();
                db.WareHouses.InsertOnSubmit(wareHouse);
            }
            else
            {
                wareHouse = db.WareHouses.SingleOrDefault(m => m.WareHouseID == WareHouseID);
            }
            if (wareHouse != null)
            {
                wareHouse.Code = Code;
                wareHouse.Name = Name;
                wareHouse.Note = Note;
                db.SubmitChanges();
                warehouseID = wareHouse.WareHouseID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            try
            {
                WareHouse wareHouse = db.WareHouses.SingleOrDefault(m => m.WareHouseID == WareHouseID);
                db.WareHouses.DeleteOnSubmit(wareHouse);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            ERPManagement.View.List.WareHouseView frmWareHouse = new View.List.WareHouseView();
            WareHouseViewModel wareHousevm = GetWareHouse(WareHouseID);
            wareHousevm.ItemAction += new ActionEventHandler(WareHousevm_ItemAction);
            frmWareHouse.DataContext = wareHousevm;
            frmWareHouse.ShowDialog();
        }

        private void WareHousevm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Edit)
            {
                WareHouseViewModel wareHousevm = (WareHouseViewModel)sender;
                Code = wareHousevm.Code;
                Name = wareHousevm.Name;
                Note = wareHousevm.Note;
            }
        }
    }
}