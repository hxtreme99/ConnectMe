using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    class Controller
    {
        public Controller()
        {
            
        }
        
        public void DataFromDB()
        {
            //Populate user list with clients
            String statement = "SELECT * FROM `utilizador`,`cliente` WHERE id=utilizador_id";
            populateUsers(statement);

            //Populate user list with admins
            statement = "SELECT * FROM `utilizador`,`administrador` WHERE id=utilizador_id";
            populateUsers(statement);

            //Populate category list with concreteCategory objects
            statement = "SELECT id,nome FROM `geral`,`categoria` WHERE id=categoria_id";
            populateCategory(statement);

            //Populate activity list with events(concrete class)
            statement = "SELECT * FROM `atividade`,`evento` WHERE id=atividade_id";
            populateActivity(statement);
        }

        private void populateUsers(String statement)
        {
            DataTable table = DB.ExecuteSQL(statement, null);
            DataRow[] datarow = table.Select();

            foreach (DataRow row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["nome"].ToString();
                var email = row["e-mail"].ToString();
                var username = row["nome_utilizador"].ToString();
                var password = row["password"].ToString();

                int.TryParse(id, out int resultid);
                User client = new Client(resultid, name, email, username, password);
                User.addUser(client);
            }
        }

        private void populateCategory(String statement)
        {
            DataTable table = DB.ExecuteSQL(statement, null);
            DataRow[] datarow = table.Select();

            foreach (DataRow row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["nome"].ToString();
                

                int.TryParse(id, out int resultid);
                Category category = new Category(resultid, name);
                Category.addCategory(category);
            }
        }

        private void populateActivity(String statement)
        {
            DataTable table = DB.ExecuteSQL(statement, null);
            DataRow[] datarow = table.Select();

            foreach (DataRow row in datarow)
            {
                var id = row["id"].ToString();
                var name = row["nome"].ToString();
                var location = row["local"].ToString();
                var date = row["horario"].ToString();
                var description = row["descricao"].ToString();
                var rules = row["regras"].ToString();
                var max_people = row["max_pessoas"].ToString();
                var user_created_activity = row["Utilizador_id"].ToString();
                var category_of_activity = row["Categoria_id"].ToString();

                int.TryParse(user_created_activity, out int intUserID);
                //User user = User.searchUser(intUserID);

                int.TryParse(category_of_activity, out int intCategoryID);
                //Category category = Category.searchCategory(intCategoryID);

                int.TryParse(max_people, out int intMaxPeople);

                int.TryParse(id, out int intActivityId);
                //Activity activity = new Event(intActivityId, name,user,category,location,date,description,rules,intMaxPeople);
                //Activity.addActivity(activity);
            }
        }
    }
}
