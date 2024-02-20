using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emporium.Infrastructure
{
    public static class MessageBoxExtensions
    {
        public static void IncorrectPassword()
        {
            Error("Неверный логин или пароль!", "Вы неверно ввели логин или пароль, пожалуйста, проверьте данные и повторите попытку");
        }

        public static void Error(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
