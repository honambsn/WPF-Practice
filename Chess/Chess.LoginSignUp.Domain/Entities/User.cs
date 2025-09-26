using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Domain.Entities
{
    public class User
    {
        public Guid UserID { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Guid RoleID { get; set; }
        public Role Role { get; set; }
    }
}
