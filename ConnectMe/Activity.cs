using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    class Activity
    {
        private static List<User> users = new List<User>();
        //private int id;
        //private String name;
        //private User user;
        //private Category category;
        //private String location;
        //private String date;
        //private String description;
        //private int maxPeople;

        public int Id { get; set; }
        public String Name { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public String Location { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public int MaxPeople { get; set; }

        public Activity(int id, string name, User user, Category category,string location, DateTime date, string description, int maxPeople)
        {
            
            this.Id = id;
            this.Name = name;
            this.User = user;
            this.Category = category;
            this.Location = location;
            this.Date = date;
            this.Description = description;
            this.MaxPeople = maxPeople;
        }
        public static List<User> getUsers()
        {
            return users;
        }
        public static void addUser(User user)
        {
            users.Add(user);
        }
        
     
    }
}
