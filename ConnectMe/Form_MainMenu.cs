using System;
using System.Windows.Forms;

namespace ConnectMe
{
    public partial class Form_MainMenu : Form
    {
        public Form_MainMenu()
        {
            InitializeComponent();
            CustomizeDesign();
            FormManager.SetPanelChildForm(panelChildForm);

            if (AccountsManager.GetLoggedUser() is Client) buttonManageCategories.Visible = false;
            else if (AccountsManager.GetLoggedUser() is Admin) buttonAtividadesInscritas.Visible = false;
        }

        void CustomizeDesign()
        {
            panelSubMenu.Visible = false;
        }

        void HideSubMenu()
        {
            if (panelSubMenu.Visible) panelSubMenu.Visible = false;
        }

        void ShowSubMenu()
        {
            if (panelSubMenu.Visible == false)
            {
                HideSubMenu();
                panelSubMenu.Visible = true;
            }
            else panelSubMenu.Visible = false;
        }

        void buttonVerAtividades_Click(object sender, EventArgs e)
        {
            FormManager.OpenActivitiesForm();

            //showSubMenu();
        }

        void buttonTodasAtividades_Click(object sender, EventArgs e)
        {
            //hideSubMenu();
        }

        void buttonAtividadesCategoria_Click(object sender, EventArgs e)
        {
            //Code
            //hideSubMenu();
        }

        void buttonAtividadesRegiao_Click(object sender, EventArgs e)
        {
            //Code
            //hideSubMenu();
        }

        void buttonAtividadesInscritas_Click(object sender, EventArgs e)
        {
            FormManager.OpenActivitiesParticipatingForm();
            //FormManager.ShowActivitiesOption = "Participating activities";
            //FormManager.openChildForm(new ShowActivities_form());
            //hideSubMenu();
        }

        void buttonAtividadesCriadas_Click(object sender, EventArgs e)
        {
            FormManager.OpenActivitiesCreatedForm();
            //hideSubMenu();
        }

        void buttonCriarAtividades_Click(object sender, EventArgs e)
        {
            FormManager.OpenCreateActivityForm();
            //Code
            //hideSubMenu();
        }

        void Form3_Load(object sender, EventArgs e) { }

        void panelChildForm_Paint(object sender, PaintEventArgs e) { }

        void buttonLogout_Click(object sender, EventArgs e)
        {
            AccountsManager.Logout();
            Close();
            var loginForm = new FormLogin();
            loginForm.Show();
        }

        void buttonManageCategories_Click(object sender, EventArgs e)
        {
            FormManager.OpenManageCategories();
        }

        private void buttonActivitiesHistory_Click(object sender, EventArgs e)
        {
            FormManager.OpenActivitiesHistoryForm();
        }
    }
}