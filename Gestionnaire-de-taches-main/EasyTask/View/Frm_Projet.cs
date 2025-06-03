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

namespace EasyTask.View
{
    public partial class Frm_Projet : Form
    {
        private ProjetViewModel projetViewModel;

        public Frm_Projet()
        {
            InitializeComponent();
            projetViewModel = new ProjetViewModel();
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var projet in projetViewModel.Projets)
            {
                dataGridView1.Rows.Add(projet.Id, projet.titre, projet.description);
            }
        }

        private void Add_click_boutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Le titre du projet ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var projet = new Model.Projet
            {
                titre = textBox1.Text,
                description = textBox2.Text // Utilisation de textBox2 pour la description
            };
            projetViewModel.SelectedProjet = projet;
            projetViewModel.AddProjet();
            RefreshDataGridView();
        }

        private void button2_Click(object sender, EventArgs e) // Supprimer
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un projet à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int projetId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            projetViewModel.DeleteProjet(projetId);
            RefreshDataGridView(); // Rafraîchir APRÈS la suppression
        }

        private void button3_Click(object sender, EventArgs e) // Modifier
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un projet à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int projetId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            var projet = projetViewModel.GetProjetById(projetId);
            if (projet == null)
            {
                MessageBox.Show("Projet introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            projet.titre = textBox1.Text;
            projet.description = textBox2.Text; // Utilisation de textBox2 pour la description

            projetViewModel.UpdateProjet(projet);
            RefreshDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Client frmClient = new Frm_Client();
            frmClient.Show();
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("Ligne sélectionnée : " + dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Aucune ligne sélectionnée !");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_Task frmTask = new Frm_Task();
            frmTask.Show();
            this.Hide();
        }
    }
}
