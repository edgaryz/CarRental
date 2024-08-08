using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsFromDb();
        Task<Client> GetClientById(int id);
        Task InsertClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
        List<Client> GetAllClientsFromFile();
        Client FindClientByFirstNameAndLastName(string firstName, string lastName);
    }
}
