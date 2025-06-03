using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFTaskModel = EasyTask.Model;

namespace EasyTask.Model.Repository
{
    internal class TaskRepository
    {
        private string connectionString = "Data Source=tasks.db;Version=3;";

        public List<KFTaskModel.Task> GetAllTasks()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Tasks", connection);
                List<KFTaskModel.Task> tasks = new List<KFTaskModel.Task>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KFTaskModel.Task aTask = new KFTaskModel.Task();
                        aTask.Id = Convert.ToInt32(reader["Id"]);
                        aTask.Title = reader["Title"].ToString();
                        aTask.Description = reader["Description"].ToString();
                        aTask.IsCompleted = false; Convert.ToBoolean(reader["IsCompleted"]);
                        tasks.Add(aTask);
                    }
                }

                return tasks;
            }
        }

        public KFTaskModel.Task GetTaskById(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Tasks WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Task
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            IsCompleted = Convert.ToBoolean(reader["IsCompleted"])
                        };
                    }
                }

                return null;
            }
        }

        public void AddTask(Task task)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                int nb = 0;
                if(task.IsCompleted == true) {
                    nb = 1;
                }
                var command = new SQLiteCommand("INSERT INTO Tasks (Id, Title, Description, IsCompleted) VALUES (NULL, @Title, @Description, @IsCompleted)", connection);
                command.Parameters.AddWithValue("@Title", task.Title);
                command.Parameters.AddWithValue("@Description", task.Description);
                command.Parameters.Add("@IsCompleted", DbType.Int32);
                command.Parameters["@IsCompleted"].Value = nb ;
                command.ExecuteNonQuery();
            }
        }

        public void UpdateTask(Task task)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                int nb = 0;
                if (task.IsCompleted == true)
                {
                    nb = 1;
                }
                var command = new SQLiteCommand("UPDATE Tasks SET Title = @Title, Description = @Description, IsCompleted = @IsCompleted WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Title", task.Title);
                command.Parameters.AddWithValue("@Description", task.Description);
                command.Parameters.Add("@IsCompleted", DbType.Int32);
                command.Parameters["@IsCompleted"].Value = nb;
                command.Parameters.AddWithValue("@Id", task.Id);
                Console.WriteLine($"Updating Task: Id={task.Id}, Title={task.Title}, Description={task.Description}, IsCompleted={task.IsCompleted}");

                command.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                    connection.Open();
                    var command = new SQLiteCommand("DELETE FROM Tasks WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

