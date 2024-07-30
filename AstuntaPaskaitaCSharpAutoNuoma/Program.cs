using CarRental.Core.Contracts;
using CarRental.Core.Models;
using CarRental.Core.Repositories;
using CarRental.Core.Services;

namespace CarRentalConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {


        ICarRentService carRentService = SetupDependencies();
        while (true)
        {
            Console.WriteLine("1. Rodyti visus automobilius");
            Console.WriteLine("2. Rodyti visus klientus");
            Console.WriteLine("3. Formuoti nuomos uzsakyma");
            string pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    List<Car> auto = carRentService.GetAllCars();
                    foreach (Car a in auto)
                    {
                        Console.WriteLine(a);
                    }
                    break;
                case "2":
                    List<Client> client = carRentService.GetAllClients();
                    foreach (Client k in client)
                    {
                        Console.WriteLine(k);
                    }
                    break;
                case "3":
                    Console.WriteLine("Nuomos uzsakymas: ");
                    foreach (Client k in carRentService.GetAllClients())
                    {
                        Console.WriteLine(k);
                    }

                    Console.WriteLine("Iveskite norimo kliento varda");
                    string vardas = Console.ReadLine();
                    Console.WriteLine("Iveskite norimo kliento pavarde");
                    string pavarde = Console.ReadLine();

                    foreach (Car a in carRentService.GetAllCars())
                    {
                        Console.WriteLine(a);
                    }

                    Console.WriteLine("Pasirinkite automobili pagal Id sarase: ");
                    int autoId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Iveskite kiek dienu autommobilis yra isnuomojamas: ");
                    int dienos = int.Parse(Console.ReadLine());

                    carRentService.CreateOrder(vardas, pavarde, autoId, DateTime.Now, dienos);

                    break;
            }

        }
    }
    public static ICarRentService SetupDependencies()
    {
        IClientRepository clientRepository = new ClientsFileRepository("clients.csv");
        ICarsRepository carsRepository = new CarsFileRepository("cars.csv");
        IClientService clientService = new ClientService(clientRepository);
        ICarsService carService = new CarsService(carsRepository);
        return new CarRentService(clientService, carService);
    }
}