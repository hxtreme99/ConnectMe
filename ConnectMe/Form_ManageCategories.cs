using System.Windows.Forms;
using System.Windows.Markup;

namespace ConnectMe
{
    public partial class FormManageCategories : Form
    {
        public FormManageCategories()
        {
            InitializeComponent();
            FormManager.FillComboBox(comboBoxCategories);
        }

        private void labelTitle_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonDeleteCategory_Click(object sender, System.EventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem a certeza que quer eliminar esta atividade?",
                "Atividade removida!",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                Category selectedCategory = (Category)comboBoxCategories.SelectedItem;
                object[] values = new[] { selectedCategory.Id.ToString() };

                string statement = "DELETE FROM `user_has_activity` WHERE Activity_id IN (SELECT id FROM `activity` WHERE Category_id=@0)";
                Db.ExecuteSql(statement, values);
                statement = "DELETE FROM `activity` WHERE activity.Category_id=@0";
                Db.ExecuteSql(statement, values);
                statement = "DELETE FROM `category` WHERE `category`.`id` = @0";
                Db.ExecuteSql(statement, values);
                
                MessageBox.Show("Categoria eliminada");
                FormManager.OpenManageCategories(); //reload form
            }
        }

        private void buttonCreateCategory_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCategoryName.Text))
            {
                MessageBox.Show("Insira um nome para a categoria");
                return;
            }

            string statement = "INSERT INTO `category` (`id`, `name`) VALUES (NULL, @0)";
            object[] values = new[] {textBoxCategoryName.Text};
            Db.ExecuteSql(statement, values);

            MessageBox.Show("Categoria criada");
            FormManager.OpenManageCategories(); //reload form
        }
    }
}