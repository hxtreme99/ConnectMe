using System.Collections.Generic;

namespace ConnectMe
{
    abstract class User
    {
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

       
    }
}