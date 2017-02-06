using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ERPManagement.ViewModel
{
    class BaseViewModel : BaseNotify
    {
        protected Boolean isInserted = true;
        private ICommand saveCommand, closeCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand<Telerik.Windows.Controls.RadWindow>((wnd) =>
                    {
                        Save(wnd);
                    });
                }
                return saveCommand;
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand<Telerik.Windows.Controls.RadWindow>((wnd) =>
                    {
                        Close(wnd);
                    });
                }
                return closeCommand;
            }
        }


        protected virtual void Save(Telerik.Windows.Controls.RadWindow window)
        {

        }

        protected void Close(Telerik.Windows.Controls.RadWindow window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}