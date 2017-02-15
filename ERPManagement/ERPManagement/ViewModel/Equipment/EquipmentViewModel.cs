using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentViewModel : BaseViewModel
    {
        #region Variables
        private String number, note;
        private DateTime date = DateTime.Now;
        #endregion

        #region Properties
        public String Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    RaisePropertyChanged("Number");
                }
            }
        }

        public String Note
        {
            get { return note; }
            set
            {
                if (note != value)
                {
                    note = value;
                    RaisePropertyChanged("Note");
                }
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }
        #endregion

        protected void Sync(IEnumerable<EquipmentDetailViewModel> srcDetails, IEnumerable destDetails)
        {
            int i = 0;
            int j = 0;
        }

        protected void SyncIndex(IEnumerable<EquipmentDetailViewModel> details)
        {
            int index = 0;
            foreach(var detail in details)
            {
                detail.Index = index++;
            }
        }
    }
}