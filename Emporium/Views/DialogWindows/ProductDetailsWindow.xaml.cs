using Emporium.Models;
using Emporium.ViewModels.DialogWindows;
using System.Windows;

namespace Emporium.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductDetailsWindow.xaml
    /// </summary>
    public partial class ProductDetailsWindow : Window
    {
        public ProductDetailsWindow(Product product, ProductDetailsViewModel viewModel)
        {
            InitializeComponent();
            viewModel.CurrentProduct = product;
            viewModel.CurrentWindow = this;
            DataContext = viewModel;
        }
    }
}
