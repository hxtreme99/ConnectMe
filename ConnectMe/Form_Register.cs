using System;
using System.Windows.Forms;

namespace ConnectMe
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        void txtUsername_TextChanged(object sender, EventArgs e) { }

        void label1_Click(object sender, EventArgs e) { }

        void label2_Click(object sender, EventArgs e) { }

        //Sign up button
        void button1_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var name = txtName.Text;
            var email = txtEmail.Text;

            var statement = "SELECT * FROM `user` WHERE `username` = @0 AND `password`= @1";
            string[] values =
            {
                username,
                password
            };
            var table = Db.ExecuteSql(statement, values);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Username ja existe!");
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) )
            {
                MessageBox.Show("Todos os campos têm que estar preenchidos!");
                return;
            }

            statement =
                "INSERT INTO `user` (`id`, `name`, `e-mail`, `username`, `password`) VALUES (@0, @1 , @2 , @3, @4)";
            string[] values2 =
            {
                "NULL",
                name,
                email,
                username,
                password
            };

            Db.ExecuteSql(statement, values2);
            var id = Db.GetId();
            //MessageBox.Show(id.ToString());
            statement = "INSERT INTO `role` (`User_id`, `type`) VALUES (@0, 'client')";
            object[] values3 = {id};
            Db.ExecuteSql(statement, values3);
            MessageBox.Show("Utilizador criado com sucesso!");
            new FormLogin().Show();
            Hide();
            
        }

        void textBox1_TextChanged(object sender, EventArgs e) { }

        void label5_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            Hide();
        }

        void textBox2_TextChanged(object sender, EventArgs e) { }

        void Form2_Load(object sender, EventArgs e) { }
    }
}