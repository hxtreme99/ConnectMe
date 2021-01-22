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
    public partial class Form_Login : Form
    {
       
        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Login button
        private void button1_Click(object sender, EventArgs e)
        {
           
            String username = txtUsername.Text;
            String password = txtpassword.Text;

            bool loginSuccessful=AccountsManager.login(username,password);

            if (loginSuccessful)
            {
                MessageBox.Show("Bem Vindo " + AccountsManager.getLoggedUser().Name + "!");
                new Form3().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("O utilizador ou a password inseridos estão incorretos");
                txtUsername.Clear();
                txtpassword.Clear();
            }


        }


        private void label1_Click(object sender, EventArgs e)
        {
            new Form_Register().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}