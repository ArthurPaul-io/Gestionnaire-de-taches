namespace EasyTask
{
    partial class Frm_Task
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewTask = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            IsCompleted = new DataGridViewCheckBoxColumn();
            Btn_Add = new Button();
            Btn_Update = new Button();
            Btn_Del = new Button();
            txtTitle = new TextBox();
            txtDescription = new RichTextBox();
            chkTermine = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTask).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTask
            // 
            dataGridViewTask.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTask.Columns.AddRange(new DataGridViewColumn[] { Id, Title, Description, IsCompleted });
            dataGridViewTask.Location = new Point(95, 344);
            dataGridViewTask.Margin = new Padding(3, 4, 3, 4);
            dataGridViewTask.Name = "dataGridViewTask";
            dataGridViewTask.RowHeadersWidth = 51;
            dataGridViewTask.RowTemplate.Height = 25;
            dataGridViewTask.Size = new Size(510, 432);
            dataGridViewTask.TabIndex = 3;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 125;
            // 
            // Title
            // 
            Title.HeaderText = "Titre";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.Width = 125;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            Description.Width = 125;
            // 
            // IsCompleted
            // 
            IsCompleted.HeaderText = "Terminé";
            IsCompleted.MinimumWidth = 6;
            IsCompleted.Name = "IsCompleted";
            IsCompleted.Width = 125;
            // 
            // Btn_Add
            // 
            Btn_Add.Location = new Point(534, 19);
            Btn_Add.Margin = new Padding(3, 4, 3, 4);
            Btn_Add.Name = "Btn_Add";
            Btn_Add.Size = new Size(86, 31);
            Btn_Add.TabIndex = 0;
            Btn_Add.Text = "&Ajouter";
            Btn_Add.UseVisualStyleBackColor = true;
            Btn_Add.Click += Btn_Add_Click;
            // 
            // Btn_Update
            // 
            Btn_Update.Location = new Point(534, 57);
            Btn_Update.Margin = new Padding(3, 4, 3, 4);
            Btn_Update.Name = "Btn_Update";
            Btn_Update.Size = new Size(86, 31);
            Btn_Update.TabIndex = 1;
            Btn_Update.Text = "Modifier";
            Btn_Update.UseVisualStyleBackColor = true;
            Btn_Update.Click += Btn_Update_Click;
            // 
            // Btn_Del
            // 
            Btn_Del.Location = new Point(534, 96);
            Btn_Del.Margin = new Padding(3, 4, 3, 4);
            Btn_Del.Name = "Btn_Del";
            Btn_Del.Size = new Size(86, 31);
            Btn_Del.TabIndex = 2;
            Btn_Del.Text = "Supprimer";
            Btn_Del.UseVisualStyleBackColor = true;
            Btn_Del.Click += Btn_Del_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(235, 22);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(249, 27);
            txtTitle.TabIndex = 4;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(193, 80);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(313, 193);
            txtDescription.TabIndex = 6;
            txtDescription.Text = "";
            // 
            // chkTermine
            // 
            chkTermine.AutoSize = true;
            chkTermine.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            chkTermine.Location = new Point(311, 283);
            chkTermine.Margin = new Padding(3, 4, 3, 4);
            chkTermine.Name = "chkTermine";
            chkTermine.Size = new Size(132, 41);
            chkTermine.TabIndex = 7;
            chkTermine.Text = "Terminé";
            chkTermine.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(167, 20);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 8;
            label1.Text = "Titre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(43, 80);
            label2.Name = "label2";
            label2.Size = new Size(135, 32);
            label2.TabIndex = 9;
            label2.Text = "Description";
            // 
            // button1
            // 
            button1.Location = new Point(12, 20);
            button1.Name = "button1";
            button1.Size = new Size(149, 29);
            button1.TabIndex = 10;
            button1.Text = "Retour aux projets";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 11;
            // 
            // Frm_Task
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 792);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chkTermine);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Controls.Add(dataGridViewTask);
            Controls.Add(Btn_Del);
            Controls.Add(Btn_Update);
            Controls.Add(Btn_Add);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Frm_Task";
            Text = "Form1";
            Load += Frm_Task_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTask).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Add;
        private Button Btn_Update;
        private Button Btn_Del;
        private DataGridView dataGridViewTask;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewCheckBoxColumn IsCompleted;
        private TextBox txtTitle;
        private RichTextBox txtDescription;
        private CheckBox chkTermine;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
    }
}