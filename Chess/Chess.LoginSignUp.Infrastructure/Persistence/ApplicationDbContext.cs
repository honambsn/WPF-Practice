using Chess.LoginSignUp.Application.Helpers;
using Chess.LoginSignUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.LoginSignUp.Application.Helpers;

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

            //// seed 
            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasKey(e => e.UserID);
            //    entity.HasIndex(e => e.Username).IsUnique();
            //    entity.HasIndex(e => e.Email).IsUnique();

            //    // Thêm dữ liệu mẫu vào bảng User
            //    entity.HasData(
            //    new User
            //    {
            //        UserID = Guid.NewGuid(),
            //        Username = "admin",
            //        PasswordHash = PasswordHasher.HashPassword("123"),  // Dùng PasswordHasher để băm mật khẩu
            //        Name = "Administrator",
            //        Email = "admin@example.com",
            //        RoleID = adminRoleID,
            //    },

            //    new User
            //    {
            //        UserID = Guid.NewGuid(),
            //        Username = "guest",
            //        PasswordHash = PasswordHasher.HashPassword("guest"),
            //        Name = "Guest User",
            //        Email = "guest@example.com",
            //        RoleID = guestRoleID,
            //    },

            //    new User
            //    {
            //        UserID = Guid.NewGuid(),
            //        Username = "user1",
            //        PasswordHash = PasswordHasher.HashPassword("user1password"),
            //        Name = "User One",
            //        Email = "user1@example.com",
            //        RoleID = guestRoleID,
            //    },

            //    new User
            //    {
            //        UserID = Guid.NewGuid(),
            //        Username = "user2",
            //        PasswordHash = PasswordHasher.HashPassword("user2password"),
            //        Name = "User Two",
            //        Email = "user2@example.com",
            //        RoleID = guestRoleID,
            //    },

            //    new User
            //    {
            //        UserID = Guid.NewGuid(),
            //        Username = "user3",
            //        PasswordHash = PasswordHasher.HashPassword("user3password"),
            //        Name = "User Three",
            //        Email = "user3@example.com",
            //        RoleID = guestRoleID,
            //    },

            //    new User
            //    {
            //        UserID = Guid.NewGuid(),
            //        Username = "usertest",
            //        PasswordHash = PasswordHasher.HashPassword("usertestpassword"),
            //        Name = "User test",
            //        Email = "usertest@example.com",
            //        RoleID = guestRoleID,
            //    }
            //);


            //});
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();

                // Thêm dữ liệu mẫu cho bảng User
                entity.HasData(
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        Username = "admin",
                        PasswordHash = PasswordHasher.HashPassword("123"),  // Sử dụng PasswordHasher để băm mật khẩu
                        Name = "Administrator",
                        LastName = "Admin",
                        Email = "admin@example.com",
                        RoleID = adminRoleID,
                        ProfilePicture = new byte[] { /* Thêm dữ liệu byte array nếu có ảnh đại diện mặc định */ },
                        // LastLoginAt = DateTime.UtcNow,  // Có thể dùng nếu muốn đặt thời gian đăng nhập mặc định
                        // Rating = 1500,  // Xếp hạng mặc định, nếu cần
                        // GamesPlayed = 0,
                        // GamesWon = 0,
                        // GamesLost = 0,
                        // GamesDraw = 0
                    },

                    new User
                    {
                        UserID = Guid.NewGuid(),
                        Username = "guest",
                        PasswordHash = PasswordHasher.HashPassword("guest"),
                        Name = "Guest User",
                        LastName = "Guest",
                        Email = "guest@example.com",
                        RoleID = guestRoleID,
                        ProfilePicture = new byte[] { /* Thêm dữ liệu byte array nếu có ảnh đại diện mặc định */ },
                        // LastLoginAt = DateTime.UtcNow,
                    },

                    new User
                    {
                        UserID = Guid.NewGuid(),
                        Username = "user1",
                        PasswordHash = PasswordHasher.HashPassword("user1password"),
                        Name = "User One",
                        LastName = "LastOne",
                        Email = "user1@example.com",
                        RoleID = guestRoleID,
                        ProfilePicture = new byte[] { /* Thêm dữ liệu byte array nếu có ảnh đại diện mặc định */ },
                        // LastLoginAt = DateTime.UtcNow,
                    },

                    new User
                    {
                        UserID = Guid.NewGuid(),
                        Username = "user2",
                        PasswordHash = PasswordHasher.HashPassword("user2password"),
                        Name = "User Two",
                        LastName = "LastTwo",
                        Email = "user2@example.com",
                        RoleID = guestRoleID,
                        ProfilePicture = new byte[] { /* Thêm dữ liệu byte array nếu có ảnh đại diện mặc định */ },
                        // LastLoginAt = DateTime.UtcNow,
                    },

                    new User
                    {
                        UserID = Guid.NewGuid(),
                        Username = "user3",
                        PasswordHash = PasswordHasher.HashPassword("user3password"),
                        Name = "User Three",
                        LastName = "LastThree",
                        Email = "user3@example.com",
                        RoleID = guestRoleID,
                        ProfilePicture = new byte[] { /* Thêm dữ liệu byte array nếu có ảnh đại diện mặc định */ },
                        // LastLoginAt = DateTime.UtcNow,
                    },

                    new User
                    {
                        UserID = Guid.NewGuid(),
                        Username = "usertest",
                        PasswordHash = PasswordHasher.HashPassword("usertestpassword"),
                        Name = "User Test",
                        LastName = "TestLast",
                        Email = "usertest@example.com",
                        RoleID = guestRoleID,
                        ProfilePicture = new byte[] { /* Thêm dữ liệu byte array nếu có ảnh đại diện mặc định */ },
                        // LastLoginAt = DateTime.UtcNow,
                    }
                );
            });
        }
    }
}
