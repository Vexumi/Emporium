using Emporium.ViewModels.DialogWindows;
using System.Windows;

namespace Emporium.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeDetailsWindow.xaml
    /// </summary>
    public partial class EmployeeDetailsWindow : Window
    {
        public EmployeeDetailsWindow(EmployeeDetailsViewModel viewModel)
        {
            InitializeComponent();

            viewModel.CurrentWindow = this;
            DataContext = viewModel;
        }
    }
}
