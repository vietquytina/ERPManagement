using ERPManagement.Model;
using System;
using System.ComponentModel;

namespace ERPManagement.ViewModel
{
    public class BaseNotify : INotifyPropertyChanged
    {
        protected static ERPManagementDataContext db = new ERPManagementDataContext();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}