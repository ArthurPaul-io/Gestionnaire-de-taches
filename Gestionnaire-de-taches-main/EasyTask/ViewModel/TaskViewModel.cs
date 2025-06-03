using EasyTask.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRepository = EasyTask.Model.Repository;
using KFTaskModel = EasyTask.Model;
using EasyTask.Model;

namespace EasyTask.ViewModel
{
    internal class TaskViewModel
    {
        private TRepository.TaskRepository taskRepository;

        public List<KFTaskModel.Task> Tasks { get; set; }
        public KFTaskModel.Task? SelectedTask { get; set; }

        public TaskViewModel()
        {
            taskRepository = new TRepository.TaskRepository();
            Tasks = taskRepository.GetAllTasks();
        }

        public Model.Task GetTaskById(int id)
{
            // Récupère directement la tâche depuis le repository
            return taskRepository.GetTaskById(id);
        }


        public void AddTask()
        {
            taskRepository.AddTask(SelectedTask);
            Tasks = taskRepository.GetAllTasks();
            SelectedTask = null;
        }

        public void UpdateTask(KFTaskModel.Task task)
        {
            taskRepository.UpdateTask(task);
            Tasks = taskRepository.GetAllTasks();
            SelectedTask = null;
        }

        public void DeleteTask(int TaskId)
        {
            SelectedTask = taskRepository.GetTaskById(TaskId);
            taskRepository.DeleteTask(TaskId);
            Tasks = taskRepository.GetAllTasks();
            SelectedTask = null;
        }
    }
}
