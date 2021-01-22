using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    class Admin : User
    {
        public Admin(int id, string name, string email, string username, string password) : base(id, name, email, username, password)
        {

        }

    }
}
