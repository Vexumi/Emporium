using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Emporium;
using Emporium.Views;
using Emporium.Services;
using Emporium.ViewModels;

public class Program
{
    [STAThread]
    public static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // App Start
                services.AddSingleton<App>();
                services.AddSingleton<SignInWindow>();

                // Services
                services.AddTransient<ApplicationContext>();
                services.AddTransient<ProductsService>();
                services.AddTransient<SignInService>();

                // ViewModels
                services.AddSingleton<SignInViewModel>();
                services.AddSingleton<MainViewModel>();
            })
            .Build();

        var app = host.Services.GetService<App>();
        app?.Run();
    }
}