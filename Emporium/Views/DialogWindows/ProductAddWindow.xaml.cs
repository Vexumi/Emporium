using Emporium.ViewModels.DialogWindows;
using System.Windows;

namespace Emporium.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        private readonly ProductAddViewModel _viewModel;
        public ProductAddWindow(ProductAddViewModel viewModel)
        {
            InitializeComponent();

            this._viewModel = viewModel;
            viewModel.CurrentWindow = this;
            DataContext = viewModel;
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this._viewModel.OnEmployeeSelected(sender, e);
        }
    }
}
