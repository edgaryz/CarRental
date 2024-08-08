using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClientsFromDb();
        Task InsertClient(Client client);
        Task<Client> GetClientById(int id);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
        List<Client> ReadClients();
        void WriteClients(List<Client> clientList);
    }
}
