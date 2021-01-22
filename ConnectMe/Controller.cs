namespace ConnectMe
{
    class Controller
    {
        public void DataFromDb()
        {
            //Populate user list with clients
            var statement = "SELECT * FROM `utilizador`,`cliente` WHERE id=utilizador_id";
            PopulateUsers(statement);

            //Populate user list with admins
            statement = "SELECT * FROM `utilizador`,`administrador` WHERE id=utilizador_id";
            PopulateUsers(statement);

            //Populate category list with concreteCategory objects
            statement = "SELECT id,nome FROM `geral`,`categoria` WHERE id=categoria_id";
            PopulateCategory(statement);

            //Populate activity list with events(concrete class)
            statement = "SELECT * FROM `atividade`,`evento` WHERE id=atividade_id";
            PopulateActivity(statement);
        }

        void PopulateUsers(string statement)
        {
            var table = Db.ExecuteSql(statement, null);
            var datarow = table.Select();

            foreach (var row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["nome"].ToString();
                var email = row["e-mail"].ToString();
                var username = row["nome_utilizador"].ToString();
                var password = row["password"].ToString();

                int.TryParse(id, out var resultid);
                User client = new Client(resultid, name, email, username, password);
                User.AddUser(client);
            }
        }

        void PopulateCategory(string statement)
        {
            var table = Db.ExecuteSql(statement, null);
            var datarow = table.Select();

            foreach (var row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["nome"].ToString();

                int.TryParse(id, out var resultid);
                var category = new Category(resultid, name);
                Category.AddCategory(category);
            }
        }

        void PopulateActivity(string statement)
        {
            var table = Db.ExecuteSql(statement, null);
            var datarow = table.Select();

            foreach (var row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["nome"].ToString();
                var location = row["local"].ToString();
                var date = row["horario"].ToString();
                var description = row["descricao"].ToString();
                var rules = row["regras"].ToString();
                var maxPeople = row["max_pessoas"].ToString();
                var userCreatedActivity = row["Utilizador_id"].ToString();
                var categoryOfActivity = row["Categoria_id"].ToString();

                int.TryParse(userCreatedActivity, out var intUserId);
                //User user = User.searchUser(intUserID);

                int.TryParse(categoryOfActivity, out var intCategoryId);
                //Category category = Category.searchCategory(intCategoryID);

                int.TryParse(maxPeople, out var intMaxPeople);

                int.TryParse(id, out var intActivityId);
                //Activity activity = new Event(intActivityId, name,user,category,location,date,description,rules,intMaxPeople);
                //Activity.addActivity(activity);
            }
        }
    }
}