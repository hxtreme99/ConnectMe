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
            else if (AccountsManager.GetLoggedUser() is Admin)
            {
                buttonPariticipatingActivities.Visible = false;
                buttonActivitiesHistory.Visible = false;
            }
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

        void buttonActivitiesShowSubMenu_Click(object sender, EventArgs e)
        {
            

            ShowSubMenu();
        }

        void buttonAllActivities_Click(object sender, EventArgs e)
        {
            FormManager.OpenActivitiesForm();
            HideSubMenu();
        }

        void buttonPariticipatingActivities_Click(object sender, EventArgs e)
        {
            FormManager.OpenActivitiesParticipatingForm();
            HideSubMenu();
        }

        void buttonCreatedActivities_Click(object sender, EventArgs e)
        {
            FormManager.OpenActivitiesCreatedForm();
            HideSubMenu();
        }



        void buttonCreateActivities_Click(object sender, EventArgs e)
        {
            FormManager.OpenCreateActivityForm();
            HideSubMenu();
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
            HideSubMenu();
        }

        private void buttonActivitiesHistory_Click(object sender, EventArgs e)
        {
            FormManager.OpenActivitiesHistoryForm();
            HideSubMenu();
        }
    }
}