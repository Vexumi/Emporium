using Emporium.Models;
using Emporium.ViewModels;
using System.Windows;

namespace Emporium.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();

            DataContext = new MainViewModel(this, user);
        }
    }
}
