﻿using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Models;
using Emporium.Services;
using Emporium.Views.DialogWindows;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Emporium.ViewModels.UserControls
{
    public class ProductsControlViewModel : BaseViewModel
    {
        private readonly ProductsService _productsService;
        private ObservableCollection<Product> _products = new();

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        public ProductsControlViewModel()
        {
            this._productsService = new ProductsService();
        }

        public static async Task<ProductsControlViewModel> Build()
        {
            var entity = new ProductsControlViewModel();
            await entity.LoadProducts();
            return entity;
        }

        public async Task LoadProducts()
        {
            var products = await _productsService.GetAllProducts();
            this._products.Clear();
            products.ForEach(el => this._products.Add(el));

        }
        public void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (DataGridRow)sender;
            var dialogWindow = new ProductDetailsWindow((Product)row.Item);

            dialogWindow.ShowDialog();
        }
    }
}
