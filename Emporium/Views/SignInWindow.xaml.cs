using Emporium.ViewModels;

using System.Windows;

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

            DataContext = new SignInViewModel(this);
        }
    }
}
