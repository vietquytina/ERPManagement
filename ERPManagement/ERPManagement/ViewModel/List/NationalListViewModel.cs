using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class NationalListViewModel : ItemListViewModel<NationalViewModel>
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
    }
}