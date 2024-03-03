using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Infrastructure.Enums;
using Emporium.Models;
using Emporium.Services;
using Emporium.Views.DialogWindows;
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
        private Paginator _paginator;
        private DataGrid _dataGrid;

        public ICommand OpenWindowCommand { get; set; }
        public ICommand ChangePageCommand { get; set; }

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
                this._window = value;
                _dataGrid = (DataGrid)this._window.FindName("MainTable");
                OnPropertyChanged("CurrentWindow");
            }
        }

        public MainViewModel(ProductsService productsService)
        {
            this._productsService = productsService;
            this.OpenWindowCommand = new RelayCommand(async o => await OpenWindow(Enum.Parse<WindowType>(o.ToString())));
            this.ChangePageCommand = new RelayCommand(o => ChangePage(o.ToString()));
        }

        public void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*var row = (DataGridRow)sender;
            var dialogWindow = new ProductDetailsWindow((Product)row.Item, this._productsService);

            dialogWindow.ShowDialog();*/
            MessageBox.Show("Hehe");
        }

        private async Task ReloadPage()
        {
            switch (this._openedWindow)
            {
                case WindowType.Products:
                    {
                        this._dataGrid.ItemsSource = await this._productsService.GetAll(this._paginator);
                        break;
                    }
                default: break;
            }
        }

        private int GetTotalElementsForWindow()
        {
            switch (this._openedWindow)
            {
                case WindowType.Products: return this._productsService.Count();
                default: break;
            }
            return 0;
        }

        private async Task OpenWindow(WindowType windowType)
        {
            this._openedWindow = windowType;
            this._paginator = new Paginator(this.GetTotalElementsForWindow());
            await this.ReloadPage();
        }

        private async Task ChangePage(string page)
        {
            if (page == "Next") _paginator.NextPage();
            else _paginator.PrevPage();

            await this.ReloadPage();
        }
    }
}
