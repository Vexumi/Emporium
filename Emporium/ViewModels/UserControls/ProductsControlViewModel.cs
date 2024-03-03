using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using Emporium.Views.DialogWindows;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Emporium.ViewModels.UserControls
{
    public class ProductsControlViewModel : BaseViewModel
    {
        private readonly ProductsService _productsService;
        private Paginator _paginator;
        private ObservableCollection<Product> _products = new();

        public ICommand ChangePageCommand { get; set; }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        public ProductsControlViewModel(ProductsService productsService)
        {
            this._productsService = productsService;
            this._paginator = new Paginator(this._productsService.Count());
            this.ChangePageCommand = new RelayCommand(o => ChangePage(o.ToString()));
        }

        private async Task ChangePage(string page)
        {
            if (page == "Next") _paginator.NextPage();
            else _paginator.PrevPage();

            await this.LoadProducts();

        }

        public async Task LoadProducts()
        {
            var products = await _productsService.GetAll(_paginator).ToListAsync();
            this._products.Clear();
            products.ForEach(el => this._products.Add(el));
        }
        public void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
/*            var row = (DataGridRow)sender;
            var dialogWindow = new ProductDetailsWindow((Product)row.Item, this._productsService);

            dialogWindow.ShowDialog();*/
        }
    }
}
