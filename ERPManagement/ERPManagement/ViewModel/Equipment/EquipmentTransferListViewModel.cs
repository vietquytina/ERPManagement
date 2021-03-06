﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method = "EquipmentTransfer")]
    public class EquipmentTransferListViewModel : ItemListViewModel<EquipmentTransferViewModel>
    {
        #region Variables
        private ObservableCollection<EquipmentTransferDetailViewModel> details = null;
        private ObservableCollection<EquipmentTransferPersonViewModel> senders, receivers;
        #endregion

        #region Properties
        public ObservableCollection<EquipmentTransferDetailViewModel> Details
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

        public ObservableCollection<EquipmentTransferPersonViewModel> Senders
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

        public ObservableCollection<EquipmentTransferPersonViewModel> Receivers
        {
            get { return receivers; }
            set
            {
                if (receivers != value)
                {
                    receivers = value;
                    RaisePropertyChanged("Senders");
                }
            }
        }
        #endregion

        public EquipmentTransferListViewModel() : base()
        {
            foreach (var equipmentTransfer in EquipmentTransferViewModel.Gets())
            {
                Items.Add(equipmentTransfer);
                equipmentTransfer.Deleted += new System.Windows.RoutedEventHandler(EquipmentTransfer_Deleted);
            }
        }

        private void EquipmentTransfer_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentTransferViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.Profession.EquipmentTransferingView frmEqTransfer = new View.Profession.EquipmentTransferingView();
            EquipmentTransferViewModel equipmentTransfervm = new EquipmentTransferViewModel();
            equipmentTransfervm.ItemAction += new ActionEventHandler(EquipmentTransfervm_ItemAction);
            frmEqTransfer.DataContext = equipmentTransfervm;
            frmEqTransfer.ShowDialog();
        }

        private void EquipmentTransfervm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((EquipmentTransferViewModel)sender);
            }
        }

        protected override void OnSelectedItemChanged(EquipmentTransferViewModel oldValue, EquipmentTransferViewModel newValue)
        {
            Details = newValue.Details;
            Senders = newValue.Senders;
            Receivers = newValue.Receivers;
        }
    }
}