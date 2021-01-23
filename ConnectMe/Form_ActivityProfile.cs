using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectMe
{
    public partial class FormActivityProfile : Form
    {
        public FormActivityProfile()
        {
            InitializeComponent();
        }

        void ActivityProfile_form_Load(object sender, EventArgs e)
        {
            var activityId = ActivityManager.GetCurrentActivity().Id;
            var activity = ActivityManager.CreateActivityId(activityId);

            FillUsersTable(ActivityManager.GetCurrentActivity(), AccountsManager.GetLoggedUser());

            activity_name.Text = activity.Name;
            category.Text = activity.Category.Name;
            date.Text = activity.Date.ToString("dd/MM/yyyy HH:mm");

            description.Text = activity.Description;
            localization.Text = activity.Location;
            labelActivityCreator.Text = "Criador da atividade\n" + activity.User.Email;

            description.MaximumSize = new Size(400, 0);
            description.AutoSize = true;

            if (AccountsManager.GetLoggedUser() is Admin) buttonParticipate.Visible = false;

            else if (activity.User.Id != AccountsManager.GetLoggedUser().Id)
            {
                buttonDelete.Visible = false;
                buttonEdit.Visible = false;
            }
        }

        void FillUsersTable(Activity activity, User user)
        {
            var statement =
                "SELECT user.id,user.name as Participantes FROM `user_has_activity`,`user`,`activity` WHERE user_has_activity.User_id=user.id AND activity.id = user_has_activity.Activity_id AND activity.id = @0";
            object[] values = {activity.Id};
            var table = Db.ExecuteSql(statement, values);

            dataGridView1.DataSource = table;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["Participantes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ActivityManager.NumberOfParticipants = table.Rows.Count;

            nr_people.Text = ActivityManager.NumberOfParticipants + "/" + activity.MaxPeople;

            var datarow = table.Select();

            //If user logged participate on current activity
            var participate = false;
            foreach (var row in datarow)
            {
                if (user.Id == (int) row["id"]) participate = true;
            }

            buttonParticipate.Text = participate ? "Não Participar" : "Participar";
            // same as:
            //  if (participate) buttonParticipate.Text = "Não Participar";
            //  else buttonParticipate.Text = "Participar";
        }

        void activity_name_Click(object sender, EventArgs e) { }

        void buttonParticipate_Click(object sender, EventArgs e)
        {
            if (buttonParticipate.Text.Equals("Participar")) //Participate on activity
            {
                if (ActivityManager.NumberOfParticipants < ActivityManager.GetCurrentActivity().MaxPeople)
                {
                    const string statement =
                        "INSERT INTO `user_has_activity` (`User_id`, `Activity_id`) VALUES (@0, @1)";
                    object[] values =
                    {
                        AccountsManager.GetLoggedUser().Id,
                        ActivityManager.GetCurrentActivity().Id
                    };
                    Db.ExecuteSql(statement, values);
                    FillUsersTable(ActivityManager.GetCurrentActivity(), AccountsManager.GetLoggedUser());
                }
                else MessageBox.Show("A atividade está cheia!");
            }
            else //Remove participation
            {
                const string statement =
                    "DELETE FROM `user_has_activity` WHERE `user_has_activity`.`User_id` = @0 AND `user_has_activity`.`Activity_id` = @1";
                object[] values =
                {
                    AccountsManager.GetLoggedUser().Id,
                    ActivityManager.GetCurrentActivity().Id
                };
                Db.ExecuteSql(statement, values);
                FillUsersTable(ActivityManager.GetCurrentActivity(), AccountsManager.GetLoggedUser());
            }
        }

        void buttonDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem a certeza que quer eliminar esta atividade?",
                "Atividade removida!",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                object[] values = {ActivityManager.GetCurrentActivity().Id};

                var statement =
                    "DELETE FROM `user_has_activity` WHERE `user_has_activity`.`Activity_id` = @0";
                Db.ExecuteSql(statement, values);

                statement = "DELETE FROM `activity` WHERE `activity`.`id` = @0";
                Db.ExecuteSql(statement, values);

                FormManager.GoBack();
            }
        }

        void pictureBox1_Click(object sender, EventArgs e)
        {
            FormManager.GoBack();
        }

        void buttonEdit_Click(object sender, EventArgs e)
        {
            FormManager.OpenEditActivityForm();
        }
    }
}