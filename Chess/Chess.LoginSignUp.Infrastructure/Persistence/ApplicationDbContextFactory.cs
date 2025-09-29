using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;



namespace Chess.LoginSignUp.Infrastructure.Persistence
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Chess;Trusted_Connection=True;"));
            optionsBuilder.UseSqlServer(connectionString);


            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
