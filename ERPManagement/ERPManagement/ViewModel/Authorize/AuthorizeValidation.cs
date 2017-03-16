using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.Authorize
{
    public static class AuthorizeValidation
    {
        public static Boolean IsAuthorize(this RadWindow wnd)
        {
            AuthorizeViewModel authvm = wnd.DataContext as AuthorizeViewModel;
            return authvm.CanRead;
        }
    }
}