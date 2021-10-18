using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpv1
{
    interface IUsers
    {
        int? Create(
            string login,
                string password,
                string email,
                int roleId);
    }
}
