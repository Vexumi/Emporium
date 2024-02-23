using Emporium.Interfaces;
using Emporium.Models;
using Emporium.ViewModels.UserControls;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Emporium.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        private readonly ProductsControlViewModel _viewModel;

        public async Task LoadData()
        {
            await this._viewModel.LoadProducts();
        }

        public ProductsControl()
        {
            InitializeComponent();

            this._viewModel = new ProductsControlViewModel();
            DataContext = this._viewModel;
        }
    }
}
