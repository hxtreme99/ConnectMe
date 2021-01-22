using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    class Category
    {
        private static List<Category> categories = new List<Category>();

        public int Id { get; set; }
        public string Name { get; set; }
        

        public Category(int id,String name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static void addCategory(Category category)
        {
            categories.Add(category);
        }

        public static List<Category> GetCategories()
        {
            return categories;
        }
        
    }
}
