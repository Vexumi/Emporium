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
        public SignInWindow()
        {
            InitializeComponent();

            DataContext = new SignInViewModel();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((SignInViewModel)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
