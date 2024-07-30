using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Repositories
{
    public class ClientsFileRepository : IClientRepository
    {
        List<Client> IClientRepository.ReadClients()
        {
            throw new NotImplementedException();
        }

        void IClientRepository.WriteClient(Client client)
        {
            throw new NotImplementedException();
        }

        void IClientRepository.WriteClients(List<Client> clientList)
        {
            throw new NotImplementedException();
        }
    }
}
