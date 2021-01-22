using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    static class ActivityManager
    {
        private static Activity currentActivity;
        public static int NumberOfParticipants { get; set; }
        
        public static Activity getCurrentActivity()
        {
            return currentActivity;
        }

        public static void setCurrentActivity(Activity activity)
        {
            currentActivity = activity;
        }


        public static Activity createActivityId(int id)
        {
            string statement = "SELECT * FROM `activity` WHERE id = @0";
            Object[] values = { id };

            DataTable table = DB.ExecuteSQL(statement, values);
            DataRow[] datarow = table.Select();

            foreach (DataRow row in datarow)
            {
                var name = row["name"].ToString();
                var location = row["localization"].ToString();
                var date = row["date"].ToString();
                var description = row["description"].ToString();
                var max_people = row["max_people"].ToString();
                var user_created_activity = row["User_id"].ToString();
                var category_of_activity = row["Category_id"].ToString();

                int.TryParse(user_created_activity, out int intUserID);
                User user = AccountsManager.createUser(intUserID);

                int.TryParse(category_of_activity, out int intCategoryID);
                Category category = CategoryManager.getCategory_by_id(intCategoryID);

                int.TryParse(max_people, out int intMaxPeople);
                
                DateTime myDate = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture);
                Activity activity = new Activity(id, name,user,category,location,myDate,description,intMaxPeople);
                //Activity.addActivity(activity);
                return activity;
            }
            return null;
        }
    }
}
