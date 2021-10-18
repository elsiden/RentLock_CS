using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpv1
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int roleId { get; set; }
        public User() { }
        public User(string login, string password, string email, int roleId)
        {
            this.login = login;
            this.email = email;
            this.password = password;
            this.roleId = roleId;
        }
    }
}