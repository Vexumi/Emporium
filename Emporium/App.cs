using Emporium.Views;
using System.Windows;

public class App : Application
{
    readonly SignInWindow signInWindow;

    public App(SignInWindow mainWindow)
    {
        this.signInWindow = mainWindow;
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        signInWindow.Show();
        base.OnStartup(e);
    }
}