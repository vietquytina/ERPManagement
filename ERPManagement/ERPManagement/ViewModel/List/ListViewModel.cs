﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;

namespace ERPManagement.ViewModel.List
{
    class ListViewModel : BaseViewModel
    {
        #region Variables
        private String name = null;
        private String note = null;
        private String code = null;
        
        #endregion

        #region Properties
        public String Code
        {
            get { return code; }
            set
            {
                if (code != null)
                {
                    code = value;
                    RaisePropertyChanged("Code");
                }
            }
        }

        public String Name
        {
            get { return name; }
            set
            {
                if (name != null)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public String Note
        {
            get { return note; }
            set
            {
                if (note != null)
                {
                    note = value;
                    RaisePropertyChanged("Note");
                }
            }
        }
        #endregion
    }
}