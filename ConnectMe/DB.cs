using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConnectMe
{
    static class Db
    {
        static readonly MySqlConnection _connection =
            new MySqlConnection("server=localhost;port=3306;username=root;password=;database=connectme");

        static int _lastId;

        static void OpenConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed) _connection.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Verifique a conexão à internet");
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique a conexão à internet");
            }
        }

        static void CloseConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Open) _connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Verifique a conexão à internet");
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique a conexão à internet");
            }
        }

        public static MySqlConnection GetConnection() => _connection;

        public static int GetId() => _lastId;

        public static DataTable ExecuteSql(string statement, object[] values)
        {
            OpenConnection();
            var table = new DataTable();

            var adapter = new MySqlDataAdapter();

            var command = new MySqlCommand(statement, _connection);
            if (values != null)
            {
                string value;
                for (var i = 0; i < values.Length; i++)
                {
                    value = "@" + i;
                    if (values[i] is string)
                        command.Parameters.Add(value, MySqlDbType.VarChar).Value = values[i];
                    else if (values[i] is int)
                        command.Parameters.Add(value, MySqlDbType.Int32).Value = values[i];
                }
            }

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(table);
            }
            catch (SqlException)
            {
                MessageBox.Show("Verifique a conexão à internet");
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique a conexão à internet");
            }

            _lastId = (int) command.LastInsertedId;

            CloseConnection();
            return table;
        }
    }
}