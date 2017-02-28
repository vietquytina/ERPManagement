using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using System.Reflection;

namespace ERPManagement.ViewModel.Equipment
{
    public class EquipmentViewModel : BaseViewModel
    {
        #region Variables
        private String number, note;
        private DateTime date = DateTime.Now;
        private Int32 statusID = 0;
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

        public Int32 StatusID
        {
            get { return statusID; }
            set
            {
                if (statusID != value)
                {
                    statusID = value;
                    RaisePropertyChanged("StatusID");
                }
            }
        }
        #endregion

        public EquipmentViewModel() : base()
        {

        }

        protected void SyncIndex(IEnumerable<EquipmentDetailViewModel> details)
        {
            int index = 0;
            foreach(var detail in details)
            {
                detail.Index = index++;
            }
        }

        protected void SyncIndex(IEnumerable details)
        {
            int index = 0;
            foreach(var detail in details)
            {
                PropertyInfo pi = detail.GetType().GetProperty("Index");
                if (pi != null)
                {
                    pi.SetValue(detail, index, null);
                    index++;
                }
            }
        }
    }
}