using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    class Client : User
    {
       

        public Client(int id, string name, string email, string username, string password) :base(id,name,email,username,password)
        {

        }
    }
}
