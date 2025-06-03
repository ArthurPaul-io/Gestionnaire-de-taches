using EasyTask.Model;
using EasyTask.Model.Repository;
using System.Collections.Generic;

namespace EasyTask.ViewModel
{
    internal class ClientViewModel
    {
        private ClientRepository clientRepository;
        public List<Client> Clients { get; set; }
        public Client? SelectedClient { get; set; }

        public ClientViewModel()
        {
            clientRepository = new ClientRepository();
            Clients = clientRepository.GetAllClients();
        }

        public void AddClient(Client client)
        {
            clientRepository.AddClient(client);
            Clients = clientRepository.GetAllClients();
        }

        public void UpdateClient(Client client)
        {
            clientRepository.UpdateClient(client);
            Clients = clientRepository.GetAllClients();
        }

        public void DeleteClient(int id)
        {
            clientRepository.DeleteClient(id);
            Clients = clientRepository.GetAllClients();
        }

        public Client? GetClientById(int id)
        {
            return Clients.Find(c => c.Id == id);
        }
    }
}