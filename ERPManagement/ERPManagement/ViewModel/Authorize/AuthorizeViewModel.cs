using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ERPManagement.ViewModel.Authorize
{
    public class AuthorizeViewModel : BaseNotify
    {
        #region Properties
        public Boolean CanRead { get; set; }

        public Boolean CanWrite { get; set; }

        public Boolean CanDelete { get; set; }

        public Boolean CanAccept { get; set; }
        #endregion

        public AuthorizeViewModel() : base()
        {
            var authAttr = (ERPManagement.ViewModel.Authorize.AuthorizeAttribute)GetType().GetCustomAttributes(true)[0];
            var methodPers = App.Employee.Permissions.SingleOrDefault(m => m.MethodName == authAttr.Method);
            if (methodPers != null)
            {
                CanRead = methodPers.CanRead;
                CanWrite = methodPers.CanWrite;
                CanDelete = methodPers.CanDelete;
                CanAccept = methodPers.CanAccept;
            }
            if (!CanRead)
            {
                MessageBox.Show("Ban khong du quyen de truy cap");
                if (Application.Current.Windows.Count > 0)
                {
                    Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
                }
            }
        }
    }
}