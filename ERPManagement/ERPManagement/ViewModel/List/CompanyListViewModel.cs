using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class CompanyListViewModel : ItemListViewModel<CompanyViewModel>
    {
        public CompanyListViewModel() : base()
        {
            foreach (var company in CompanyViewModel.GetCompanies())
            {
                Items.Add(company);
                company.Deleted += new System.Windows.RoutedEventHandler(Company_Deleted);
            }
        }

        private void Company_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((CompanyViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {

        }
    }
}