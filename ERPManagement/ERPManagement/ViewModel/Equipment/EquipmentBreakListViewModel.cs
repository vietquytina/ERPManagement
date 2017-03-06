using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method = "EquipmentBreak")]
    public class EquipmentBreakListViewModel : ItemListViewModel<EquipmentBreakViewModel>
    {
        public EquipmentBreakListViewModel() : base()
        {
            foreach (var equipmentBreak in EquipmentBreakViewModel.GetEquipmentBreaks())
            {
                Items.Add(equipmentBreak);
                equipmentBreak.Deleted += new System.Windows.RoutedEventHandler(EquipmentBreak_Deleted);
            }
        }

        private void EquipmentBreak_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentBreakViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.Profession.EquipmentBreakDownView frmEquipmentBreak = new View.Profession.EquipmentBreakDownView();
            EquipmentBreakViewModel equipmentBreakvm = new EquipmentBreakViewModel();
            equipmentBreakvm.ItemAction += new ActionEventHandler(EquipmentBreakvm_ItemAction);
            frmEquipmentBreak.DataContext = equipmentBreakvm;
            frmEquipmentBreak.ShowDialog();
        }

        private void EquipmentBreakvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((EquipmentBreakViewModel)sender);
            }
        }
    }
}