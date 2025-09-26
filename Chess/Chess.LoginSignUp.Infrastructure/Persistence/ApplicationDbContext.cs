using Chess.LoginSignUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("Server=.;Database=WpfLoginDemo;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed roles
            var adminRoleID = Guid.NewGuid();
            var guestRoleID = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
                new Role { ID = adminRoleID, Name = "Admin" },
                new Role { ID = guestRoleID, Name = "Guest" }
            );

            // seed 
            modelBuilder.Entity<User>().HasData(
            // Admin user
            new User
            {
                UserID = Guid.NewGuid(),
                Username = "admin",
                PasswordHash = "123", // Note: password is not hashed
                Name = "Administrator",
                Email = "admin@example.com",
                RoleID = adminRoleID,
            },

            // Guest user
            new User
            {
                UserID = Guid.NewGuid(),
                Username = "guest",
                PasswordHash = "guest", // Note: password is not hashed
                Name = "Guest User",
                Email = "guest@example.com",
                RoleID = guestRoleID,
            },

            // User 1
            new User
            {
                UserID = Guid.NewGuid(),
                Username = "user1",
                PasswordHash = "user1password", // Note: password is not hashed
                Name = "User One",
                Email = "user1@example.com",
                RoleID = guestRoleID,
            },

            // User 2
            new User
            {
                UserID = Guid.NewGuid(),
                Username = "user2",
                PasswordHash = "user2password", // Note: password is not hashed
                Name = "User Two",
                Email = "user2@example.com",
                RoleID = guestRoleID,
            },

            // User 3
            new User
            {
                UserID = Guid.NewGuid(),
                Username = "user3",
                PasswordHash = "user3password", // Note: password is not hashed
                Name = "User Three",
                Email = "user3@example.com",
                RoleID = guestRoleID,
            }
        );

        }
    }
}
