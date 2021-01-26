using System.Collections.Generic;

namespace ConnectMe
{
    static class CategoryManager
    {
        static readonly List<Category> _categories = new List<Category>();

        public static void UpdateCategories()
        {
            _categories.Clear();
            var statement = "SELECT * FROM `category`";
            var table = Db.ExecuteSql(statement, null);
            var datarow = table.Select();

            foreach (var row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["name"].ToString();

                int.TryParse(id, out var resultid);
                var category = new Category(resultid, name);
                _categories.Add(category);
            }
        }

        public static Category getCategory_by_id(int id)
        {
            var statement = "SELECT * FROM `category` WHERE id=@0";
            object[] values = {id};
            var table = Db.ExecuteSql(statement, values);
            var datarow = table.Select();

            var name = datarow[0]["name"].ToString();
            var category = new Category(id, name);

            return category;
        }

        public static IEnumerable<Category> GetCategories() => _categories;
    }
}