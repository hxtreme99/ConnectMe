using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectMe
{
    public partial class Form_Register : Form
    {
        public Form_Register()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        //Sign up button
        private void button1_Click(object sender, EventArgs e)
        {

            String username = txtUsername.Text;
            String password = txtPassword.Text;
            String name = txtName.Text;
            String email = txtEmail.Text;



            String statement = "SELECT * FROM `user` WHERE `username` = @0 AND `password`= @1";
            String[] values = { username, password };
            DataTable table = DB.ExecuteSQL(statement, values);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Username ja existe!");
            }
            else
            {
                statement = "INSERT INTO `user` (`id`, `name`, `e-mail`, `username`, `password`) VALUES (@0, @1 , @2 , @3, @4)";
                String[] values2 = { "NULL", name, email, username, password }; 

                DB.ExecuteSQL(statement, values2);
                int id = DB.getId();
                //MessageBox.Show(id.ToString());
                statement = "INSERT INTO `role` (`User_id`, `type`) VALUES (@0, 'client')";
                Object[] values3 = { id };
                DB.ExecuteSQL(statement, values3);
                MessageBox.Show("Utilizador criado com sucesso!");
                new Form_Login().Show();
                this.Hide();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            new Form_Login().Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
