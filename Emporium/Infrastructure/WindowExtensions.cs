using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Emporium.Infrastructure
{
    public static class WindowExtensions
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        public static void AddControlToView(UserControl uc, Window view)
        {
            foreach (DockPanel tb in FindVisualChildren<DockPanel>(view))
            {
                ClearPanel(tb);
                tb.Children.Add(uc);
                return;
            }
        }

        public static void ClearPanel(Panel panel)
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
