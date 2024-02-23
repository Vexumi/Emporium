using Emporium.Infrastructure.Based;
using Emporium.Models;

namespace Emporium.ViewModels.DialogWindows
{
    public class ProductDetailsViewModel : BaseViewModel
    {
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
        public ProductDetailsViewModel(Product product)
        {
            CurrentProduct = product;
        }
    }
}
