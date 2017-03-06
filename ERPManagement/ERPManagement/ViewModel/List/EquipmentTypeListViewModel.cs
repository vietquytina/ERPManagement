using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "EquipmentType")]
    public class EquipmentTypeListViewModel : ItemListViewModel<EquipmentTypeViewModel>
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

        protected override void OnNewCommandClick()
        {
            ERPManagement.View.List.EquipmentTypeView frmEquipmentType = new View.List.EquipmentTypeView();
            EquipmentTypeViewModel eqTypevm = new EquipmentTypeViewModel();
            frmEquipmentType.DataContext = eqTypevm;
            eqTypevm.ItemAction += new ActionEventHandler(EqTypevm_ItemAction);
            frmEquipmentType.ShowDialog();
        }

        private void EqTypevm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((EquipmentTypeViewModel)sender);
            }
        }
    }
}