using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMongoDbCacheRepository _cache;
        private List<Client> AllClients = new List<Client>();
        public ClientService(IClientRepository clientRepository, IMongoDbCacheRepository cache)
        {
            _clientRepository = clientRepository;
            _cache = cache;
        }

        public async Task<List<Client>> GetAllClientsFromDb()
        {
            var clnList = await _cache.GetClientList();

            if (clnList != null)
            {
                return clnList;
            }

            clnList = await _clientRepository.GetAllClientsFromDb();
            await _cache.InsertClientList(clnList);
            return clnList;
        }

        public async Task<Client> GetClientById(int id)
        {
            var cln = await _cache.GetClientById(id);

            if (cln != null)
            {
                return cln;
            }

            cln = await _clientRepository.GetClientById(id);
            await _cache.InsertClient(cln);
            return cln;
        }

        public async Task InsertClient(Client client)
        {
            await _clientRepository.InsertClient(client);
        }

        public async Task UpdateClient(Client client)
        {
            await _clientRepository.UpdateClient(client);
        }

        public async Task DeleteClient(int id)
        {
            await _clientRepository.DeleteClient(id);
        }

        //File System
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

        public List<Client> GetAllClientsFromFile()
        {
            if (AllClients.Count == 0)
                AllClients = _clientRepository.ReadClients();
            return AllClients;
        }
    }
}