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
    public partial class Form_ActivityProfile : Form
    {
        public Form_ActivityProfile()
        {
            
            InitializeComponent();
            
        }
       
        private void ActivityProfile_form_Load(object sender, EventArgs e)
        {
            
            int activity_id = ActivityManager.getCurrentActivity().Id;
            Activity activity = ActivityManager.createActivityId(activity_id);

            fillUsersTable(ActivityManager.getCurrentActivity(), AccountsManager.getLoggedUser());


            activity_name.Text = activity.Name;
            category.Text = activity.Category.Name;
            date.Text=activity.Date.ToString("dd/MM/yyyy HH:mm");
            
            description.Text = activity.Description;
            localization.Text = activity.Location;
            labelActivityCreator.Text = "Criador da atividade\n"+activity.User.Email;

            
            description.MaximumSize = new Size(400, 0);
            description.AutoSize = true;
            
            

            if (AccountsManager.getLoggedUser() is Admin)
            {
                buttonParticipate.Visible = false;
            }

            else if (activity.User.Id != AccountsManager.getLoggedUser().Id)
            {
                buttonDelete.Visible = false;
                buttonEdit.Visible = false;
            }


            
        }

        private void fillUsersTable(Activity activity,User user)
        {
            
            string statement = "SELECT user.id,user.name as Participantes FROM `user_has_activity`,`user`,`activity` WHERE user_has_activity.User_id=user.id AND activity.id = user_has_activity.Activity_id AND activity.id = @0";
            Object[] values = { activity.Id};
            DataTable table = DB.ExecuteSQL(statement, values);

            dataGridView1.DataSource = table;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["Participantes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ActivityManager.NumberOfParticipants=table.Rows.Count;
            

            nr_people.Text = ActivityManager.NumberOfParticipants + "/" + activity.MaxPeople.ToString();

            DataRow[] datarow = table.Select();

            //If user logged participate on current activity
            bool participate=false;
            foreach (DataRow row in datarow)
            {
                if (user.Id==(int)row["id"])
                {
                    participate = true;
                }
            }
            if (participate)
            {
                buttonParticipate.Text = "Não Participar";
            }
            else
            {
                buttonParticipate.Text = "Participar";
            }
            
        }

        private void activity_name_Click(object sender, EventArgs e)
        {

        }

        private void buttonParticipate_Click(object sender, EventArgs e)
        {
            if (buttonParticipate.Text.Equals("Participar"))    //Participate on activity
            {
                if (ActivityManager.NumberOfParticipants<ActivityManager.getCurrentActivity().MaxPeople)
                {
                    string statement = "INSERT INTO `user_has_activity` (`User_id`, `Activity_id`) VALUES (@0, @1)";
                    Object[] values = { AccountsManager.getLoggedUser().Id, ActivityManager.getCurrentActivity().Id };
                    DB.ExecuteSQL(statement, values);
                    fillUsersTable(ActivityManager.getCurrentActivity(), AccountsManager.getLoggedUser());
                }
                else
                {
                    MessageBox.Show("A atividade está cheia!");
                }
            }
            else    //Remove participation
            {
                string statement = "DELETE FROM `user_has_activity` WHERE `user_has_activity`.`User_id` = @0 AND `user_has_activity`.`Activity_id` = @1";
                Object[] values = { AccountsManager.getLoggedUser().Id, ActivityManager.getCurrentActivity().Id };
                DB.ExecuteSQL(statement, values);
                fillUsersTable(ActivityManager.getCurrentActivity(), AccountsManager.getLoggedUser());

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            

            var confirmResult =  MessageBox.Show("Tem a certeza que quer eliminar esta atividade?",
                                     "Atividade removida!",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                Object[] values = { ActivityManager.getCurrentActivity().Id };

                string statement = "DELETE FROM `user_has_activity` WHERE `user_has_activity`.`Activity_id` = @0";
                DB.ExecuteSQL(statement, values);

                statement = "DELETE FROM `activity` WHERE `activity`.`id` = @0";
                DB.ExecuteSQL(statement, values);

                FormManager.goBack();
            }
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormManager.goBack();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormManager.openEditActivityForm();
        }
    }
}
