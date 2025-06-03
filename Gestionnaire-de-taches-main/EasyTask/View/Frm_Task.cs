using EasyTask.View;
using EasyTask.ViewModel;
using VMTask = EasyTask.ViewModel;

namespace EasyTask
{
    public partial class Frm_Task : Form
    {
        private VMTask.TaskViewModel taskViewModel;
        private Model.Task Task;
        public Frm_Task()
        {
            InitializeComponent();
            taskViewModel = new TaskViewModel();
            //    dataGridViewTask.DataSource = taskViewModel.Tasks;
            foreach (var task in taskViewModel.Tasks)
            {
                dataGridViewTask.Rows.Add(task.Id, task.Title, task.Description, task.IsCompleted);
            }

            dataGridViewTask.CellClick += DataGridViewTask_CellClick;

        }

        private void DataGridViewTask_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifie que l'utilisateur a cliqué sur une ligne valide (pas sur l'en-tête)
            if (e.RowIndex >= 0)
            {
                // Récupérer la ligne sélectionnée
                var selectedRow = dataGridViewTask.Rows[e.RowIndex];

                // Récupérer les données de la ligne sélectionnée
                int taskId = Convert.ToInt32(selectedRow.Cells[0].Value); // Colonne Id
                string title = selectedRow.Cells[1].Value.ToString(); // Colonne Title
                string description = selectedRow.Cells[2].Value.ToString(); // Colonne Description
                bool isCompleted = Convert.ToBoolean(selectedRow.Cells[3].Value); // Colonne IsCompleted

                // Mettre à jour la tâche sélectionnée dans le ViewModel
                taskViewModel.SelectedTask = new Model.Task
                {
                    Id = taskId,
                    Title = title,
                    Description = description,
                    IsCompleted = isCompleted
                };

                // Optionnel : Afficher les données dans les champs du formulaire
                txtTitle.Text = title;
                txtDescription.Text = description;
                chkTermine.Checked = isCompleted;
            }
        }

        private void RefreshDataGridView()
        {
            // Effacer les lignes existantes
            dataGridViewTask.Rows.Clear();

            // Ajouter les tâches actuelles du ViewModel
            foreach (var task in taskViewModel.Tasks)
            {
                dataGridViewTask.Rows.Add(task.Id, task.Title, task.Description, task.IsCompleted);
            }
        }


        private void Btn_Add_Click(object sender, EventArgs e)
        {

            // Vérifier si le titre ou la description est vide
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Le titre et la description ne peuvent pas être vides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Arrêter l'exécution si les champs sont vides
            }
            var task = new Model.Task();
            task.Title = txtTitle.Text;
            task.Description = txtDescription.Text;
            task.IsCompleted = chkTermine.Checked;
            taskViewModel.SelectedTask = task;
            taskViewModel.AddTask();

            RefreshDataGridView();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            /* Todo 
                1-  Lorsque la ligne du tableau des taches est selectionnée
                    Afficher les informations dans le formulaire.
                2-  Si une donnée du formulaire change et que l'utilisateur clique sur le bouton
                    Modifier ou modifiera l'élément.
             */
            if (taskViewModel.SelectedTask == null)
            {
                MessageBox.Show("Veuillez sélectionner une tâche que vous souhaitez modifier .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupérer l'ID de la tâche sélectionnée
            int selectedTaskId = taskViewModel.SelectedTask.Id;
            var task = taskViewModel.GetTaskById(selectedTaskId);
            task.Title = txtTitle.Text; // Nouvelle valeur du champ "Titre"
            task.Description = txtDescription.Text; // Nouvelle valeur du champ "Description"
            task.IsCompleted = chkTermine.Checked; // Nouvelle valeur de l'état "Terminé"
            // Appeler DeleteTask avec l'ID
            try
            {
                taskViewModel.UpdateTask(task);
                MessageBox.Show("Tâche modifiée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la suppression : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshDataGridView();
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            /* Todo 
                1-  Lorsque la ligne du tableau des taches est selectionnée
                    Afficher les informations dans le formulaire.
                2-  On supprime l'élément selectionné.
             */

            // Vérifier si une tâche est sélectionnée 
            if (taskViewModel.SelectedTask == null)
            {
                MessageBox.Show("Veuillez sélectionner une tâche que vous souhaitez supprimer .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupérer l'ID de la tâche sélectionnée
            int selectedTaskId = taskViewModel.SelectedTask.Id;

            // Appeler DeleteTask avec l'ID
            try
            {
                taskViewModel.DeleteTask(selectedTaskId);
                MessageBox.Show("Tâche supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la suppression : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshDataGridView();
        }

        private void Frm_Task_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Projet frmProjet = new Frm_Projet();
            frmProjet.Show();
            this.Hide();
        }
    }
}