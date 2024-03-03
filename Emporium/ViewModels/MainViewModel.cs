using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Infrastructure.Enums;
using Emporium.Models;
using Emporium.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Emporium.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ProductsService _productsService;

        private User _user;
        private Window _window;
        private WindowType _openedWindow;
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

        public Window CurrentWindow
        {
            get { return this._window; }
            set
            {
                _window = value;
                OnPropertyChanged("CurrentWindow");
            }
        }

        public MainViewModel(ProductsService productsService)
        {
            this._productsService = productsService;
            this.OpenWindowCommand = new RelayCommand(async o => await OpenWindow(Enum.Parse<WindowType>(o.ToString())));
        }

        private async Task OpenWindow(WindowType windowType)
        {
            this._openedWindow = windowType;
            switch (windowType)
            {
                case WindowType.Products:
                    {
                        var table = (DataGrid)this._window.FindName("MainTable");
                        table.ItemsSource = await this._productsService.GetAll();
                        break;
                    }
                default: break;
            }
        }
    }
}
