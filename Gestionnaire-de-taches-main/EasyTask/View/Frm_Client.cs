using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTask.ViewModel;
using EasyTask.Model;

namespace EasyTask.View
{
    public partial class Frm_Client : Form
    {
        private ClientViewModel clientViewModel;

        public Frm_Client()
        {
            InitializeComponent();
            clientViewModel = new ClientViewModel();
            InitializeDataGridView();
            RefreshDataGridView();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void Frm_Client_Load(object sender, EventArgs e)
        {
            // Tu peux initialiser des choses ici si besoin
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Prenom", "Prénom");
            dataGridView1.Columns.Add("Nom", "Nom");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        private void RefreshDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var client in clientViewModel.Clients)
            {
                dataGridView1.Rows.Add(client.Id, client.prénom, client.nom);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                textBox1.Text = row.Cells[1].Value?.ToString();
                textBox2.Text = row.Cells[2].Value?.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e) // Ajouter
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = new Client
            {
                prénom = textBox1.Text,
                nom = textBox2.Text
            };
            clientViewModel.AddClient(client);
            RefreshDataGridView();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e) // Supprimer
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            clientViewModel.DeleteClient(clientId);
            RefreshDataGridView();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e) // Modifier
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            var client = clientViewModel.GetClientById(clientId);
            if (client == null)
            {
                MessageBox.Show("Client introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            client.prénom = textBox1.Text;
            client.nom = textBox2.Text;
            clientViewModel.UpdateClient(client);
            RefreshDataGridView();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_Projet frmProjet = new Frm_Projet();
            frmProjet.Show();
            this.Hide();
        }
    }
}
