using Emporium.ViewModels.DialogWindows;
using System.Windows;

namespace Emporium.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для PickPointAddWindow.xaml
    /// </summary>
    public partial class PickPointAddWindow : Window
    {
        public PickPointAddWindow(PickupPointAddViewModel viewModel)
        {
            InitializeComponent();

            viewModel.CurrentWindow = this;
            DataContext = viewModel;
        }
    }
}
