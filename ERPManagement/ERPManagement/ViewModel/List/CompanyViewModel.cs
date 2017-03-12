using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "Company")]
    public class CompanyViewModel : ListViewModel
    {
        public static IEnumerable<CompanyViewModel> GetCompanies()
        {
            var companies = from p in db.Companies
                            select p;
            List<CompanyViewModel> companyvms = new List<CompanyViewModel>();
            foreach (var company in companies)
            {
                CompanyViewModel companyvm = new CompanyViewModel();
                companyvm.companyID = company.CompanyID;
                companyvm.Code = company.Code;
                companyvm.Name = company.Name;
                companyvm.PhoneNumber = company.PhoneNumber;
                companyvm.Email = company.Email;
                companyvm.isInserted = false;
                companyvms.Add(companyvm);
            }
            return companyvms;
        }

        public static CompanyViewModel GetCompany(Int32 companyID)
        {
            var company = db.Companies.SingleOrDefault(m => m.CompanyID == companyID);
            if (company == null)
                return null;
            CompanyViewModel companyvm = new CompanyViewModel();
            companyvm.companyID = company.CompanyID;
            companyvm.Code = company.Code;
            companyvm.Name = company.Name;
            companyvm.PhoneNumber = company.PhoneNumber;
            companyvm.Email = company.Email;
            companyvm.isInserted = false;
            return companyvm;
        }

        #region Variables
        private Int32 companyID;
        private String phoneNumber, email;
        #endregion

        #region Properties
        public Int32 CompanyID
        {
            get { return companyID; }
        }

        public String PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    RaisePropertyChanged("PhoneNumber");
                }
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
                }
            }
        }
        #endregion

        public CompanyViewModel() : base()
        {

        }

        protected override void Save(RadWindow window)
        {
            Company company = null;
            if (isInserted)
            {
                company = new Company();
                db.Companies.InsertOnSubmit(company);
            }
            else
            {
                company = db.Companies.SingleOrDefault(m => m.CompanyID == CompanyID);
            }
            if (company != null)
            {
                company.Code = Code;
                company.Name = Name;
                company.PhoneNumber = PhoneNumber;
                company.Email = Email;
                db.SubmitChanges();
                companyID = company.CompanyID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override bool Delete()
        {
            try
            {
                Company company = db.Companies.SingleOrDefault(m => m.CompanyID == CompanyID);
                db.Companies.DeleteOnSubmit(company);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {
            ERPManagement.View.List.Company frmCompany = new View.List.Company();
            CompanyViewModel companyvm = GetCompany(CompanyID);
            frmCompany.DataContext = companyvm;
            companyvm.ItemAction += new ActionEventHandler(Companyvm_ItemAction);
            frmCompany.ShowDialog();
        }

        private void Companyvm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Edit)
            {
                CompanyViewModel companyvm = (CompanyViewModel)sender;
                Code = companyvm.Code;
                Name = companyvm.Name;
                PhoneNumber = companyvm.PhoneNumber;
                Email = companyvm.Email;
            }
        }
    }
}