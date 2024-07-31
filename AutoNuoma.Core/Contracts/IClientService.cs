using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IClientService
    {
        void ReadFile();
        void WriteFile();
        void AddClient(Client client);
        Client FindClientByFirstNameAndLastName(string firstName, string lastName);
        List<Client> GetAllClientsFromFile();
        List<Client> GetAllClientsFromDb();
        void InsertClient(Client client);
    }
}
