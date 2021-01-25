namespace ConnectMe
{
    partial class Form_MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.buttonActivitiesHistory = new System.Windows.Forms.Button();
            this.buttonManageCategories = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonCreateActivities = new System.Windows.Forms.Button();
            this.panelSubMenu = new System.Windows.Forms.Panel();
            this.buttonCreatedActivities = new System.Windows.Forms.Button();
            this.buttonPariticipatingActivities = new System.Windows.Forms.Button();
            this.buttonAllActivities = new System.Windows.Forms.Button();
            this.buttonActivitiesShowSubMenu = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelSubMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.Black;
            this.panelSideMenu.Controls.Add(this.buttonActivitiesHistory);
            this.panelSideMenu.Controls.Add(this.buttonManageCategories);
            this.panelSideMenu.Controls.Add(this.buttonLogout);
            this.panelSideMenu.Controls.Add(this.buttonCreateActivities);
            this.panelSideMenu.Controls.Add(this.panelSubMenu);
            this.panelSideMenu.Controls.Add(this.buttonActivitiesShowSubMenu);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 553);
            this.panelSideMenu.TabIndex = 0;
            // 
            // buttonActivitiesHistory
            // 
            this.buttonActivitiesHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActivitiesHistory.FlatAppearance.BorderSize = 0;
            this.buttonActivitiesHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActivitiesHistory.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonActivitiesHistory.Location = new System.Drawing.Point(0, 355);
            this.buttonActivitiesHistory.Name = "buttonActivitiesHistory";
            this.buttonActivitiesHistory.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonActivitiesHistory.Size = new System.Drawing.Size(250, 45);
            this.buttonActivitiesHistory.TabIndex = 8;
            this.buttonActivitiesHistory.Text = "Histórico de Atividades";
            this.buttonActivitiesHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonActivitiesHistory.UseVisualStyleBackColor = true;
            this.buttonActivitiesHistory.Click += new System.EventHandler(this.buttonActivitiesHistory_Click);
            // 
            // buttonManageCategories
            // 
            this.buttonManageCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManageCategories.FlatAppearance.BorderSize = 0;
            this.buttonManageCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageCategories.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonManageCategories.Location = new System.Drawing.Point(0, 310);
            this.buttonManageCategories.Name = "buttonManageCategories";
            this.buttonManageCategories.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonManageCategories.Size = new System.Drawing.Size(250, 45);
            this.buttonManageCategories.TabIndex = 7;
            this.buttonManageCategories.Text = "Gerir Categorias";
            this.buttonManageCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonManageCategories.UseVisualStyleBackColor = true;
            this.buttonManageCategories.Click += new System.EventHandler(this.buttonManageCategories_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonLogout.Location = new System.Drawing.Point(0, 508);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonLogout.Size = new System.Drawing.Size(250, 45);
            this.buttonLogout.TabIndex = 6;
            this.buttonLogout.Text = "Terminar Sessão";
            this.buttonLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonCreateActivities
            // 
            this.buttonCreateActivities.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreateActivities.FlatAppearance.BorderSize = 0;
            this.buttonCreateActivities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateActivities.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonCreateActivities.Location = new System.Drawing.Point(0, 265);
            this.buttonCreateActivities.Name = "buttonCreateActivities";
            this.buttonCreateActivities.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCreateActivities.Size = new System.Drawing.Size(250, 45);
            this.buttonCreateActivities.TabIndex = 5;
            this.buttonCreateActivities.Text = "Criar Atividade";
            this.buttonCreateActivities.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCreateActivities.UseVisualStyleBackColor = true;
            this.buttonCreateActivities.Click += new System.EventHandler(this.buttonCreateActivities_Click);
            // 
            // panelSubMenu
            // 
            this.panelSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelSubMenu.Controls.Add(this.buttonCreatedActivities);
            this.panelSubMenu.Controls.Add(this.buttonPariticipatingActivities);
            this.panelSubMenu.Controls.Add(this.buttonAllActivities);
            this.panelSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenu.Location = new System.Drawing.Point(0, 145);
            this.panelSubMenu.Name = "panelSubMenu";
            this.panelSubMenu.Size = new System.Drawing.Size(250, 120);
            this.panelSubMenu.TabIndex = 2;
            // 
            // buttonCreatedActivities
            // 
            this.buttonCreatedActivities.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreatedActivities.FlatAppearance.BorderSize = 0;
            this.buttonCreatedActivities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreatedActivities.ForeColor = System.Drawing.Color.LightGray;
            this.buttonCreatedActivities.Location = new System.Drawing.Point(0, 80);
            this.buttonCreatedActivities.Name = "buttonCreatedActivities";
            this.buttonCreatedActivities.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonCreatedActivities.Size = new System.Drawing.Size(250, 40);
            this.buttonCreatedActivities.TabIndex = 2;
            this.buttonCreatedActivities.Text = "Atividades Criadas";
            this.buttonCreatedActivities.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCreatedActivities.UseVisualStyleBackColor = true;
            this.buttonCreatedActivities.Click += new System.EventHandler(this.buttonCreatedActivities_Click);
            // 
            // buttonPariticipatingActivities
            // 
            this.buttonPariticipatingActivities.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPariticipatingActivities.FlatAppearance.BorderSize = 0;
            this.buttonPariticipatingActivities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPariticipatingActivities.ForeColor = System.Drawing.Color.LightGray;
            this.buttonPariticipatingActivities.Location = new System.Drawing.Point(0, 40);
            this.buttonPariticipatingActivities.Name = "buttonPariticipatingActivities";
            this.buttonPariticipatingActivities.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonPariticipatingActivities.Size = new System.Drawing.Size(250, 40);
            this.buttonPariticipatingActivities.TabIndex = 1;
            this.buttonPariticipatingActivities.Text = "Atividades Inscritas";
            this.buttonPariticipatingActivities.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPariticipatingActivities.UseVisualStyleBackColor = true;
            this.buttonPariticipatingActivities.Click += new System.EventHandler(this.buttonPariticipatingActivities_Click);
            // 
            // buttonAllActivities
            // 
            this.buttonAllActivities.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAllActivities.FlatAppearance.BorderSize = 0;
            this.buttonAllActivities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAllActivities.ForeColor = System.Drawing.Color.LightGray;
            this.buttonAllActivities.Location = new System.Drawing.Point(0, 0);
            this.buttonAllActivities.Name = "buttonAllActivities";
            this.buttonAllActivities.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonAllActivities.Size = new System.Drawing.Size(250, 40);
            this.buttonAllActivities.TabIndex = 0;
            this.buttonAllActivities.Text = "Todas as Atividades";
            this.buttonAllActivities.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAllActivities.UseVisualStyleBackColor = true;
            this.buttonAllActivities.Click += new System.EventHandler(this.buttonAllActivities_Click);
            // 
            // buttonActivitiesShowSubMenu
            // 
            this.buttonActivitiesShowSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActivitiesShowSubMenu.FlatAppearance.BorderSize = 0;
            this.buttonActivitiesShowSubMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActivitiesShowSubMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonActivitiesShowSubMenu.Location = new System.Drawing.Point(0, 100);
            this.buttonActivitiesShowSubMenu.Name = "buttonActivitiesShowSubMenu";
            this.buttonActivitiesShowSubMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonActivitiesShowSubMenu.Size = new System.Drawing.Size(250, 45);
            this.buttonActivitiesShowSubMenu.TabIndex = 1;
            this.buttonActivitiesShowSubMenu.Text = "Atividades";
            this.buttonActivitiesShowSubMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonActivitiesShowSubMenu.UseVisualStyleBackColor = true;
            this.buttonActivitiesShowSubMenu.Click += new System.EventHandler(this.buttonActivitiesShowSubMenu_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConnectMe.Properties.Resources.mike_mockupsjpg;
            this.pictureBox1.Location = new System.Drawing.Point(23, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.White;
            this.panelChildForm.Controls.Add(this.pictureBox2);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(732, 553);
            this.panelChildForm.TabIndex = 1;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildForm_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::ConnectMe.Properties.Resources.mike_mockupsjpg;
            this.pictureBox2.Location = new System.Drawing.Point(200, 176);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(350, 154);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // Form_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Form_MainMenu";
            this.Text = "Connect Me";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelSubMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button buttonActivitiesShowSubMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelSubMenu;
        private System.Windows.Forms.Button buttonCreatedActivities;
        private System.Windows.Forms.Button buttonPariticipatingActivities;
        private System.Windows.Forms.Button buttonAllActivities;
        private System.Windows.Forms.Button buttonCreateActivities;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonManageCategories;
        private System.Windows.Forms.Button buttonActivitiesHistory;
    }
}