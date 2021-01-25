using System;
using System.Windows.Forms;

namespace ConnectMe
{
    public static class FormManager
    {
        static Form _activeForm;
        static Panel _panelChildForm;
        static Form _previousForm;

        public static string ShowActivitiesOption { get; set; }
        public static string CreateEditOption { get; set; }

        public static void SetPanelChildForm(Panel panelChildForms)
        {
            _panelChildForm = panelChildForms;
        }

        public static void GoBack()
        {
            var form = (Form) Activator.CreateInstance(_previousForm.GetType());
            OpenChildForm(form);
        }

        static void OpenChildForm(Form childForm)
        {
            if (_activeForm != null) _activeForm.Close();
            _previousForm = _activeForm;
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            _panelChildForm.Controls.Add(childForm);
            _panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public  static void FillComboBox(ComboBox comboBox)
        {
            CategoryManager.UpdateCategories();

            var categories = CategoryManager.GetCategories();
            foreach (var category in categories) comboBox.Items.Add(category);

            comboBox.SelectedIndex = 0;
        }
        public static void OpenActivitiesCreatedForm()
        {
            ShowActivitiesOption = "Created activities";
            OpenChildForm(new FormShowActivities());
        }

        public static void OpenActivitiesForm()
        {
            ShowActivitiesOption = "All activities";
            OpenChildForm(new FormShowActivities());
        }

        public static void OpenActivitiesParticipatingForm()
        {
            ShowActivitiesOption = "Participating activities";
            OpenChildForm(new FormShowActivities());
        }

        public static void OpenActivitiesHistoryForm()
        {
            ShowActivitiesOption = "History Activities";
            OpenChildForm(new FormShowActivities());
        }
        public static void OpenCreateActivityForm()
        {
            CreateEditOption = "Create activity";
            OpenChildForm(new FormCreateEditActivity());
        }

        public static void OpenEditActivityForm()
        {
            CreateEditOption = "Edit activity";
            OpenChildForm(new FormCreateEditActivity());
        }

        public static void OpenActivityProfileForm()
        {
            OpenChildForm(new FormActivityProfile());
        }

        public static void OpenManageCategories()
        {
            OpenChildForm(new FormManageCategories());
        }
    }
}