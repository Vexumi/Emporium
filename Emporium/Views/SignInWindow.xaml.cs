using Emporium.Services;
using Emporium.ViewModels;

using System.Windows;
using System.Windows.Controls;

namespace Emporium.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow(SignInViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((SignInViewModel)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
