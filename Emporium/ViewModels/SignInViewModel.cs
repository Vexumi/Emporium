using Emporium.Infrastructure;
using Emporium.Services;
using Emporium.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

        private readonly SignInService _signInService;
        private readonly Window _view;
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

        public SignInViewModel(Window view)
        {
            SignInButtonCommand = new RelayCommand(o => SignIn());
            _signInService = new SignInService();
            _view = view;
        }

        public async Task SignIn()
        {
            var user = await _signInService.SignIn(Email, Password);
            if (user == null) {
                MessageBoxExtensions.IncorrectPassword();
                return;
            }

            OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            var mainWindow = new MainWindow();
            _view.Owner = mainWindow;
            _view.Hide();
            mainWindow.Show();
        }
    }
}
