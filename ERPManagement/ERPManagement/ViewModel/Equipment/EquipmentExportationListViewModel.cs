using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    public class EquipmentExportationListViewModel : ItemListViewModel<EquipmentExportationViewModel>
    {
        #region Variables
        private ObservableCollection<EquipmentExportationDetailViewModel> details = null;
        #endregion

        #region Properties
        public ObservableCollection<EquipmentExportationDetailViewModel> Details
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
        #endregion

        public EquipmentExportationListViewModel() : base()
        {
            foreach (var eqExport in EquipmentExportationViewModel.Gets())
            {
                Items.Add(eqExport);
                eqExport.Deleted += new System.Windows.RoutedEventHandler(EqExport_Deleted);
            }
        }

        private void EqExport_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentExportationViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.Profession.EquipmentExportationView frmEquipmentExport = new View.Profession.EquipmentExportationView();
            EquipmentExportationViewModel eqExportvm = new EquipmentExportationViewModel();
            eqExportvm.ItemAction += new ActionEventHandler(EqExportvm_ItemAction);
            frmEquipmentExport.DataContext = eqExportvm;
            frmEquipmentExport.ShowDialog();
        }

        private void EqExportvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                EquipmentExportationViewModel eqExportvm = (EquipmentExportationViewModel)sender;
                Items.Add(eqExportvm);
            }
        }

        protected override void OnSelectedItemChanged(EquipmentExportationViewModel oldValue, EquipmentExportationViewModel newValue)
        {
            Details = newValue.Details;
        }
    }
}