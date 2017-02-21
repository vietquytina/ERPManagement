using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class RegencyListViewModel : ItemListViewModel<RegencyViewModel>
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

        }
    }
}