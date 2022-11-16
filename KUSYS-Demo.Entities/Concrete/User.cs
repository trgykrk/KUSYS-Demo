using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public User()
        {
            Role = new Role();
        }
    }
}
