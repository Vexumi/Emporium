using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Emporium.ViewModels.DialogWindows
{
    public class ProductAddViewModel : BaseDetailsViewModel<Product, ProductsService>
    {
        private readonly SellersService sellersService;
        private ObservableCollection<Seller> _sellers;

        public ProductAddViewModel(ProductsService productsService, SellersService sellersService) : base(productsService)
        {
            this.sellersService = sellersService;
        }

        public ObservableCollection<Seller> Employees
        {
            get
            {
                if (_sellers == null)
                {
                    this._sellers = new ObservableCollection<Seller>(this.sellersService.GetAll().ToArray());
                }
                return this._sellers;
            }
        }

        public void OnEmployeeSelected(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            this.Item.SellerId = ((Seller?)(comboBox?.SelectedItem))?.Id;
        }
    }
}
