using Emporium.ViewModels.DialogWindows;
using System.Windows;
using System.Windows.Controls;

namespace Emporium.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddWindow.xaml
    /// </summary>
    public partial class EmployeeAddWindow : Window
    {
        private readonly EmployeeAddViewModel _viewModel;

        public EmployeeAddWindow(EmployeeAddViewModel viewModel)
        {
            InitializeComponent();

            viewModel.CurrentWindow = this;
            this._viewModel = viewModel;
            DataContext = this._viewModel;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._viewModel.OnPickupPointSelected(sender, e);
        }
    }
}
