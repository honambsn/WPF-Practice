using Chess.Login_SignUp.Data;
using Chess.Login_SignUp.Repositories;
using Chess.Login_SignUp.View;
using Chess.Login_SignUp.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Chess.LoginSignUp.Application.Interfaces;
using Chess.LoginSignUp.Infrastructure.Repositories;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Chess.Login_SignUp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        public App() {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public void ConfigureServices(ServiceCollection services)
        {
            //dbcontext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("YourConnectionStringHere"));


            // repository
            services.AddScoped<IUserRepository, UserRepository>();

            //viewmodel
            services.AddTransient<LoginViewModel>();

            services.AddTransient<LoginView>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginView = ServiceProvider.GetRequiredService<LoginView>();
            loginView.Show();
        }
    }

}
