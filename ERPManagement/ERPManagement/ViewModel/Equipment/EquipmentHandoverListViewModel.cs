using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method = "EquipmentHandover")]
    public class EquipmentHandoverListViewModel : ItemListViewModel<EquipmentHandoverViewModel>
    {
        #region Variables
        private ObservableCollection<EquipmentHandoverDetailViewModel> details = null;
        private ObservableCollection<EquipmentHandoverPersonViewModel> senders, receivers;
        #endregion

        #region Properties
        public ObservableCollection<EquipmentHandoverDetailViewModel> Details
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

        public ObservableCollection<EquipmentHandoverPersonViewModel> Senders
        {
            get { return senders; }
            set
            {
                if (senders != value)
                {
                    senders = value;
                    RaisePropertyChanged("Senders");
                }
            }
        }

        public ObservableCollection<EquipmentHandoverPersonViewModel> Receivers
        {
            get { return receivers; }
            set
            {
                if (receivers != value)
                {
                    receivers = value;
                    RaisePropertyChanged("Receivers");
                }
            }
        }
        #endregion

        public EquipmentHandoverListViewModel() : base()
        {
            foreach (var eqHandover in EquipmentHandoverViewModel.Gets())
            {
                Items.Add(eqHandover);
                eqHandover.Deleted += new System.Windows.RoutedEventHandler(EqHandover_Deleted);
            }
        }

        private void EqHandover_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentHandoverViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.Profession.EquipmentHandoverView frmEquipmentHandover = new View.Profession.EquipmentHandoverView();
            EquipmentHandoverViewModel equipmentHandovervm = new EquipmentHandoverViewModel();
            equipmentHandovervm.ItemAction += new ActionEventHandler(EquipmentHandovervm_ItemAction);
            frmEquipmentHandover.DataContext = equipmentHandovervm;
            frmEquipmentHandover.ShowDialog();
        }

        private void EquipmentHandovervm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((EquipmentHandoverViewModel)sender);
            }
        }

        protected override void OnSelectedItemChanged(EquipmentHandoverViewModel oldValue, EquipmentHandoverViewModel newValue)
        {
            Details = newValue.Details;
            Senders = newValue.Senders;
            Receivers = newValue.Receivers;
        }
    }
}