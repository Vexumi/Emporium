using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using Emporium.Views.DialogWindows;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public ProductsControlViewModel()
        {
            this._productsService = new ProductsService();
            this._paginator = new Paginator(this._productsService.Count());
            this.ChangePageCommand = new RelayCommand(o => ChangePage(o.ToString()));
        }

        private async Task ChangePage(string page)
        {
            if (page == "Next") _paginator.NextPage();
            else _paginator.PrevPage();

            await this.LoadProducts();

        }

        public static async Task<ProductsControlViewModel> Build()
        {
            var entity = new ProductsControlViewModel();
            await entity.LoadProducts();
            return entity;
        }

        public async Task LoadProducts()
        {
            var products = await _productsService.GetAll(_paginator);
            this._products.Clear();
            products.ForEach(el => this._products.Add(el));
        }
        public void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (DataGridRow)sender;
            var dialogWindow = new ProductDetailsWindow((Product)row.Item);

            dialogWindow.ShowDialog();
        }
    }
}
