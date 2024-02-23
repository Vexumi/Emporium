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
        public ProductDetailsWindow(Product product)
        {
            InitializeComponent();
            DataContext = new ProductDetailsViewModel(this, product);
        }
    }
}
