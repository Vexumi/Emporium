using Emporium.Infrastructure;
using Emporium.Infrastructure.Enums;
using Emporium.Interfaces;
using Emporium.Models;
using Emporium.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Emporium.Infrastructure.WindowExtensions;
namespace Emporium.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private User _user;
        private Window _view;
        public ICommand OpenWindowCommand { get; set; }

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

            this.OpenWindowCommand = new RelayCommand(async o => await OpenWindow(Enum.Parse<WindowType>(o.ToString())));
        }

        private async Task OpenWindow(WindowType windowType)
        {
            switch (windowType)
            {
                case WindowType.Products:
                    {
                        var uc = new ProductsControl();
                        AddControlToView(uc, this._view);
                        await uc.LoadData();
                        break;
                    }
                default: break;
            }
        }
    }
}
