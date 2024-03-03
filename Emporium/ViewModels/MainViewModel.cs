using AutoMapper;
using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Infrastructure.Enums;
using Emporium.Models;
using Emporium.Models.Dto;
using Emporium.Services;
using Emporium.ViewModels.DialogWindows;
using Emporium.Views.DialogWindows;
using Microsoft.EntityFrameworkCore;
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
        private readonly ProductDetailsViewModel _productDetailsViewModel;
        private readonly IMapper _mapper;

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

        public MainViewModel(ProductsService productsService, IMapper mapper, ProductDetailsViewModel productDetailsViewModel)
        {
            this._productsService = productsService;
            this._mapper = mapper;
            this.OpenWindowCommand = new RelayCommand(async o => await OpenWindow(Enum.Parse<WindowType>(o.ToString())));
            this.ChangePageCommand = new RelayCommand(o => ChangePage(o.ToString()));
            _productDetailsViewModel = productDetailsViewModel;
        }

        public async void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (this._openedWindow)
            {
                case WindowType.Products:
                    {
                        var row = (DataGridRow)sender;
                        var item = (ProductDto)row.Item;
                        var product = await this._productsService.FindById(item.ProductId).FirstOrDefaultAsync();
                        var dialogWindow = new ProductDetailsWindow(product, this._productDetailsViewModel);
                        dialogWindow.ShowDialog();
                        break;
                    }
                default: break;
            }
            await this.ReloadPage();
        }

        private async Task ReloadPage()
        {
            switch (this._openedWindow)
            {
                case WindowType.Products:
                    {
                        var items = await this._productsService.GetAll(this._paginator).ToListAsync();
                        this._dataGrid.ItemsSource = this._mapper.Map<ProductDto[]>(items);
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
