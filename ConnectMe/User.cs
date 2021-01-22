using System.Collections.Generic;

namespace ConnectMe
{
    abstract class User
    {
        static readonly List<User> _users = new List<User>();
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
            Id = id;
            Name = name;
            Email = email;
            Username = username;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

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
        public static List<User> GetUsers() => _users;

        public static void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}