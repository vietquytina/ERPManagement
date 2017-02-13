using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class StatusListViewModel : ItemListViewModel<StatusViewModel>
    {
        public StatusListViewModel() : base()
        {
            foreach (var status in StatusViewModel.GetStatuses())
            {
                Items.Add(status);
            }
        }
    }
}