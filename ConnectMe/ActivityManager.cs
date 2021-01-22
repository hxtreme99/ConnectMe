using System;
using System.Globalization;

namespace ConnectMe
{
    static class ActivityManager
    {
        static Activity _currentActivity;
        public static int NumberOfParticipants { get; set; }

        public static Activity GetCurrentActivity() => _currentActivity;

        public static void SetCurrentActivity(Activity activity)
        {
            _currentActivity = activity;
        }

        public static Activity CreateActivityId(int id)
        {
            var statement = "SELECT * FROM `activity` WHERE id = @0";
            object[] values = {id};

            var table = Db.ExecuteSql(statement, values);
            var datarow = table.Select();

            foreach (var row in datarow)
            {
                var name = row["name"].ToString();
                var location = row["localization"].ToString();
                var date = row["date"].ToString();
                var description = row["description"].ToString();
                var maxPeople = row["max_people"].ToString();
                var userCreatedActivity = row["User_id"].ToString();
                var categoryOfActivity = row["Category_id"].ToString();

                int.TryParse(userCreatedActivity, out var intUserId);
                var user = AccountsManager.CreateUser(intUserId);

                int.TryParse(categoryOfActivity, out var intCategoryId);
                var category = CategoryManager.getCategory_by_id(intCategoryId);

                int.TryParse(maxPeople, out var intMaxPeople);

                var myDate = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                var activity = new Activity(id, name, user, category, location, myDate, description,
                    intMaxPeople);
                //Activity.addActivity(activity);
                return activity;
            }

            return null;
        }
    }
}