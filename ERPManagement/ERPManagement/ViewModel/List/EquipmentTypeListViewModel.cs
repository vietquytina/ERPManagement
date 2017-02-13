using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class EquipmentTypeListViewModel : ItemListViewModel<EquipmentTypeViewModel>
    {
        public EquipmentTypeListViewModel() : base()
        {
            foreach (var it in EquipmentTypeViewModel.GetTypes())
            {
                Items.Add(it);
                it.Deleted += new System.Windows.RoutedEventHandler(It_Deleted);
            }
        }

        private void It_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentTypeViewModel)sender);
        }
    }
}