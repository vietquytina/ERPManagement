﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method = "EquipmentStatusNoteBook")]
    public class EquipmentStatusNoteBookListViewModel : ItemListViewModel<EquipmentStatusNoteBookViewModel>
    {
        private ObservableCollection<EquipmentStatusNoteBookDetailViewModel> details = null;

        public ObservableCollection<EquipmentStatusNoteBookDetailViewModel> Details
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

        public EquipmentStatusNoteBookListViewModel() : base()
        {
            foreach (var eqNoteBook in EquipmentStatusNoteBookViewModel.Gets())
            {
                Items.Add(eqNoteBook);
                eqNoteBook.Deleted += new System.Windows.RoutedEventHandler(EqNoteBook_Deleted);
            }
        }

        private void EqNoteBook_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentStatusNoteBookViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.Profession.EquipmentStatusNoteBookView frmStatusNote = new View.Profession.EquipmentStatusNoteBookView();
            EquipmentStatusNoteBookViewModel eqStatusNote = new EquipmentStatusNoteBookViewModel();
            frmStatusNote.DataContext = eqStatusNote;
            eqStatusNote.ItemAction += new ActionEventHandler(EqStatusNote_ItemAction);
            frmStatusNote.ShowDialog();
        }

        private void EqStatusNote_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((EquipmentStatusNoteBookViewModel)sender);
            }
        }

        protected override void OnSelectedItemChanged(EquipmentStatusNoteBookViewModel oldValue, EquipmentStatusNoteBookViewModel newValue)
        {
            Details = newValue.Details;
        }
    }
}