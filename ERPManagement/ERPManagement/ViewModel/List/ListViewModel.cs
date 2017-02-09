using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.List
{
    class ListViewModel : BaseViewModel
    {
        private String name = null;
        private String note = null;

        public String Name
        {
            get { return name; }
            set
            {
                if (name != null)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public String Note
        {
            get { return note; }
            set
            {
                if (note != null)
                {
                    note = value;
                    RaisePropertyChanged("Note");
                }
            }
        }
    }
}