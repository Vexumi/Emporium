using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emporium.ViewModels.DialogWindows
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private readonly Window _view;
        private ProductsService _productsService;
        private Product _product;
        public Product CurrentProduct
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged("CurrentProduct");
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ProductDetailsViewModel(Window view, Product product, ProductsService productsService)
        {
            _view = view;
            CurrentProduct = product;

            this._productsService = productsService;
            this.SaveCommand = new RelayCommand(async o => Save());
            this.DeleteCommand = new RelayCommand(o => Delete());
        }

        public async Task Save()
        {
            await this._productsService.Save(CurrentProduct);
            this._view.DialogResult = true;
        }

        public async Task Delete()
        {
            await this._productsService.Delete(CurrentProduct);
            this._view.DialogResult = true;
        }
    }
}
