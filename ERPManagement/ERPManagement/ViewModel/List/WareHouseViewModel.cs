using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    class WareHouseViewModel : ListViewModel
    {
        public static IEnumerable<WareHouseViewModel> GetWareHouses()
        {
            List<WareHouseViewModel> warehouses = new List<WareHouseViewModel>();
            var _warehouses = from p in db.WareHouses
                              select p;
            foreach (var _warehouse in _warehouses)
            {
                WareHouseViewModel warehouse = new WareHouseViewModel();
                warehouse.warehouseID = _warehouse.WareHouseID;
                warehouse.Name = _warehouse.Name;
                warehouse.Note = _warehouse.Note;
                warehouse.Quality = _warehouse.Quality;
                warehouse.SubjectID = _warehouse.SubjectID;
                warehouse.isInserted = false;
                warehouses.Add(warehouse);
            }
            return warehouses;
        }

        public static WareHouseViewModel GetWareHouse(Int32 warehouseID)
        {
            var _warehouse = db.WareHouses.SingleOrDefault(m => m.WareHouseID == warehouseID);
            if (_warehouse == null)
                return null;
            WareHouseViewModel warehouse = new WareHouseViewModel();
            warehouse.warehouseID = _warehouse.WareHouseID;
            warehouse.Name = _warehouse.Name;
            warehouse.Note = _warehouse.Note;
            warehouse.Quality = _warehouse.Quality;
            warehouse.SubjectID = _warehouse.SubjectID;
            warehouse.isInserted = false;
            return warehouse;
        }

        #region Variables
        private Int32 warehouseID = 0;
        private Int32 quality = 0;
        private Int32? subjectID;
        #endregion

        #region Properties
        public Int32 WareHouseID
        {
            get { return warehouseID; }
        }

        public Int32? SubjectID
        {
            get { return subjectID; }
            set
            {
                if (subjectID != value)
                {
                    subjectID = value;
                    RaisePropertyChanged("SubjectID");
                }
            }
        }

        public Int32 Quality
        {
            get { return quality; }
            set
            {
                if (quality != value)
                {
                    quality = value;
                    RaisePropertyChanged("Quality");
                }
            }
        }
        #endregion

        protected override void Save(RadWindow window)
        {
            WareHouse warehouse = null;
            if (isInserted)
            {
                warehouse = new WareHouse();
                db.WareHouses.InsertOnSubmit(warehouse);
            }
            else
            {
                warehouse = db.WareHouses.SingleOrDefault(m => m.WareHouseID == warehouseID);
            }
            if (warehouse != null)
            {
                warehouse.Name = Name;
                warehouse.Note = Note;
                warehouse.Quality = Quality;
                warehouse.Subject = db.Subjects.SingleOrDefault(m => m.SubjectID == SubjectID);
                db.SubmitChanges();
                warehouseID = warehouse.WareHouseID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            WareHouse warehouse = db.WareHouses.SingleOrDefault(m => m.WareHouseID == warehouseID);
            try
            {
                db.WareHouses.DeleteOnSubmit(warehouse);
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