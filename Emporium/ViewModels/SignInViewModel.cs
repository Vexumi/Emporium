using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using Emporium.Views;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emporium.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public ICommand SignInButtonCommand { get; set; }

        private readonly SignInService _signInService;
        private readonly MainViewModel _mainViewModel;
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

        public SignInViewModel(SignInService signInService, MainViewModel mainViewModel)
        {
            _signInService = signInService;
            _mainViewModel = mainViewModel;

            SignInButtonCommand = new RelayCommand(async o => await SignIn());
        }

        public async Task SignIn()
        {
            /*var user = await _signInService.SignIn(Email, Password);
            if (user == null)
            {
                MessageBoxExtensions.IncorrectPassword();
                return;
            }*/

            var user = new User()
            {
                UserId = 0,
                FullName = "Gaag Gleb Alexandrovich",
                Phone = "88005553535",
                Email = "admin",
                Password = "admin",
                AccountType = 0
            };

            OpenMainWindow(user);
        }

        private void OpenMainWindow(User user)
        {
            var mainWindow = new MainWindow(user, this._mainViewModel);
            mainWindow.Show();

            CloseLoginWindow();
        }

        private void CloseLoginWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is SignInWindow)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
