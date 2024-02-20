using Emporium.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emporium.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public ICommand SignInButtonCommand { get; set; }

        private string _email;
        private string _password;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public SignInViewModel()
        {
            SignInButtonCommand = new RelayCommand(o => SignIn());
        }

        public void SignIn()
        {
            throw new DivideByZeroException("SignInMethod");
        }
    }
}
