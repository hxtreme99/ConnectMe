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
    public partial class Form_CreateEditActivity : Form
    {
        public Form_CreateEditActivity()
        {
            InitializeComponent();
            fillComboBox();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy HH:mm";

            if (FormManager.CreateEditOption.Equals("Create activity"))
            {
                labelTitle.Text = "Criar Atividade";
                buttonCreate.Text = "Criar";
            }
            else
            {
                preSelectFields();
                labelTitle.Text = "Editar Atividade";
                buttonCreate.Text = "Confirmar";
            }
        }
        private void fillComboBox()
        {
            CategoryManager.updateCategories();
            List<String> categoriesNames = CategoryManager.getAllCategoriesNames();
            foreach (String categoryName in categoriesNames)
            {
                comboBoxCategory.Items.Add(categoryName);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            
            string activityName = nameActivity.Text;
            string local = localization.Text;
            string dateTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string max_people = maxPeople.Text;
            string descriptions = description.Text;
            
            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma categoria");
                return;
            }

            string categoryName = comboBoxCategory.SelectedItem.ToString();
            if (String.IsNullOrEmpty(categoryName) || String.IsNullOrEmpty(activityName) || String.IsNullOrEmpty(local) || String.IsNullOrEmpty(dateTime) || String.IsNullOrEmpty(max_people) || String.IsNullOrEmpty(descriptions))
            {
                MessageBox.Show("Todos os campos têm que estar preenchidos!");
                return;
            }

            if (dateTimePicker1.Value<DateTime.Now)
            {
                MessageBox.Show("Insira uma data válida!");
                return;
            }

            if (FormManager.CreateEditOption.Equals("Create activity"))
            {
                string statement = "INSERT INTO `activity` (`id`, `Category_id`, `User_id`, `name`, `localization`, `date`, `description`, `max_people`) VALUES (NULL, @0, @1, @2, @3 ,@4, @5, @6)";
                Object[] values = { CategoryManager.getCategoryId(categoryName), AccountsManager.getLoggedUser().Id, activityName, local, dateTime, descriptions, max_people };
                DB.ExecuteSQL(statement, values);
                MessageBox.Show("Atividade inserida");
                FormManager.openActivitiesCreatedForm();
            }
            else //Edit activity
            {
                string statement = "UPDATE `activity` SET `Category_id` = @0, `name` = @1, `localization` = @2, `date` = @3, `description` = @4, `max_people` = @5 WHERE `activity`.`id` = @6";
                Object[] values = { CategoryManager.getCategoryId(categoryName),  activityName, local, dateTime, descriptions, max_people,ActivityManager.getCurrentActivity().Id };
                DB.ExecuteSQL(statement, values);
                MessageBox.Show("Atividade editada");
                FormManager.openActivitiesCreatedForm();
            }
        }

        private void preSelectFields()
        {
            
            Activity activity = ActivityManager.getCurrentActivity();
            nameActivity.Text=activity.Name;
            localization.Text=activity.Location;
            dateTimePicker1.Value = activity.Date;
            maxPeople.Text=activity.MaxPeople.ToString();
            description.Text=activity.Description;

            comboBoxCategory.SelectedItem=activity.Category.Name;

            

        }
        private void labelTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
