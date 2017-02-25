using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using ERPManagement.Model;

namespace ERPManagement.ViewModel
{
    public enum ViewModelAction : uint
    {
        Add = 1,
        Edit = 2
    }

    public class ActionEventArgs : RoutedEventArgs
    {
        public ViewModelAction Action { get; set; }
    }

    public delegate void ActionEventHandler(object sender, ActionEventArgs e);

    public class BaseViewModel : BaseNotify
    {
        protected static ERPManagementDataContext db = new ERPManagementDataContext();

        public event RoutedEventHandler Deleted;
        public event ActionEventHandler ItemAction;

        #region Variables
        protected Boolean isInserted = true;
        private ICommand saveCommand, closeCommand, deleteCommand, editCommand;
        #endregion

        #region Properties
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand<Telerik.Windows.Controls.RadWindow>((wnd) =>
                    {
                        Save(wnd);
                        if (wnd != null)
                            wnd.Close();
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

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(() =>
                    {
                        if (Delete() && Deleted != null)
                        {
                            Deleted(this, new RoutedEventArgs());
                        }
                    });
                }
                return deleteCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (editCommand == null)
                {
                    editCommand = new RelayCommand(() =>
                    {
                        Edit();
                    });
                }
                return editCommand;
            }
        }
        #endregion

        #region Permission properties
        public Boolean CanRead { get; set; }

        public Boolean CanWrite { get; set; }

        public Boolean CanDelete { get; set; }
        #endregion

        public BaseViewModel()
        {
            var authAttr = (ERPManagement.ViewModel.Authorize.AuthorizeAttribute)GetType().GetCustomAttributes(true)[0];
            var methodPers = App.Employee.Permissions.SingleOrDefault(m => m.MethodName == authAttr.Method);
            if (methodPers != null)
            {
                CanRead = methodPers.CanRead;
                CanWrite = methodPers.CanWrite;
                CanDelete = methodPers.CanDelete;
            }
        }

        #region Method
        protected virtual void Save(Telerik.Windows.Controls.RadWindow window)
        {

        }

        private void Close(Telerik.Windows.Controls.RadWindow window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        protected virtual void Edit()
        {
        }

        protected virtual Boolean Delete()
        {
            return true;
        }
        #endregion

        protected void RaiseAction(ViewModelAction action)
        {
            if (ItemAction != null)
            {
                ItemAction(this, new ActionEventArgs() { Action = action });
            }
        }
    }
}