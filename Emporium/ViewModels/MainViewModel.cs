using Emporium.Infrastructure;
using Emporium.Infrastructure.Enums;
using Emporium.Models;
using Emporium.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Emporium.Infrastructure.WindowExtensions;
namespace Emporium.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private User _user;
        private Window _view;

        public ICommand OpenWindowCommand { get; set; }

        public User CurrentUser
        {
            get { return this._user; }
            set
            {
                _user = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        public MainViewModel(Window view, User user)
        {
            this._view = view;
            this.CurrentUser = user;

            this.OpenWindowCommand = new RelayCommand(o => OpenWindow(Enum.Parse<WindowType>(o.ToString())));
        }

        private void OpenWindow(WindowType windowType)
        {
            switch (windowType)
            {
                case WindowType.Products:
                    {
                        foreach (DockPanel tb in FindVisualChildren<DockPanel>(this._view))
                        {
                            ClearPanel(tb);
                            var uc = new ProductsControl();
                            tb.Children.Add(uc);
                            return;
                        }
                        break;
                    }
                default: break;
            }
        }

        private void ClearPanel(Panel panel)
        {
            List<UIElement> elementsToRemove = new();
            foreach (UIElement el in panel.Children)
            {
                elementsToRemove.Add(el);
            }

            foreach (var item in elementsToRemove)
            {
                panel.Children.Remove(item);
            }
        }
    }
}
