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
            // V�rifie que l'utilisateur a cliqu� sur une ligne valide (pas sur l'en-t�te)
            if (e.RowIndex >= 0)
            {
                // R�cup�rer la ligne s�lectionn�e
                var selectedRow = dataGridViewTask.Rows[e.RowIndex];

                // R�cup�rer les donn�es de la ligne s�lectionn�e
                int taskId = Convert.ToInt32(selectedRow.Cells[0].Value); // Colonne Id
                string title = selectedRow.Cells[1].Value.ToString(); // Colonne Title
                string description = selectedRow.Cells[2].Value.ToString(); // Colonne Description
                bool isCompleted = Convert.ToBoolean(selectedRow.Cells[3].Value); // Colonne IsCompleted

                // Mettre � jour la t�che s�lectionn�e dans le ViewModel
                taskViewModel.SelectedTask = new Model.Task
                {
                    Id = taskId,
                    Title = title,
                    Description = description,
                    IsCompleted = isCompleted
                };

                // Optionnel : Afficher les donn�es dans les champs du formulaire
                txtTitle.Text = title;
                txtDescription.Text = description;
                chkTermine.Checked = isCompleted;
            }
        }

        private void RefreshDataGridView()
        {
            // Effacer les lignes existantes
            dataGridViewTask.Rows.Clear();

            // Ajouter les t�ches actuelles du ViewModel
            foreach (var task in taskViewModel.Tasks)
            {
                dataGridViewTask.Rows.Add(task.Id, task.Title, task.Description, task.IsCompleted);
            }
        }


        private void Btn_Add_Click(object sender, EventArgs e)
        {

            // V�rifier si le titre ou la description est vide
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Le titre et la description ne peuvent pas �tre vides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Arr�ter l'ex�cution si les champs sont vides
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
                1-  Lorsque la ligne du tableau des taches est selectionn�e
                    Afficher les informations dans le formulaire.
                2-  Si une donn�e du formulaire change et que l'utilisateur clique sur le bouton
                    Modifier ou modifiera l'�l�ment.
             */
            if (taskViewModel.SelectedTask == null)
            {
                MessageBox.Show("Veuillez s�lectionner une t�che que vous souhaitez modifier .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // R�cup�rer l'ID de la t�che s�lectionn�e
            int selectedTaskId = taskViewModel.SelectedTask.Id;
            var task = taskViewModel.GetTaskById(selectedTaskId);
            task.Title = txtTitle.Text; // Nouvelle valeur du champ "Titre"
            task.Description = txtDescription.Text; // Nouvelle valeur du champ "Description"
            task.IsCompleted = chkTermine.Checked; // Nouvelle valeur de l'�tat "Termin�"
            // Appeler DeleteTask avec l'ID
            try
            {
                taskViewModel.UpdateTask(task);
                MessageBox.Show("T�che modifi�e avec succ�s.", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                1-  Lorsque la ligne du tableau des taches est selectionn�e
                    Afficher les informations dans le formulaire.
                2-  On supprime l'�l�ment selectionn�.
             */

            // V�rifier si une t�che est s�lectionn�e 
            if (taskViewModel.SelectedTask == null)
            {
                MessageBox.Show("Veuillez s�lectionner une t�che que vous souhaitez supprimer .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // R�cup�rer l'ID de la t�che s�lectionn�e
            int selectedTaskId = taskViewModel.SelectedTask.Id;

            // Appeler DeleteTask avec l'ID
            try
            {
                taskViewModel.DeleteTask(selectedTaskId);
                MessageBox.Show("T�che supprim�e avec succ�s.", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);
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