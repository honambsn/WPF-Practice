using Chess.Login_SignUp.View;
using Chess.Login_SignUp.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Chess.LoginSignUp.Application.Interfaces;
using Chess.LoginSignUp.Infrastructure.Repositories;
using System.Data;
using System.Windows;
using Chess.LoginSignUp.Infrastructure.Persistence;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Chess.Login_SignUp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }
        public App() {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();


            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Chess;Trusted_Connection=True;"));
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            // ViewModel
            //services.AddTransient<LoginViewModel>();
            services.AddTransient<LoginViewModel2>();

            // View
            services.AddTransient<LoginView>();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginView = ServiceProvider.GetRequiredService<LoginView>();
            loginView.Show();

            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    //var mainView = new MainView();
                    //mainView.Show();
                    loginView.Close(); 
                    //https://youtu.be/FGqj4q09NtA?list=PLwG-AtjFaHdO802QyIrHRwN-StZtKlm9g&t=1794
                }
            };
        }
    }

}
