using Emporium.Models;
using Emporium.Services;
using Emporium.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace Emporium.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user, MainViewModel viewModel)
        {
            InitializeComponent();

            viewModel.CurrentUser = user;
            viewModel.CurrentWindow = this;
            DataContext = viewModel;
        }

        public User CurrentUser { get; set; }
    }
}
