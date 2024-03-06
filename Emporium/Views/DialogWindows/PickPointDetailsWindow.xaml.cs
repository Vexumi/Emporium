using Emporium.ViewModels.DialogWindows;
using System.Windows;

namespace Emporium.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для PickPointDetailsWindow.xaml
    /// </summary>
    public partial class PickupPointDetailsWindow : Window
    {
        public PickupPointDetailsWindow(PickupPointDetailsViewModel viewModel)
        {
            InitializeComponent();

            viewModel.CurrentWindow = this;
            DataContext = viewModel;
        }
    }
}
