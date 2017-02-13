using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ERPManagement.ViewModel
{
    class ItemListViewModel<T> : BaseNotify
    {
        private ICommand newCommand = null;

        public ObservableCollection<T> Items { get; set; }

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(() =>
                    {
                        OnNewCommandClick();
                    });
                }
                return newCommand;
            }
        }

        public ItemListViewModel()
        {
            Items = new ObservableCollection<T>();
        }

        protected virtual void OnNewCommandClick()
        {

        }
    }
}