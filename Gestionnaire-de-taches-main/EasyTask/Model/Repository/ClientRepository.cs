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
    internal class ClientRepository
    {
        private string connectionString = "Data Source=tasks.db;Version=3;";

        public List<Client> GetAllClients()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Client", connection);
                List<Client> clients = new List<Client>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            prénom = reader["prénom"].ToString(),
                            nom = reader["nom"].ToString()
                        });
                    }
                }

                return clients;
            }
        }

        public void AddClient(Client client)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Client (prénom, nom) VALUES (@prenom, @nom)", connection);
                command.Parameters.AddWithValue("@prenom", client.prénom);
                command.Parameters.AddWithValue("@nom", client.nom);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateClient(Client client)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Client SET prénom = @prenom, nom = @nom WHERE id = @id", connection);
                command.Parameters.AddWithValue("@prenom", client.prénom);
                command.Parameters.AddWithValue("@nom", client.nom);
                command.Parameters.AddWithValue("@id", client.Id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteClient(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("DELETE FROM Client WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}