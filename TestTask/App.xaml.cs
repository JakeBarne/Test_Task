using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using TestTask.Common;
using TestTask.Infrastructure.Database;
using TestTask.Infrastructure.Repository;
using TestTask.Model.Entities;
using TestTask.View;
using TestTask.ViewModel;

namespace TestTask
{
    public partial class App : Application
    {
        private ServiceProvider _services;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                var db = config.GetSection("Database");
                bool.TryParse(config["UpdateSchema"], out var updateSchema); 
                var sessionFactory = NHibernateHelper.Build(
                    db["Server"], db["Name"], db["User"], db["Password"], updateSchema);

                var services = new ServiceCollection();
                ConfigureServices(services, sessionFactory);
                _services = services.BuildServiceProvider();

                _services.GetRequiredService<MainWindow>().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при запуске:\n{ExceptionHelper.RootMessage(ex)}\n\nПоставьте в appsettings.json ваши данные",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown(1);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _services?.Dispose();
            base.OnExit(e);
        }

        private static void ConfigureServices(IServiceCollection services, ISessionFactory sessionFactory)
        {
            services.AddSingleton(sessionFactory);

            services.AddSingleton<IRepository<Employee>,   Repository<Employee>>();
            services.AddSingleton<IRepository<Contractor>, Repository<Contractor>>();
            services.AddSingleton<IRepository<Order>,      Repository<Order>>();

            services.AddSingleton<IDialogService, DialogService>();

            services.AddSingleton<EmployeesViewModel>();
            services.AddSingleton<ContractorsViewModel>();
            services.AddSingleton<OrdersViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }
    }
}

