using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class WareHouseListViewModel : ItemListViewModel<WareHouseViewModel>
    {
        public WareHouseListViewModel() : base()
        {
            foreach (var wareHouse in WareHouseViewModel.GetWareHouses())
            {
                Items.Add(wareHouse);
                wareHouse.Deleted += new System.Windows.RoutedEventHandler(WareHouse_Deleted);
            }
        }

        private void WareHouse_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((WareHouseViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            ERPManagement.View.List.WareHouseView frmWareHouse = new View.List.WareHouseView();
            WareHouseViewModel wareHousevm = new WareHouseViewModel();
            wareHousevm.ItemAction += new ActionEventHandler(WareHousevm_ItemAction);
            frmWareHouse.DataContext = wareHousevm;
            frmWareHouse.ShowDialog();
        }

        private void WareHousevm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((WareHouseViewModel)sender);
            }
        }
    }
}