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
            return eqTypes;
        }

        public static EquipmentTypeViewModel GetTypeByID(Int32 typeID)
        {
            EquipmentTypeViewModel eqType = new EquipmentTypeViewModel();
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