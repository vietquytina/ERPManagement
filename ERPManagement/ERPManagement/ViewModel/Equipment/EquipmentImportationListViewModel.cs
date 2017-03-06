using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method = "EquipmentImportation")]
    public class EquipmentImportationListViewModel : ItemListViewModel<EquipmentImportationViewModel>
    {
        private ObservableCollection<EquipmentImportationDetailViewModel> details;

        public ObservableCollection<EquipmentImportationDetailViewModel> Details
        {
            get { return details; }
            set
            {
                if (details != value)
                {
                    details = value;
                    RaisePropertyChanged("Details");
                }
            }
        }

        public EquipmentImportationListViewModel() : base()
        {
            foreach (var equipmentImport in EquipmentImportationViewModel.Gets())
            {
                Items.Add(equipmentImport);
                equipmentImport.Deleted += new System.Windows.RoutedEventHandler(EquipmentImport_Deleted);
            }
        }

        private void EquipmentImport_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentImportationViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.Profession.EquipmentImportationView frmEquipmentImport = new View.Profession.EquipmentImportationView();
            EquipmentImportationViewModel equipmentImportvm = new EquipmentImportationViewModel();
            equipmentImportvm.ItemAction += new ActionEventHandler(EquipmentImportvm_ItemAction);
            frmEquipmentImport.DataContext = equipmentImportvm;
            frmEquipmentImport.ShowDialog();
        }

        private void EquipmentImportvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((EquipmentImportationViewModel)sender);
            }
        }

        protected override void OnSelectedItemChanged(EquipmentImportationViewModel oldValue, EquipmentImportationViewModel newValue)
        {
            Details = newValue.Details;
        }
    }
}