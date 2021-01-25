using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace ConnectMe
{
    public partial class FormShowActivities : Form
    {
        public FormShowActivities()
        {
            InitializeComponent();

            comboBox1.Items.Add("Todas as categorias");
            FormManager.FillComboBox(this.comboBox1);
        }

        void FillTable(string statement, object[] values)
        {
            var table = Db.ExecuteSql(statement, values);

            DataTable[] tables = SeparateActivities(table); 
                        
            if (FormManager.ShowActivitiesOption.Equals("History activities"))
            {
                dataGridView1.DataSource = tables[1];   //tables[1] passed activities
            }
            else
            {
                dataGridView1.DataSource = tables[0];   //tables[0] future activities
            }
            
            dataGridView1.Columns["id"].Visible = false;

            // Formatação da tabela
            for (var i = 1; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
        }

        

        void ShowActivities_Load(object sender, EventArgs e) { }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var statement = "";
            string[] values = null;

            switch (FormManager.ShowActivitiesOption)
            {
                case "All activities":
                    TitleActivities.Text = "Atividades";
                    statement =
                        "SELECT activity.id,category.name AS Categoria,activity.name AS Atividade,localization AS Localização,date AS Data FROM `activity`,`category` WHERE category.id=activity.Category_id";
                    values = null;
                    break;

                case "Participating activities":
                    TitleActivities.Text = "Atividades Inscritas";
                    statement =
                        "SELECT activity.id,category.name AS Categoria,activity.name AS Atividade,localization AS Localização,date AS Data FROM `activity`,`category`,`user_has_activity` WHERE category.id=activity.Category_id AND user_has_activity.User_id=@0 AND user_has_activity.Activity_id=activity.id";
                    values = new[] {AccountsManager.GetLoggedUser().Id.ToString()};
                    break;
                case "History activities":
                    TitleActivities.Text = "Histórico de Atividades";
                    statement =
                        "SELECT activity.id,category.name AS Categoria,activity.name AS Atividade,localization AS Localização,date AS Data FROM `activity`,`category`,`user_has_activity` WHERE category.id=activity.Category_id AND user_has_activity.User_id=@0 AND user_has_activity.Activity_id=activity.id";
                    values = new[] { AccountsManager.GetLoggedUser().Id.ToString() };
                    break;
                case "Created activities":
                    TitleActivities.Text = "Atividades Criadas";
                    statement =
                        "SELECT activity.id,category.name AS Categoria,activity.name AS Atividade,localization AS Localização,date AS Data FROM `activity`,`category` WHERE category.id=activity.Category_id AND activity.User_id=@0";
                    values = new[] {AccountsManager.GetLoggedUser().Id.ToString()};
                    break;
            }

            if (!comboBox1.SelectedItem.ToString().Equals("Todas as categorias"))
            {
                if (FormManager.ShowActivitiesOption.Equals("All activities"))
                {
                    statement = statement + " AND category.name=@0";
                    values = new[] {comboBox1.SelectedItem.ToString()};
                }
                else
                {
                    statement = statement + " AND category.name=@1";
                    values = new[]
                    {
                        AccountsManager.GetLoggedUser().Id.ToString(),
                        comboBox1.SelectedItem.ToString()
                    };
                }
            }

            FillTable(statement, values);
        }

        void button1_Click(object sender, EventArgs e) { }

        void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = (int) dataGridView1.CurrentRow.Cells["id"].Value;
                var activity = ActivityManager.CreateActivityId(id);

                ActivityManager.SetCurrentActivity(activity);
            }

            FormManager.OpenActivityProfileForm();
        }

        DataTable[] SeparateActivities(DataTable table)
        {
            var datarow = table.Select();
            var historyTable = CreateDataTable();

            foreach (var row in datarow)
            {
                var date = row["Data"].ToString();
                var myDate = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                if (myDate<DateTime.Now)
                {
                    historyTable.Rows.Add(row.ItemArray);
                    row.Delete();
                    
                }
            }

            DataTable[] tables = new[] { table,historyTable};
            return tables;
        }

        DataTable CreateDataTable()
        {
            var dt = new DataTable();
            dt.Clear(); 
            dt.Columns.Add("id",typeof(int));
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Atividade");
            dt.Columns.Add("Localização");
            dt.Columns.Add("Data");

            return dt;
        }

        void panel2_Paint(object sender, PaintEventArgs e) { }

        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}