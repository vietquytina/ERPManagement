using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    public class EquipmentListViewModel : ItemListViewModel<EquipmentViewModel>
    {
        public EquipmentListViewModel() : base()
        {
            foreach (var eq in EquipmentViewModel.GetEquipments())
            {
                Items.Add(eq);
                eq.Deleted += new System.Windows.RoutedEventHandler(Eq_Deleted);
            }
        }

        private void Eq_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentViewModel)sender);
        }
    }
}