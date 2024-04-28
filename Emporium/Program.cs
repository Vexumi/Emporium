using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Emporium;
using Emporium.Views;
using Emporium.Services;
using Emporium.ViewModels;
using AutoMapper;
using Emporium.Infrastructure.MappingProfiles;
using Emporium.ViewModels.DialogWindows;
using Emporium.Views.DialogWindows;

public class Program
{
    [STAThread]
    public static void Main()
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // App Start
                services.AddSingleton<App>();
                services.AddSingleton<SignInWindow>();

                // Services
                services.AddTransient<ApplicationContext>();
                services.AddTransient<ProductsService>();
                services.AddTransient<OrdersService>();
                services.AddTransient<EmployeesService>();
                services.AddTransient<PickupPointsService>();
                services.AddTransient<SellersService>();
                services.AddTransient<UsersService>();
                services.AddTransient<SignInService>();
                services.AddSingleton(mapper);

                // ViewModels
                services.AddSingleton<SignInViewModel>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<ProductDetailsViewModel>();
                services.AddSingleton<OrderDetailsViewModel>();
                services.AddSingleton<PickupPointDetailsViewModel>();
                services.AddSingleton<EmployeeDetailsViewModel>();
                services.AddSingleton<ProductAddViewModel>();
                services.AddSingleton<EmployeeAddViewModel>();
                services.AddSingleton<PickupPointAddViewModel>();
            })
            .Build();

        var app = host.Services.GetService<App>();
        app?.Run();
    }
}