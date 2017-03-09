using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method = "EquipmentStatusNoteBook")]
    public class EquipmentStatusNoteBookListViewModel : ItemListViewModel<EquipmentStatusNoteBookViewModel>
    {
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
        }

        protected override void OnSelectedItemChanged(EquipmentStatusNoteBookViewModel oldValue, EquipmentStatusNoteBookViewModel newValue)
        {

        }
    }
}