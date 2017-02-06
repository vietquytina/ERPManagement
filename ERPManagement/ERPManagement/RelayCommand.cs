using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ERPManagement
{
    class RelayCommand : ICommand
    {
        private Action action = null;
        private Predicate<Object> predicate = null;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public RelayCommand(Action action, Predicate<Object> predicate)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (predicate != null)
                return predicate(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            if (action != null)
            {
                action();
            }
        }
    }

    class RelayCommand<T> : ICommand
    {
        private Action<T> action = null;
        private Predicate<T> predicate = null;

        public RelayCommand(Action<T> action)
        {
            this.action = action;
        }

        public RelayCommand(Action<T> action, Predicate<T> predicate)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (predicate != null)
                return predicate((T)parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            if (action != null)
            {
                action((T)parameter);
            }
        }
    }
}