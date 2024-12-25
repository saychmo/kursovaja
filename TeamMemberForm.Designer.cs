﻿namespace kurs
{
    partial class TeamMemberForm
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
            dataGridViewTeamMembers = new DataGridView();
            textBoxTeamName = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            LastName = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            EndDate = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeamMembers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTeamMembers
            // 
            dataGridViewTeamMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTeamMembers.Columns.AddRange(new DataGridViewColumn[] { LastName, StartDate, EndDate });
            dataGridViewTeamMembers.Location = new Point(12, 12);
            dataGridViewTeamMembers.Name = "dataGridViewTeamMembers";
            dataGridViewTeamMembers.RowHeadersWidth = 51;
            dataGridViewTeamMembers.RowTemplate.Height = 29;
            dataGridViewTeamMembers.Size = new Size(475, 319);
            dataGridViewTeamMembers.TabIndex = 0;
            // 
            // textBoxTeamName
            // 
            textBoxTeamName.Location = new Point(199, 354);
            textBoxTeamName.Name = "textBoxTeamName";
            textBoxTeamName.Size = new Size(217, 27);
            textBoxTeamName.TabIndex = 1;
            // 
            // label1
            // 
            label1.Location = new Point(12, 354);
            label1.Name = "label1";
            label1.Size = new Size(181, 87);
            label1.TabIndex = 2;
            label1.Text = "Название коллектива(*должно совпадать с названием проекта)";
            // 
            // btnSave
            // 
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(209, 443);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // LastName
            // 
            LastName.HeaderText = "Фамилия сотрудника";
            LastName.MinimumWidth = 6;
            LastName.Name = "LastName";
            LastName.Width = 125;
            // 
            // StartDate
            // 
            StartDate.HeaderText = "Дата начала участия";
            StartDate.MinimumWidth = 6;
            StartDate.Name = "StartDate";
            StartDate.Width = 125;
            // 
            // EndDate
            // 
            EndDate.HeaderText = "Дата окончания участия";
            EndDate.MinimumWidth = 6;
            EndDate.Name = "EndDate";
            EndDate.Width = 125;
            // 
            // TeamMemberForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 496);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(textBoxTeamName);
            Controls.Add(dataGridViewTeamMembers);
            Name = "TeamMemberForm";
            Text = "TeamMemberForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeamMembers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTeamMembers;
        private TextBox textBoxTeamName;
        private Label label1;
        private Button btnSave;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn EndDate;
    }
}