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

        protected override void OnNewCommandClick()
        {
            View.List.EquipmentView frmEquipment = new View.List.EquipmentView();
            EquipmentViewModel equipmentvm = new EquipmentViewModel();
            frmEquipment.DataContext = equipmentvm;
            equipmentvm.ItemAction += new ActionEventHandler(Equipmentvm_ItemAction);
            frmEquipment.ShowDialog();
        }

        private void Equipmentvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((EquipmentViewModel)sender);
            }
        }
    }
}