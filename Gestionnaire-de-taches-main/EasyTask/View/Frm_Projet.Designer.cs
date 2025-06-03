namespace EasyTask.View
{
    partial class Frm_Projet
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
            textBox1 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            titre = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button3 = new Button();
            Add_click_boutton = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(405, 176);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(198, 164);
            label1.Name = "label1";
            label1.Size = new Size(201, 40);
            label1.TabIndex = 2;
            label1.Text = "Titre du projet";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, titre, description });
            dataGridView1.Location = new Point(255, 328);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(479, 235);
            dataGridView1.TabIndex = 3;
            // 
            // Id
            // 
            Id.HeaderText = "Id projet";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Width = 125;
            // 
            // titre
            // 
            titre.HeaderText = "Titre";
            titre.MinimumWidth = 6;
            titre.Name = "titre";
            titre.Width = 125;
            // 
            // description
            // 
            description.HeaderText = "Description";
            description.MinimumWidth = 6;
            description.Name = "description";
            description.Width = 125;
            // 
            // button2
            // 
            button2.Location = new Point(741, 240);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Supprimer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(741, 275);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "Modifier";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Add_click_boutton
            // 
            Add_click_boutton.Location = new Point(741, 176);
            Add_click_boutton.Name = "Add_click_boutton";
            Add_click_boutton.Size = new Size(94, 29);
            Add_click_boutton.TabIndex = 7;
            Add_click_boutton.Text = "Ajouter";
            Add_click_boutton.UseVisualStyleBackColor = true;
            Add_click_boutton.Click += Add_click_boutton_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(396, 223);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(226, 81);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(305, 223);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 9;
            label2.Text = "Description";
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(146, 29);
            button1.TabIndex = 10;
            button1.Text = "Retour au client";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(431, 570);
            button4.Name = "button4";
            button4.Size = new Size(149, 29);
            button4.TabIndex = 11;
            button4.Text = "Accéder aux tâches";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Frm_Projet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 628);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(Add_click_boutton);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Frm_Projet";
            Text = "Frm_Projet";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn titre;
        private DataGridViewTextBoxColumn description;
        private Button button2;
        private Button button3;
        private Button Add_click_boutton;
        private TextBox textBox2;
        private Label label2;
        private Button button1;
        private Button button4;
    }
}