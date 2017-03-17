using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    public class NationalListViewModel : ItemListViewModel<NationalViewModel>
    {
        public NationalListViewModel() : base()
        {
            foreach (var national in NationalViewModel.GetNationals())
            {
                Items.Add(national);
                national.Deleted += new System.Windows.RoutedEventHandler(National_Deleted);
            }
        }

        private void National_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((NationalViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            View.List.NationalView frmNational = new View.List.NationalView();
            NationalViewModel nationalvm = new NationalViewModel();
            nationalvm.ItemAction += new ActionEventHandler(Nationalvm_ItemAction);
            frmNational.DataContext = nationalvm;
            frmNational.ShowDialog();
        }

        private void Nationalvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((NationalViewModel)sender);
            }
        }
    }
}