using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    static class AccountsManager
    {
        private static User userLogged;


        public static Boolean login(string username, string password)
        {
            String statement = "SELECT * FROM `user`,`role` WHERE `username` = @0 AND `password`= @1 AND user.id=role.User_id";
            String[] values = { username, password };
            DataTable table = DB.ExecuteSQL(statement, values);

            if (table.Rows.Count > 0)
            {
                DataRow[] datarow = table.Select();
                var id_str=datarow[0]["id"].ToString();

                int.TryParse(id_str, out int id);
                userLogged = createUser(id);
                return true;
            }
            else
            {
                return false;
            }


        }

        public static void logout()
        {
            userLogged = null;
        }

        public static User getLoggedUser()
        {
            return userLogged;
        }

        public static User createUser(int id)
        {
            String statement = "SELECT * FROM `user`,`role` WHERE id=User_id AND id=@0";
            Object[] values = { id};
            DataTable table = DB.ExecuteSQL(statement, values);
            DataRow[] datarow = table.Select();

            foreach (DataRow row in datarow)
            {
                var name = row["name"].ToString();
                var email = row["e-mail"].ToString();
                var username = row["username"].ToString();
                var password = row["password"].ToString();
                var type = row["type"].ToString();

                if (type.Equals("client"))
                {
                    User client = new Client(id, name, email, username, password);
                    return client;
                }
                else
                {
                    User admin = new Admin(id, name, email, username, password);
                    return admin;
                }
                
            }
            return null;
        }
    }
}
