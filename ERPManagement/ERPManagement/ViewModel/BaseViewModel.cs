using System;
using System.Windows;
using System.Windows.Input;

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

    public class BaseViewModel : Authorize.AuthorizeViewModel
    {
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

        public BaseViewModel() : base()
        {
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