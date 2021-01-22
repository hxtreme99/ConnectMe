using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    abstract class User
    {
        private static List<User> users = new List<User>();
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }


        //public static User searchUser(int id)
        //{
        //    foreach (var item in users)
        //    {
        //        if (item.id==id)
        //        {
        //            return item;
        //        }
        //    }
        //    return null;
        //}
        public static List<User> getUsers()
        {
            return users;
        }
        public static void addUser(User user)
        {
            users.Add(user);
        }
        //public int Id
        //{
        //    get { return id; }
        //    set { id = value;  }
        //}
        //public String Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        //public String Email
        //{
        //    get { return email; }
        //    set { email = value; }
        //}
        //public String Username
        //{
        //    get { return username; }
        //    set { username = value; }
        //}
        public User(int id, string name, string email, string username, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

    }
}
