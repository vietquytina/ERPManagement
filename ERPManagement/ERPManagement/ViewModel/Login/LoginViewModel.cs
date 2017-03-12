using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ERPManagement.ViewModel.Login
{
    public class LoginViewModel : BaseNotify
    {
        private ICommand loginCommand = null;
        private Boolean isVisiblePasswordPlaceHolder = true;
        private Boolean isValidate = false;

        public String UserName { get; set; }

        public Boolean IsVisiblePasswordPlaceHolder
        {
            get { return isVisiblePasswordPlaceHolder; }
            set
            {
                if (isVisiblePasswordPlaceHolder != value)
                {
                    isVisiblePasswordPlaceHolder = value;
                    RaisePropertyChanged("IsVisiblePasswordPlaceHolder");
                }
            }
        }

        public Boolean IsValidate
        {
            get { return isValidate; }
            set
            {
                if (isValidate != value)
                {
                    isValidate = value;
                    RaisePropertyChanged("IsValidate");
                }
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand<PasswordBox>((pw) =>
                    {
                        if (IsNotSqlInjection(UserName) || IsNotSqlInjection(pw.Password))
                        {
                            Boolean lgResult = Employee.EmployeeViewModel.Login(UserName, pw.Password);
                            if (lgResult)
                            {
                                (App.Current as App).Load();
                                MainWindow mainWnd = new MainWindow();
                                Application.Current.MainWindow.Close();
                                mainWnd.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Thông tin bạn nhập không chính xác");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thông tin bạn nhập không hợp lệ");
                        }
                    });
                }
                return loginCommand;
            }
        }

        private Boolean IsNotSqlInjection(String data)
        {
            var s = data.ToLower();
            if (String.IsNullOrEmpty(s))
                return false;
            if (s.IndexOf(' ') != -1)
                return false;
            if (s.IndexOf('~') != -1)
                return false;
            if (s.IndexOf('!') != -1)
                return false;
            if (s.IndexOf('@') != -1)
                return false;
            if (s.IndexOf('#') != -1)
                return false;
            if (s.IndexOf('$') != -1)
                return false;
            if (s.IndexOf('%') != -1)
                return false;
            if (s.IndexOf('^') != -1)
                return false;
            if (s.IndexOf('&') != -1)
                return false;
            if (s.IndexOf('*') != -1)
                return false;
            if (s.IndexOf('(') != -1)
                return false;
            if (s.IndexOf(')') != -1)
                return false;
            if (s.IndexOf('-') != -1)
                return false;
            if (s.IndexOf('_') != -1)
                return false;
            if (s.IndexOf('=') != -1)
                return false;
            if (s.IndexOf('+') != -1)
                return false;
            if (s.IndexOf('[') != -1)
                return false;
            if (s.IndexOf('{') != -1)
                return false;
            if (s.IndexOf('}') != -1)
                return false;
            if (s.IndexOf(']') != -1)
                return false;
            if (s.IndexOf('\\') != -1)
                return false;
            if (s.IndexOf('\"') != -1)
                return false;
            if (s.IndexOf('\'') != -1)
                return false;
            if (s.IndexOf(';') != -1)
                return false;
            if (s.IndexOf(':') != -1)
                return false;
            if (s.IndexOf("create") != -1)
                return false;
            if (s.IndexOf("update") != -1)
                return false;
            if (s.IndexOf("insert") != -1)
                return false;
            if (s.IndexOf("delete") != -1)
                return false;
            if (s.IndexOf("grant") != -1)
                return false;
            if (s.IndexOf("select") != -1)
                return false;
            return true;
        }
    }
}