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
    public class ListViewModel : BaseViewModel
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
                if (code != value)
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
                if (name != value)
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
                if (note != value)
                {
                    note = value;
                    RaisePropertyChanged("Note");
                }
            }
        }
        #endregion
    }
}