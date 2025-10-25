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
using ChessUI;
using System.Diagnostics;

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
            services.AddTransient<MainView>();
            //services.AddTransient<MainWindow>();
        }


        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    var loginView = ServiceProvider.GetRequiredService<LoginView>();

        //    //Version 1
        //    loginView.Closed += (s, args) =>
        //    {
        //        Debug.WriteLine("login close");
        //        var mainView = ServiceProvider.GetRequiredService<MainView>();
        //        mainView.Show();
        //        //var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        //        //mainWindow.Show();
        //        //try
        //        //{
        //        //    Application.Current.Dispatcher.Invoke(() =>
        //        //    {
        //        //        Debug.WriteLine("Show view");
        //        //        var mainWindow = new MainWindow();
        //        //        mainWindow.Show();
        //        //        Debug.WriteLine("showing");
        //        //    });
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    Debug.WriteLine(ex);
        //        //}
        //    };

        ////Version 2
        ////loginView.IsVisibleChanged += (s, ev) =>
        ////{
        ////    if (loginView.IsVisible == false && loginView.IsLoaded)
        ////    {
        ////        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        ////        {
        ////            loginView.Close();
        ////        }));
        ////        //var mainView = new MainView();
        ////        //mainView.Show();
        ////        //loginView.Close(); 
        ////        //https://youtu.be/FGqj4q09NtA?list=PLwG-AtjFaHdO802QyIrHRwN-StZtKlm9g&t=1794
        //          //https://youtu.be/FGqj4q09NtA?list=PLwG-AtjFaHdO802QyIrHRwN-StZtKlm9g&t=1800
        //    //    }
        //    //};

        //    loginView.Show();

        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Khởi tạo LoginView thông qua DI
            var loginView = ServiceProvider.GetRequiredService<LoginView>();

            // Hiển thị LoginView
            loginView.Show();

            // Lắng nghe sự kiện IsVisibleChanged để kiểm tra khi LoginView không còn hiển thị
            loginView.IsVisibleChanged += (s, args) =>
            {
                // Khi LoginView không hiển thị và đã được load, mở MainView
                if (!loginView.IsVisible && loginView.IsLoaded)
                {

                    var uri = new Uri("pack://application:,,,/ChessUI;component/Resources/SharedStyles.xaml", UriKind.Absolute);
                    var dict = new ResourceDictionary { Source = uri };
                    Application.Current.Resources.MergedDictionaries.Add(dict);


                    var mainView = ServiceProvider.GetRequiredService<MainView>();
                    mainView.Show();
                    //var mainWindow = new ChessUI.MainWindow();
                    //mainWindow.Show();

                    //var mainWindow = new ChessUI.MainWindow();
                    //mainWindow.Show();

                    // Nếu muốn, có thể làm cho LoginView hiển thị lại ở đây (tùy vào ứng dụng cụ thể)
                    loginView.Show();


                //https://youtu.be/FGqj4q09NtA?list=PLwG-AtjFaHdO802QyIrHRwN-StZtKlm9g&t=1978
                }
            };
        }


    }

}
