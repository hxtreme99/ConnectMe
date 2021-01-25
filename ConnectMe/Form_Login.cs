using System;
using System.Windows.Forms;

namespace ConnectMe
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        void Form1_Load(object sender, EventArgs e) { }

        

        void label1_Click(object sender, EventArgs e)
        {
            new FormRegister().Show();
            Hide();
        }

        void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void panel2_Paint(object sender, PaintEventArgs e) { }

        void panel1_Paint(object sender, PaintEventArgs e) { }

        void pictureBox3_Click(object sender, EventArgs e) { }

        void pictureBox2_Click(object sender, EventArgs e) { }

        void pictureBox1_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            //Login button

            var username = textUsername.Text;
            var password = textPassword.Text;

            var loginSuccessful = AccountsManager.Login(username, password);

            if (loginSuccessful)
            {
                MessageBox.Show("Bem Vindo " + AccountsManager.GetLoggedUser().Name + "!");
                new Form_MainMenu().Show();
                Hide();
            }
            else
            {
                MessageBox.Show("O utilizador ou a password inseridos estão incorretos");
                textUsername.Clear();
                textPassword.Clear();
            }
            
        }
    }
}