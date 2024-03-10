using Emporium.Infrastructure;
using Emporium.Infrastructure.Enums;
using Emporium.Models;
using Emporium.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
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
            DataContext = viewModel;

            FilterByCombobox.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.mainViewModel.OnRowDoubleClick(sender, e);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterByCombobox.SelectedItem is FilterBy.Unknown)
            {
                this.mainViewModel.IsFilterDescriptionTextBoxEnabled = false;
            }
            else
            {
                this.mainViewModel.IsFilterDescriptionTextBoxEnabled = true;
            }
        }

        private void MainTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
