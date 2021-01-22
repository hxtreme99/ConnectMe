using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectMe
{
    public static class FormManager
    {
        private static Form activeForm = null;
        private static Panel panelChildForm= null;
        private static Form previousForm = null;
        
        public static string ShowActivitiesOption { get; set; }
        public static string CreateEditOption { get; set; }
        public static void setPanelChildForm(Panel panelChildForms)
        {
            panelChildForm = panelChildForms;
        }

        public static void goBack()
        {
            Form form = (Form)Activator.CreateInstance(previousForm.GetType());
            openChildForm(form);
        }

        
        private static void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            previousForm = activeForm;
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        public static void openActivitiesCreatedForm()
        {
            ShowActivitiesOption = "Created activities";
            openChildForm(new Form_ShowActivities());
        }

        public static void openActivitiesForm()
        {
            ShowActivitiesOption = "All activities";
            openChildForm(new Form_ShowActivities());
        }

        public static void openActivitiesParticipatingForm()
        {
            ShowActivitiesOption = "Participating activities";
            FormManager.openChildForm(new Form_ShowActivities());
        }

        public static void openCreateActivityForm()
        {
            CreateEditOption = "Create activity";
            openChildForm(new Form_CreateEditActivity());
        }

        public static void openEditActivityForm()
        {
            FormManager.CreateEditOption = "Edit activity";
            FormManager.openChildForm(new Form_CreateEditActivity());
        }
        public static void openActivityProfileForm()
        {
            openChildForm(new Form_ActivityProfile());
        }
        public static void openManageCategories()
        {
            openChildForm(new Form_ManageCategories());
        }
    }
}
