using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMe
{
    static class DB
    {
        private static MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=connectme");
        private static int lastId=0;
        
        public static void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void closeConnection()
        {
            if (connection.State==System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static MySqlConnection GetConnection()
        {
            return connection;
        }

        public static int getId()
        {
            return lastId;
        }
        public static DataTable ExecuteSQL(String statement, Object[] values)
        {
            openConnection();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand(statement, connection);
            if (values!=null)
            {
                String value;
                for (int i = 0; i < values.Length; i++)
                {
                    value = "@" + i;
                    if (values[i] is String)
                    {
                        command.Parameters.Add(value, MySqlDbType.VarChar).Value = values[i];
                    }
                    else if (values[i] is int)
                    {
                        command.Parameters.Add(value, MySqlDbType.Int32).Value = values[i];
                    }
                    
                }
            }

            adapter.SelectCommand = command;

            adapter.Fill(table);

            lastId = (int)command.LastInsertedId;

            closeConnection();
            return table;
        }
    }
}
