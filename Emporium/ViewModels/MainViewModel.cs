using Emporium.Models;
using Emporium.Views;
using Emporium.Views.UserControls;
using System.Windows;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Emporium.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private User _user;
        private Window _view;

        public User CurrentUser
        {
            get { return this._user; }
            set
            {
                _user = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        public MainViewModel(Window view, User user)
        {
            this._view = view;
            this.CurrentUser = user;
        }
    }
}
