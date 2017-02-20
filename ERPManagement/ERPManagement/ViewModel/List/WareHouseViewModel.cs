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
            return warehouses;
        }

        public static WareHouseViewModel GetWareHouse(Int32 warehouseID)
        {
            WareHouseViewModel warehouse = new WareHouseViewModel();
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

        }

        protected override Boolean Delete()
        {
            try
            {
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {

        }
    }
}