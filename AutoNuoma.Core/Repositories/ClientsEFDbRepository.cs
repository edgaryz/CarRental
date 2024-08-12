using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Core.Repositories
{
    public class ClientsEFDbRepository : IClientRepository
    {
        public async Task<List<Client>> GetAllClientsFromDb()
        {
            using (var context = new MyDbContext())
            {
                List<Client> allClients = await context.Clients.ToListAsync();
                return allClients;
            }
        }

        public async Task<Client> GetClientById(int id)
        {
            using (var context = new MyDbContext())
            {
                return await context.Clients.FindAsync(id);
            }
        }

        public async Task InsertClient(Client client)
        {
            using (var context = new MyDbContext())
            {
                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateClient(Client client)
        {
            using (var context = new MyDbContext())
            {
                await context.Clients
                    .Where(x => x.Id == client.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.FirstName, client.FirstName)
                        .SetProperty(y => y.LastName, client.LastName)
                        .SetProperty(y => y.YearOfBirth, client.YearOfBirth));
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteClient(int id)
        {
            using (var context = new MyDbContext())
            {
                context.Clients.Remove(await context.Clients.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> GetClientCountFromDb()
        {
            using (var context = new MyDbContext())
            {
                var allClientsCount = await context.Clients.CountAsync();
                return allClientsCount;
            }
        }

        //File System
        public List<Client> ReadClients()
        {
            throw new NotImplementedException();
        }

        public void WriteClients(List<Client> clientList)
        {
            throw new NotImplementedException();
        }
    }
}
