using Emporium.Infrastructure;
using Emporium.ViewModels.DialogWindows;
using System.ComponentModel;
using System.Windows;

namespace Emporium.Views.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для OrderDetailsWindow.xaml
    /// </summary>
    public partial class OrderDetailsWindow : Window
    {
        public OrderDetailsWindow(OrderDetailsViewModel viewModel)
        {
            InitializeComponent();

            viewModel.CurrentWindow = this;
            DataContext = viewModel;
        }

        private void OrderDetailsTable_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            var desc = e.PropertyDescriptor as PropertyDescriptor;
            var att = desc.Attributes[typeof(ColumnNameAttribute)] as ColumnNameAttribute;
            if (att != null)
            {
                e.Column.Header = att.Name;
            }
        }
    }
}
