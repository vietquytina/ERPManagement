using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERPManagement.View.List;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "Company")]
    public class CompanyListViewModel : ItemListViewModel<CompanyViewModel>
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
            Company frmCompany = new Company();
            CompanyViewModel companyvm = new CompanyViewModel();
            companyvm.ItemAction += new ActionEventHandler(Companyvm_ItemAction);
            frmCompany.DataContext = companyvm;
            frmCompany.ShowDialog();
        }

        private void Companyvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((CompanyViewModel)sender);
            }
        }
    }
}