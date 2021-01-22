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
    public partial class Form3 : Form
    {
        
        
        public Form3()
        {
            InitializeComponent();
            customizeDesign();
            FormManager.setPanelChildForm(panelChildForm);

            if (AccountsManager.getLoggedUser() is Client)
            {
                buttonManageCategories.Visible = false;
            }
            else if (AccountsManager.getLoggedUser() is Admin)
            {
                buttonAtividadesInscritas.Visible = false;
            }
            

        }
        private void customizeDesign()
        {
            panelSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelSubMenu.Visible==true)
            {
                panelSubMenu.Visible = false;
            }
        }

        private void showSubMenu()
        {
            if (panelSubMenu.Visible == false)
            {
                hideSubMenu();
                panelSubMenu.Visible = true;
            }
            else
            {
                panelSubMenu.Visible = false;
            }
        }
        private void buttonVerAtividades_Click(object sender, EventArgs e)
        {
            FormManager.openActivitiesForm();

            //showSubMenu();
        }

        private void buttonTodasAtividades_Click(object sender, EventArgs e)
        {
            
            //hideSubMenu();
        }
        
        private void buttonAtividadesCategoria_Click(object sender, EventArgs e)
        {
            //Code
            //hideSubMenu();
        }

        private void buttonAtividadesRegiao_Click(object sender, EventArgs e)
        {
            //Code
            //hideSubMenu();
        }

        private void buttonAtividadesInscritas_Click(object sender, EventArgs e)
        {
            FormManager.openActivitiesParticipatingForm();
            //FormManager.ShowActivitiesOption = "Participating activities";
            //FormManager.openChildForm(new ShowActivities_form());
            //hideSubMenu();
        }

        private void buttonAtividadesCriadas_Click(object sender, EventArgs e)
        {
            FormManager.openActivitiesCreatedForm();
            //hideSubMenu();
        }

        private void buttonCriarAtividades_Click(object sender, EventArgs e)
        {
            FormManager.openCreateActivityForm();
            //Code
            //hideSubMenu();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

     
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            AccountsManager.logout();
            this.Close();
            Form_Login login_Form = new Form_Login();
            login_Form.Show();
        }

        private void buttonManageCategories_Click(object sender, EventArgs e)
        {
            FormManager.openManageCategories();
        }
    }
}
