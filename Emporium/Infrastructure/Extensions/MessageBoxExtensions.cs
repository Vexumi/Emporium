using System.Windows;

namespace Emporium.Infrastructure.Extensions
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
