using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private List<Client> AllClients = new List<Client>();
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public void AddClient(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClientsFromFile()
        {
            if (AllClients.Count == 0)
                AllClients = _clientRepository.ReadClients();
            return AllClients;
        }

        public void ReadFile()
        {
            throw new NotImplementedException();
        }

        public void WriteFile()
        {
            throw new NotImplementedException();
        }

        public Client FindClientByFirstNameAndLastName(string firstName, string lastName)
        {
            Client client = new Client();
            foreach (Client k in AllClients)
            {
                if (k.FirstName == firstName && k.LastName == lastName)
                {
                    client = k;
                    break;
                }
            }
            return client;
        }

        public void InsertClient(Client client)
        {
            _clientRepository.InsertClient(client);
        }

        public List<Client> GetAllClientsFromDb()
        {
            return _clientRepository.GetAllClientsFromDb();
        }
    }
}