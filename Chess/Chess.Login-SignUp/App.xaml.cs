using Chess.Login_SignUp.Data;
using Chess.Login_SignUp.Repositories;
using Chess.Login_SignUp.View;
using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceProvider ServiceProvider { get; private set; }

        public App() {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("YourConnectionStringHere")); // <-- thay bằng chuỗi kết nối thật


            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<LoginViewModel>();

            services.AddSingleton<LoginView>();
        }

        protected override void OnStartUp(StartupEventArgs e)
        {
            base.OnStartup(e);
            var loginView = ServiceProvider.GetRequiredService<LoginView>();
            loginView.Show();
        }
    }

}
