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
    internal class ProjetRepository
    {
        private string connectionString = "Data Source=tasks.db;Version=3;";
        public List<Projet> GetAllProjects()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Projet", connection);
                List<Projet> projects = new List<Projet>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(new Projet
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            titre = reader["titre"].ToString(),
                            description = reader["description"].ToString(),
                            id_client = Convert.ToInt32(reader["id_client"])
                        });
                    }
                }   

                return projects;
            }
        }

        public void AddProject(Projet projet)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Projet (titre, Description, id_client) VALUES (@titre, @Description, @ClientId)", connection);
                command.Parameters.AddWithValue("@titre", projet.titre);
                command.Parameters.AddWithValue("@Description", projet.description);
                command.Parameters.AddWithValue("@ClientId", projet.id_client);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateProject(Projet projet)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Projects SET Name = @Name, Description = @Description, ClientId = @ClientId WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Name", projet.titre);
                command.Parameters.AddWithValue("@Description", projet.description);
                command.Parameters.AddWithValue("@ClientId", projet.id_client);
                command.Parameters.AddWithValue("@Id", projet.Id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProject(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("DELETE FROM Projects WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
