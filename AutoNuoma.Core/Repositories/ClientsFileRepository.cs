using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Repositories
{
    public class ClientsFileRepository : IClientRepository
    {
        public readonly string _filePath;
        public ClientsFileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Client> ReadClients()
        {
            List<Client> clients = new List<Client>();
            using (StreamReader sr = new StreamReader(_filePath))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    clients.Add(new Client(
                        values[0],
                        values[1],
                        DateTime.Parse(values[2])));
                }
            }
            return clients;
        }

        public Task UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void WriteClients(List<Client> clientList)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                foreach (Client client in clientList)
                {
                    sw.WriteLine($"" +
                        $"{client.FirstName}," +
                        $"{client.LastName}," +
                        $"{client.YearOfBirth},");
                }
            }
        }

        public Task DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> GetAllClientsFromDb()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
