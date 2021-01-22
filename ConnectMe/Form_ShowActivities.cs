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
    public partial class Form_ShowActivities : Form
    {
        
        public Form_ShowActivities()
        {
            
            InitializeComponent();

            fillComboBox();
            
        }

        private void fillTable(String statement,String[] values)
        {
               DataTable table = DB.ExecuteSQL(statement, values);
            dataGridView1.DataSource = table;
            dataGridView1.Columns["id"].Visible = false;

            //Formatação da tabela
            
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
            }
            dataGridView1.Columns[dataGridView1.Columns.Count-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void fillComboBox()
        {
            CategoryManager.updateCategories();
            comboBox1.Items.Add("Todas as categorias");
            
            List<String> categoriesNames=CategoryManager.getAllCategoriesNames();
            foreach (String categoryName in categoriesNames)
            {
                comboBox1.Items.Add(categoryName);
            }
            comboBox1.SelectedIndex=0;
        }
        private void ShowActivities_Load(object sender, EventArgs e)
        {
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String statement = "" ;
            String[] values= null;
            
                switch (FormManager.ShowActivitiesOption)
                {
                    case "All activities":
                        TitleActivities.Text="Atividades";
                        statement = "SELECT activity.id,category.name AS Categoria,activity.name AS Atividade,localization AS Localização,date AS Data FROM `activity`,`category` WHERE category.id=activity.Category_id";
                        values = null;
                        break;

                    case "Participating activities":
                        TitleActivities.Text = "Atividades Inscritas";
                        statement = "SELECT activity.id,category.name AS Categoria,activity.name AS Atividade,localization AS Localização,date AS Data FROM `activity`,`category`,`user_has_activity` WHERE category.id=activity.Category_id AND user_has_activity.User_id=@0 AND user_has_activity.Activity_id=activity.id";
                        values = new string[] { AccountsManager.getLoggedUser().Id.ToString() };
                        break;

                    case "Created activities":
                        TitleActivities.Text = "Atividades Criadas";
                        statement = "SELECT activity.id,category.name AS Categoria,activity.name AS Atividade,localization AS Localização,date AS Data FROM `activity`,`category` WHERE category.id=activity.Category_id AND activity.User_id=@0";
                        values = new string[] { AccountsManager.getLoggedUser().Id.ToString() };
                        break;
                    
                    default:
                        break;
                }
                
                
            if (!(comboBox1.SelectedItem.ToString().Equals("Todas as categorias")))
            {
                
                if (FormManager.ShowActivitiesOption.Equals("All activities"))
                {
                    
                    statement= statement + " AND category.name=@0";
                    values = new string[] { comboBox1.SelectedItem.ToString() };
                }
                else
                {
                    statement = statement + " AND category.name=@1";
                    values = new string[] { AccountsManager.getLoggedUser().Id.ToString(),comboBox1.SelectedItem.ToString() };
                }
            }

            fillTable(statement, values);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
            Activity activity = ActivityManager.createActivityId(id);


            ActivityManager.setCurrentActivity(activity);
            FormManager.openActivityProfileForm();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
