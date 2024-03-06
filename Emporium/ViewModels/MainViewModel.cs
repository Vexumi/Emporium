using AutoMapper;
using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Infrastructure.Enums;
using Emporium.Infrastructure.Extensions;
using Emporium.Models;
using Emporium.Models.Dto;
using Emporium.Services;
using Emporium.ViewModels.DialogWindows;
using Emporium.Views.DialogWindows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Emporium.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ProductsService _productsService;
        private readonly OrdersService _ordersService;
        private readonly EmployeesService _employeesService;
        private readonly PickPointsService _pickpointsService;

        private readonly ProductDetailsViewModel _productDetailsViewModel;
        private readonly IMapper _mapper;

        private User _user;
        private Window _window;
        private WindowType _openedWindow;
        private Paginator _paginator;
        private DataGrid _dataGrid;
        private bool _isFilterDescriptionTextBoxEnabled = false;
        private string _filterDescriptionText = "";
        private SortBy _sortByField = SortBy.Unknown;
        private FilterBy _filterByField = FilterBy.Unknown;

        public ICommand OpenWindowCommand { get; set; }
        public ICommand ChangePageCommand { get; set; }
        public ICommand ApplyFiltersCommand { get; set; }

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

        public bool IsFilterDescriptionTextBoxEnabled
        {
            get { return this._isFilterDescriptionTextBoxEnabled; }
            set
            {
                this._isFilterDescriptionTextBoxEnabled = value;
                OnPropertyChanged("IsFilterDescriptionTextBoxEnabled");
            }
        }

        public string FilterDescriptionText
        {
            get { return this._filterDescriptionText; }
            set
            {
                this._filterDescriptionText = value;
                OnPropertyChanged("FilterDescriptionText");
            }
        }

        public SortBy SortByField
        {
            get { return this._sortByField; }
            set
            {
                this._sortByField = value;
                OnPropertyChanged("SortByField");
            }
        }

        public FilterBy FilterByField
        {
            get { return this._filterByField; }
            set
            {
                this._filterByField = value;
                OnPropertyChanged("FilterByField");
            }
        }


        public MainViewModel(
            ProductsService productsService,
            OrdersService ordersService,
            EmployeesService employeesService,
            PickPointsService pickpointsService,
            ProductDetailsViewModel productDetailsViewModel,
            IMapper mapper)
        {
            this._productsService = productsService;
            this._ordersService = ordersService;
            this._employeesService = employeesService;
            this._pickpointsService = pickpointsService;

            this._productDetailsViewModel = productDetailsViewModel;

            this._mapper = mapper;

            this.OpenWindowCommand = new RelayCommand(async o => await OpenWindow(Enum.Parse<WindowType>(o.ToString())));
            this.ChangePageCommand = new RelayCommand(async o => await ChangePage(o.ToString()));
            this.ApplyFiltersCommand = new RelayCommand(async o => await ReloadPage());
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
                        var items = await this._productsService
                            .GetAll(this._paginator)
                            .ApplyFilters(SortByField, FilterByField, FilterDescriptionText) //fix bug 
                            .ToListAsync();
                        this._dataGrid.ItemsSource = this._mapper.Map<ProductDto[]>(items);
                        break;
                    }
                case WindowType.Orders:
                    {
                        var items = await this._ordersService.GetAll(this._paginator).ToListAsync();
                        this._dataGrid.ItemsSource = this._mapper.Map<OrderDto[]>(items);
                        break;
                    }
                case WindowType.Employees:
                    {
                        var items = await this._employeesService.GetAll(this._paginator).ToListAsync();
                        this._dataGrid.ItemsSource = this._mapper.Map<EmployeeDto[]>(items);
                        break;
                    }
                case WindowType.PickPoints:
                    {
                        var items = await this._pickpointsService.GetAll(this._paginator).ToListAsync();
                        this._dataGrid.ItemsSource = this._mapper.Map<PickPointDto[]>(items);
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
                case WindowType.Orders: return this._ordersService.Count();
                case WindowType.Employees: return this._employeesService.Count();
                case WindowType.PickPoints: return this._pickpointsService.Count();
                default: return 0;
            }
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
