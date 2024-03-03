using Emporium.Models;
using Emporium.Services;
using Emporium.ViewModels.DialogWindows;
using System.Windows;

namespace Emporium.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductDetailsWindow.xaml
    /// </summary>
    public partial class ProductDetailsWindow : Window
    {
        public ProductDetailsWindow(Product product, ProductsService productsService)
        {
            InitializeComponent();
            DataContext = new ProductDetailsViewModel(this, product, productsService);
        }
    }
}
