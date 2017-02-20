using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.List
{
    class DepartmentViewModel : ListViewModel
    {
        public DepartmentViewModel()
        {

        }

        protected override void Save(RadWindow window)
        {
        }

        protected override bool Delete()
        {
            return base.Delete();
        }

        protected override void Edit()
        {

        }
    }
}