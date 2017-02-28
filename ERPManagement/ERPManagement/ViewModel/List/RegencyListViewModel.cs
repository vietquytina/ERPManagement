using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    public class RegencyListViewModel : ItemListViewModel<RegencyViewModel>
    {
        public RegencyListViewModel() : base()
        {
            foreach (var regency in RegencyViewModel.GetRegencies())
            {
                Items.Add(regency);
                regency.Deleted += new System.Windows.RoutedEventHandler(Regency_Deleted);
            }
        }

        private void Regency_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((RegencyViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {
            ERPManagement.View.List.RegencyView frmRegency = new View.List.RegencyView();
            RegencyViewModel regencyvm = new RegencyViewModel();
            regencyvm.ItemAction += new ActionEventHandler(Regencyvm_ItemAction);
            frmRegency.DataContext = regencyvm;
            frmRegency.ShowDialog();
        }

        private void Regencyvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((RegencyViewModel)sender);
            }
        }
    }
}