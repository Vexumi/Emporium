using Emporium.Models;
using Emporium.Services;
using Emporium.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Emporium.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel mainViewModel;
        public MainWindow(User user, MainViewModel viewModel)
        {
            InitializeComponent();

            this.mainViewModel = viewModel;
            viewModel.CurrentUser = user;
            viewModel.CurrentWindow = this;
            DataContext = viewModel;
        }

        private void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.mainViewModel.OnRowDoubleClick(sender, e);
        }
    }
}
