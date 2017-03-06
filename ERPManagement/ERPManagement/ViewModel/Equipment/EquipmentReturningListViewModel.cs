using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method = "EquipmentReturning")]
    public class EquipmentReturningListViewModel : ItemListViewModel<EquipmentReturningViewModel>
    {
        #region Variables
        private ObservableCollection<EquipmentReturningDetailViewModel> details = null;
        private ObservableCollection<EquipmentReturningPersonViewModel> senders, receivers = null;
        #endregion

        #region Properties
        public ObservableCollection<EquipmentReturningDetailViewModel> Details
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

        public ObservableCollection<EquipmentReturningPersonViewModel> Senders
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

        public ObservableCollection<EquipmentReturningPersonViewModel> Receivers
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

        public EquipmentReturningListViewModel() : base()
        {
            foreach (var eqReturning in EquipmentReturningViewModel.Gets())
            {
                Items.Add(eqReturning);
                eqReturning.Deleted += new System.Windows.RoutedEventHandler(EqReturning_Deleted);
            }
        }

        private void EqReturning_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentReturningViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.Profession.EquipmentReturningView frmEquipmentReturning = new View.Profession.EquipmentReturningView();
            EquipmentReturningViewModel equipmentReturningvm = new EquipmentReturningViewModel();
            equipmentReturningvm.ItemAction += new ActionEventHandler(EquipmentReturningvm_ItemAction);
            frmEquipmentReturning.DataContext = equipmentReturningvm;
            frmEquipmentReturning.ShowDialog();
        }

        private void EquipmentReturningvm_ItemAction(object sender, ActionEventArgs e)
        {
            Items.Add((EquipmentReturningViewModel)sender);
        }

        protected override void OnSelectedItemChanged(EquipmentReturningViewModel oldValue, EquipmentReturningViewModel newValue)
        {
            Details = newValue.Details;
            Senders = newValue.Senders;
            Receivers = newValue.Receivers;
        }
    }
}