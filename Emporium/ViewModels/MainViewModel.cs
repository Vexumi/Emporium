using AutoMapper;
using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Infrastructure.Enums;
using Emporium.Interfaces;
using Emporium.Models;
using Emporium.Models.Dto;
using Emporium.Services;
using Emporium.ViewModels.DialogWindows;
using Emporium.Views.DialogWindows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
namespace Emporium.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ProductsService _productsService;
        private readonly OrdersService _ordersService;
        private readonly EmployeesService _employeesService;
        private readonly PickupPointsService _pickpointsService;

        private readonly ProductDetailsViewModel _productDetailsViewModel;
        private readonly OrderDetailsViewModel _orderDetailsViewModel;
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly PickupPointDetailsViewModel _pickupPointDetailsViewModel;
        private readonly ProductAddViewModel _productAddViewModel;
        private readonly EmployeeAddViewModel _employeeAddViewModel;
        private readonly PickupPointAddViewModel _pickupPointAddViewModel;
        private readonly IMapper _mapper;

        private object _items;
        private ICountable _currentService;

        private User _user;
        private WindowType _openedWindow;
        private Paginator _paginator = new Paginator(0);
        private bool _isFilterDescriptionTextBoxEnabled = false;

        public ICommand OpenWindowCommand { get; set; }
        public ICommand ChangePageCommand { get; set; }
        public ICommand ApplyFiltersCommand { get; set; }
        public ICommand CreateNewEntityCommand { get; set; }

        public User CurrentUser
        {
            get { return this._user; }
            set
            {
                _user = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        public string GetVisiblityBasedOnUser
        {
            get
            {
                return this.IsUserAdmin ? "Visible" : "Hidden";
            }
        }

        public string GetVisiblityForProducts
        {
            get => (AccountTypeEnum)CurrentUser.AccountType == AccountTypeEnum.Admin
                || (AccountTypeEnum)CurrentUser.AccountType == AccountTypeEnum.Customer
                || (AccountTypeEnum)CurrentUser.AccountType == AccountTypeEnum.Employee ? "Visible" : "Hidden";
        }

        public string GetVisiblityForOrders
        {
            get => "Visible";
        }

        public string GetVisiblityForPickupPoints
        {
            get => (AccountTypeEnum)CurrentUser.AccountType == AccountTypeEnum.Admin
                || (AccountTypeEnum)CurrentUser.AccountType == AccountTypeEnum.Employee ? "Visible" : "Hidden";
        }

        public string GetVisiblityEmployees
        {
            get => (AccountTypeEnum)CurrentUser.AccountType == AccountTypeEnum.Admin ? "Visible" : "Hidden";
        }

        public bool IsUserAdmin
        {
            get => (AccountTypeEnum)CurrentUser.AccountType == AccountTypeEnum.Admin;
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
            get { return this._paginator.FilterOption; }
            set
            {
                this._paginator.FilterOption = value;
                OnPropertyChanged("FilterDescriptionText");
            }
        }

        public SortBy SortByField
        {
            get { return this._paginator.SortSettings; }
            set
            {
                this._paginator.SortSettings = value;
                OnPropertyChanged("SortByField");
            }
        }

        public FilterBy FilterByField
        {
            get { return this._paginator.FilterSettings; }
            set
            {
                this._paginator.FilterSettings = value;
                OnPropertyChanged("FilterByField");
            }
        }


        public MainViewModel(
            ProductsService productsService,
            OrdersService ordersService,
            EmployeesService employeesService,
            PickupPointsService pickpointsService,
            ProductDetailsViewModel productDetailsViewModel,
            OrderDetailsViewModel orderDetailsViewModel,
            EmployeeDetailsViewModel employeeDetailsViewModel,
            PickupPointDetailsViewModel pickupPointDetailsViewModel,
            ProductAddViewModel productAddViewModel,
            EmployeeAddViewModel employeeAddViewModel,
            PickupPointAddViewModel pickupPointAddViewModel,
            IMapper mapper)
        {
            this._productsService = productsService;
            this._ordersService = ordersService;
            this._employeesService = employeesService;
            this._pickpointsService = pickpointsService;

            this._productDetailsViewModel = productDetailsViewModel;
            this._orderDetailsViewModel = orderDetailsViewModel;
            this._employeeDetailsViewModel = employeeDetailsViewModel;
            this._pickupPointDetailsViewModel = pickupPointDetailsViewModel;
            this._productAddViewModel = productAddViewModel;
            this._employeeAddViewModel = employeeAddViewModel;
            this._pickupPointAddViewModel = pickupPointAddViewModel;

            this._mapper = mapper;

            this.OpenWindowCommand = new RelayCommand(async o => await OpenWindow(Enum.Parse<WindowType>(o.ToString())));
            this.ChangePageCommand = new RelayCommand(async o => await ChangePage(o.ToString()));
            this.ApplyFiltersCommand = new RelayCommand(async o => await ReloadPage());
            this.CreateNewEntityCommand = new RelayCommand(async o => await OnCreateNewEntityClick());
        }

        public object Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public async Task OnCreateNewEntityClick()
        {
            switch (this._openedWindow)
            {
                case WindowType.Products:
                    {
                        this._productAddViewModel.Item = new Product();
                        var dialogWindow = new ProductAddWindow(this._productAddViewModel);
                        dialogWindow.ShowDialog();
                        break;
                    }
                case WindowType.Employees:
                    {
                        this._employeeAddViewModel.Item = new Employee() { User = new User() };
                        var dialogWindow = new EmployeeAddWindow(this._employeeAddViewModel);
                        dialogWindow.ShowDialog();
                        break;
                    }
                case WindowType.PickupPoints:
                    {
                        this._pickupPointAddViewModel.Item = new PickupPoint();
                        var dialogWindow = new PickPointAddWindow(this._pickupPointAddViewModel);
                        dialogWindow.ShowDialog();
                        break;
                    }
                default: break;
            }
            await this.ReloadPage();
        }

        public async void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (this._openedWindow)
            {
                case WindowType.Products:
                    {
                        var product = await this._productsService.FindById(GetItemFromTable<ProductDto>(sender).Id).FirstOrDefaultAsync();

                        this._productDetailsViewModel.Item = product;
                        var dialogWindow = new ProductDetailsWindow(this._productDetailsViewModel);
                        dialogWindow.ShowDialog();
                        break;
                    }
                case WindowType.Orders:
                    {
                        var orders = await this._ordersService.FindById(GetItemFromTable<OrderDto>(sender).Id).FirstOrDefaultAsync();

                        this._orderDetailsViewModel.Item = orders;
                        var dialogWindow = new OrderDetailsWindow(this._orderDetailsViewModel);
                        dialogWindow.ShowDialog();
                        break;
                    }
                case WindowType.Employees:
                    {
                        var employees = await this._employeesService.FindById(GetItemFromTable<EmployeeDto>(sender).Id).FirstOrDefaultAsync();

                        this._employeeDetailsViewModel.Item = employees;
                        var dialogWindow = new EmployeeDetailsWindow(this._employeeDetailsViewModel);
                        dialogWindow.ShowDialog();
                        break;
                    }
                case WindowType.PickupPoints:
                    {
                        var pickupPoints = await this._pickpointsService.FindById(GetItemFromTable<PickPointDto>(sender).Id).FirstOrDefaultAsync();

                        this._pickupPointDetailsViewModel.Item = pickupPoints;
                        var dialogWindow = new PickupPointDetailsWindow(this._pickupPointDetailsViewModel);
                        dialogWindow.ShowDialog();
                        break;
                    }
                default: break;
            }
            await this.ReloadPage();
        }

        private T GetItemFromTable<T>(object sender)
        {
            var row = (DataGridRow)sender;
            var item = (T)row.Item;
            return item;
        }

        private async Task ReloadPage()
        {
            switch (this._openedWindow)
            {
                case WindowType.Products:
                    {
                        var items = await this._productsService.GetAll(this._paginator).ToListAsync();
                        this.Items = this._mapper.Map<ProductDto[]>(items);
                        break;
                    }
                case WindowType.Orders:
                    {
                        var items = await this._ordersService.GetAll(this._paginator).ToListAsync();
                        this.Items = this._mapper.Map<OrderDto[]>(items);
                        break;
                    }
                case WindowType.Employees:
                    {
                        var items = await this._employeesService.GetAll(this._paginator).ToListAsync();
                        this.Items = this._mapper.Map<EmployeeDto[]>(items);
                        break;
                    }
                case WindowType.PickupPoints:
                    {
                        var items = await this._pickpointsService.GetAll(this._paginator).ToListAsync();
                        this.Items = this._mapper.Map<PickPointDto[]>(items);
                        break;
                    }
                default: break;
            }
        }

        private int GetTotalElementsForWindow()
        {
            if (this._currentService != null) return this._currentService.Count();
            return 0;
        }

        private async Task OpenWindow(WindowType windowType)
        {
            this._openedWindow = windowType;

            switch (this._openedWindow)
            {
                case WindowType.Products:
                    {
                        this._currentService = this._productsService;
                        break;
                    }
                case WindowType.Orders:
                    {
                        this._currentService = this._ordersService;
                        break;
                    }
                case WindowType.Employees:
                    {
                        this._currentService = this._employeesService;
                        break;
                    }
                case WindowType.PickupPoints:
                    {
                        this._currentService = this._pickpointsService;
                        break;
                    }
            }
            this._paginator = new Paginator(this.GetTotalElementsForWindow());

            await this.ReloadPage();
        }

        private async Task ChangePage(string page)
        {
            if (this._paginator == null) return;

            if (page == "Next") this._paginator.NextPage();
            else this._paginator.PrevPage();

            await this.ReloadPage();
        }
    }
}
