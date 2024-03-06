using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;

namespace Emporium.ViewModels.DialogWindows
{
    public class ProductDetailsViewModel : BaseDetailsViewModel<Product, ProductsService>
    {
        public ProductDetailsViewModel(ProductsService productsService) : base(productsService)
        { }
    }
}
