namespace ConnectMe
{
    static class AccountsManager
    {
        static User _userLogged;

        public static bool Login(string username, string password)
        {
            const string statement =
                "SELECT * FROM `user`,`role` WHERE `username` = @0 AND `password`= @1 AND user.id=role.User_id";
            object[] values =
            {
                username,
                password
            };
            var table = Db.ExecuteSql(statement, values);

            if (table.Rows.Count > 0)
            {
                var datarow = table.Select();
                var idStr = datarow[0]["id"].ToString();

                int.TryParse(idStr, out var id);
                _userLogged = CreateUser(id);
                return true;
            }

            return false;
        }

        public static void Logout()
        {
            _userLogged = null;
        }

        public static User GetLoggedUser() => _userLogged;

        public static User CreateUser(int id)
        {
            const string statement = "SELECT * FROM `user`,`role` WHERE id=User_id AND id=@0";
            object[] values = {id};
            var table = Db.ExecuteSql(statement, values);
            var datarow = table.Select();

            foreach (var row in datarow)
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

                User admin = new Admin(id, name, email, username, password);
                return admin;
            }

            return null;
        }
    }
}