using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IClientRepository
    {
        List<Client> ReadClients();
        void WriteClient(Client client);
        void WriteClients(List<Client> clientList);
    }
}
