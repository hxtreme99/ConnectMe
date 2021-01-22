using System;
using System.Collections.Generic;

namespace ConnectMe
{
    class Activity
    {
        static readonly List<User> _users = new List<User>();

        public Activity(int id,
            string name,
            User user,
            Category category,
            string location,
            DateTime date,
            string description,
            int maxPeople)
        {
            Id = id;
            Name = name;
            User = user;
            Category = category;
            Location = location;
            Date = date;
            Description = description;
            MaxPeople = maxPeople;
        }
        //private int id;
        //private String name;
        //private User user;
        //private Category category;
        //private String location;
        //private String date;
        //private String description;
        //private int maxPeople;

        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int MaxPeople { get; set; }

        public static List<User> GetUsers() => _users;

        public static void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}