using System.Collections.Generic;

namespace ConnectMe
{
    static class CategoryManager
    {
        public static List<Category> Categories = new List<Category>();

        public static void UpdateCategories()
        {
            Categories.Clear();
            var statement = "SELECT * FROM `category`";
            var table = Db.ExecuteSql(statement, null);
            var datarow = table.Select();

            foreach (var row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["name"].ToString();

                int.TryParse(id, out var resultid);
                var category = new Category(resultid, name);
                Categories.Add(category);
            }
        }

        public static int GetCategoryId(string name)
        {
            foreach (var category in Categories)
            {
                if (name.Equals(category.Name)) return category.Id;
            }

            return 0;
        }

        public static List<string> GetAllCategoriesNames()
        {
            var categoriesNamesList = new List<string>();
            foreach (var category in Categories) categoriesNamesList.Add(category.Name);
            return categoriesNamesList;
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
    }
}