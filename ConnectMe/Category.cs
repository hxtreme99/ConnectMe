using System.Collections.Generic;

namespace ConnectMe
{
    class Category
    {
        static readonly List<Category> _categories = new List<Category>();

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;
    }
}