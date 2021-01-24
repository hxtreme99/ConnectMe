using System;
using System.Windows.Forms;

namespace ConnectMe
{
    public partial class FormCreateEditActivity : Form
    {
        public FormCreateEditActivity()
        {
            InitializeComponent();
            FormManager.FillComboBox(comboBoxCategory);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy HH:mm";

            if (FormManager.CreateEditOption.Equals("Create activity"))
            {
                labelTitle.Text = "Criar Atividade";
                buttonCreate.Text = "Criar";
            }
            else
            {
                PreSelectFields();
                labelTitle.Text = "Editar Atividade";
                buttonCreate.Text = "Actualizar";
            }
        }


        void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        void textBox1_TextChanged(object sender, EventArgs e) { }

        void textBox2_TextChanged(object sender, EventArgs e) { }

        void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }

        void textBox3_TextChanged(object sender, EventArgs e) { }

        void richTextBox1_TextChanged(object sender, EventArgs e) { }

        void buttonCreate_Click(object sender, EventArgs e)
        {
            var activityName = nameActivity.Text;
            var local = localization.Text;
            var dateTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            var maxPeople = this.maxPeople.Text;
            var descriptions = description.Text;

            //-------------------Verifications--------------------
            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma categoria");
                return;
            }

            var categoryName = comboBoxCategory.SelectedItem.ToString();
            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(activityName) ||
                string.IsNullOrEmpty(local) || string.IsNullOrEmpty(dateTime) ||
                string.IsNullOrEmpty(maxPeople) || string.IsNullOrEmpty(descriptions))
            {
                MessageBox.Show("Todos os campos têm que estar preenchidos!");
                return;
            }

            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Insira uma data válida!");
                return;
            }

            if (!int.TryParse(maxPeople,out int MaxPeopleResult))
            {
                MessageBox.Show("Insira um número máximo de pessoas válido");
                return;
                
            }
            //---------------------------------------------------

            Category categorySelected = (Category) comboBoxCategory.SelectedItem;

            if (FormManager.CreateEditOption.Equals("Create activity"))
            {
                var statement =
                    "INSERT INTO `activity` (`id`, `Category_id`, `User_id`, `name`, `localization`, `date`, `description`, `max_people`) VALUES (NULL, @0, @1, @2, @3 ,@4, @5, @6)";
                object[] values =
                {
                    categorySelected.Id,
                    AccountsManager.GetLoggedUser().Id,
                    activityName,
                    local,
                    dateTime,
                    descriptions,
                    maxPeople
                };
                Db.ExecuteSql(statement, values);
                MessageBox.Show("Atividade inserida");
                FormManager.OpenActivitiesCreatedForm();
            }
            else //Edit activity
            {
                var statement =
                    "UPDATE `activity` SET `Category_id` = @0, `name` = @1, `localization` = @2, `date` = @3, `description` = @4, `max_people` = @5 WHERE `activity`.`id` = @6";
                object[] values =
                {
                    categorySelected.Id,
                    activityName,
                    local,
                    dateTime,
                    descriptions,
                    maxPeople,
                    ActivityManager.GetCurrentActivity().Id
                };
                Db.ExecuteSql(statement, values);
                MessageBox.Show("Atividade editada");
                FormManager.OpenActivitiesCreatedForm();
            }
        }

        void PreSelectFields()
        {
            var currentActivity = ActivityManager.GetCurrentActivity();
            nameActivity.Text = currentActivity.Name;
            localization.Text = currentActivity.Location;
            dateTimePicker1.Value = currentActivity.Date;
            maxPeople.Text = currentActivity.MaxPeople.ToString();
            description.Text = currentActivity.Description;

           
            foreach (Category category in comboBoxCategory.Items)
            {
                if (category.Id == currentActivity.Category.Id)
                {
                    comboBoxCategory.SelectedItem = category;
                }
            }

        }

        
        void labelTitle_Click(object sender, EventArgs e) { }
    }
}