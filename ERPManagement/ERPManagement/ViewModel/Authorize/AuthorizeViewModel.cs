using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ERPManagement.ViewModel.Authorize
{
    public class AuthorizeViewModel : BaseNotify
    {
        #region Variables
        private Boolean canRead, canWrite, canDel, canAccept;
        #endregion

        #region Properties
        public Boolean CanRead
        {
            get { return canRead; }
            set
            {
                if (canRead != value)
                {
                    canRead = value;
                    if (!canRead)
                    {
                        CanWrite = CanDelete = CanAccept = false;
                    }
                    RaisePropertyChanged("CanRead");
                }
            }
        }

        public Boolean CanWrite
        {
            get { return canWrite; }
            set
            {
                if (canWrite != value)
                {
                    canWrite = value;
                    RaisePropertyChanged("CanWrite");
                }
            }
        }

        public Boolean CanDelete
        {
            get { return canDel; }
            set
            {
                if (canDel != value)
                {
                    canDel = value;
                    RaisePropertyChanged("CanDelete");
                }
            }
        }

        public Boolean CanAccept
        {
            get { return canAccept; }
            set
            {
                if (canAccept != value)
                {
                    canAccept = value;
                    RaisePropertyChanged("CanAccept");
                }
            }
        }
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
        }
    }
}