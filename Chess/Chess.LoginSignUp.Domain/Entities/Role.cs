using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Domain.Entities
{
    public class Role
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        // nagigation property
        public ICollection<User> Users { get; set; }
    }
}
