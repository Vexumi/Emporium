using Emporium.Models;
using Emporium.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emporium.ViewModels.UserControls
{
    public class ProductsControlViewModel: BaseViewModel
    {
        private readonly ProductsService _productsService;
        private Product[] _products;

        public Product[] Products { 
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
        }

        public static async Task<ProductsControlViewModel> Build()
        {
            var entity = new ProductsControlViewModel();
            await entity.LoadProducts();
            return entity;
        }

        private async Task LoadProducts()
        {
            this.Products = await this._productsService.GetAllProducts();
        }
    }
}
