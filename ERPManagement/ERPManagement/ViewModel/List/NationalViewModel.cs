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
            return nationals;
        }

        public static NationalViewModel GetNational(Int32 nationalID)
        {
            NationalViewModel national = new NationalViewModel();
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