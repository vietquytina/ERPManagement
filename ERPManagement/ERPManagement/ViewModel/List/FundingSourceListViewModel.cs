using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class FundingSourceListViewModel : ItemListViewModel<FundingSourceViewModel>
    {
        public FundingSourceListViewModel() : base()
        {
            foreach (var fdSource in FundingSourceViewModel.GetFundings())
            {
                Items.Add(fdSource);
                fdSource.Deleted += new System.Windows.RoutedEventHandler(FdSource_Deleted);
            }
        }

        private void FdSource_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((FundingSourceViewModel)sender);
        }
    }
}