namespace ConnectMe
{
    partial class Form_ManageCategories
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxCategoryName = new System.Windows.Forms.TextBox();
            this.buttonCreateCategory = new System.Windows.Forms.Button();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(714, 506);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Criar Categoria";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxCategoryName
            // 
            this.textBoxCategoryName.Location = new System.Drawing.Point(109, 207);
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.Size = new System.Drawing.Size(269, 22);
            this.textBoxCategoryName.TabIndex = 2;
            // 
            // buttonCreateCategory
            // 
            this.buttonCreateCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(214)))));
            this.buttonCreateCategory.FlatAppearance.BorderSize = 0;
            this.buttonCreateCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateCategory.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateCategory.ForeColor = System.Drawing.Color.White;
            this.buttonCreateCategory.Location = new System.Drawing.Point(422, 195);
            this.buttonCreateCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateCategory.Name = "buttonCreateCategory";
            this.buttonCreateCategory.Size = new System.Drawing.Size(179, 39);
            this.buttonCreateCategory.TabIndex = 6;
            this.buttonCreateCategory.Text = "Criar";
            this.buttonCreateCategory.UseVisualStyleBackColor = false;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(109, 298);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(269, 24);
            this.comboBoxCategories.TabIndex = 8;
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(214)))));
            this.buttonDeleteCategory.FlatAppearance.BorderSize = 0;
            this.buttonDeleteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteCategory.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteCategory.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteCategory.Location = new System.Drawing.Point(422, 286);
            this.buttonDeleteCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(179, 39);
            this.buttonDeleteCategory.TabIndex = 9;
            this.buttonDeleteCategory.Text = "Eliminar";
            this.buttonDeleteCategory.UseVisualStyleBackColor = false;
            // 
            // Form_CreateCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 506);
            this.Controls.Add(this.buttonDeleteCategory);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.buttonCreateCategory);
            this.Controls.Add(this.textBoxCategoryName);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form_CreateCategory";
            this.Text = "Form_CreateCategory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.Button buttonCreateCategory;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Button buttonDeleteCategory;
    }
}