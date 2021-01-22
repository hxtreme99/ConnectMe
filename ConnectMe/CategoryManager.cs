using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    static class CategoryManager
    {
        public static List<Category> categories = new List<Category>();

        public static void updateCategories()
        {
            categories.Clear();
            string statement = "SELECT * FROM `category`";
            DataTable table = DB.ExecuteSQL(statement, null);
            DataRow[] datarow = table.Select();

            foreach (DataRow row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["name"].ToString();


                int.TryParse(id, out int resultid);
                Category category = new Category(resultid, name);
                categories.Add(category);
            }
        }

        public static int getCategoryId(string name)
        {
            foreach (Category category in categories)
            {
                if (name.Equals(category.Name))
                {
                    return category.Id;
                }
                
            }
            return 0;
        }
        public static List<String> getAllCategoriesNames()
        {
            List<String> categoriesNamesList = new List<string>();
            foreach (Category category in categories)
            {
                categoriesNamesList.Add(category.Name);     
            }
            return categoriesNamesList;
        }
        public static Category getCategory_by_id(int id)
        {
            string statement = "SELECT * FROM `category` WHERE id=@0";
            Object[] values = { id };
            DataTable table = DB.ExecuteSQL(statement, values);
            DataRow[] datarow = table.Select();

            var name = datarow[0]["name"].ToString();
            Category category = new Category(id, name);
            
            return category;
        }

    }
}
