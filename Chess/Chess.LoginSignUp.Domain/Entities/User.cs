using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Domain.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public Guid UserID { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public string DisplayName => $"{Name} {LastName}".Trim();
        public byte[] ProfilePicture { get; set; }
        public Guid RoleID { get; set; }
        public Role Role { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //public DateTime? LastLoginAt { get; set; }

        //public int Rating { get; set; } = 1200;

        //public int GamesPlayed { get; set; }

        //public int GamesWon { get; set; }

        //public int GamesLost { get; set; }

        //public int GamesDraw { get; set; }
    }
}
