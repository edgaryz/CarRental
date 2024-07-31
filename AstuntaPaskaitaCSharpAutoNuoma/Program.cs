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
            Console.WriteLine("1. GetAllElectricCars");
            Console.WriteLine("2. GetAllOilFuelCars");
            Console.WriteLine("3. InsertNewCar");
            Console.WriteLine("4. GetAllClientsFromDb");
            Console.WriteLine("5. InsertNewClient");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List<ElectricCar> ev = carRentService.GetAllElectricCars();
                    foreach (ElectricCar e in ev)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                case "2":
                    List<OilFuelCar> ofc = carRentService.GetAllOilFuelCars();
                    foreach (OilFuelCar v in ofc)
                    {
                        Console.WriteLine(v);
                    }
                    break;
                case "3":
                    Car newCar = new Car();
                    string batteryCapacity = "";
                    int batteryChargingTime = 0;
                    string fuelConsumption = "";
                    Console.WriteLine("Electric Car - 1  Oil Fuel Car - 2: ");
                    string type = Console.ReadLine();
                    switch(type)
                    {
                        case "1":
                            Console.WriteLine("Enter battery capacity");
                            batteryCapacity = Console.ReadLine();
                            Console.WriteLine("Enter battery charging time");
                            batteryChargingTime = int.Parse(Console.ReadLine());
                            break;
                        case "2":
                            Console.WriteLine("Enter fuel consumption");
                            fuelConsumption = Console.ReadLine();
                            break;
                    }
                    Console.WriteLine("Enter car brand");
                    string brand = Console.ReadLine();
                    Console.WriteLine("Enter car model");
                    string model = Console.ReadLine();
                    Console.WriteLine("Enter car rent price");
                    decimal rentPrice = decimal.Parse(Console.ReadLine());
                    switch(type)
                    {
                        case "1":
                            newCar = new ElectricCar(brand, model, rentPrice, batteryCapacity, batteryChargingTime);
                            break;
                        case "2":
                            newCar = new OilFuelCar(brand, model, rentPrice, fuelConsumption);
                            break;
                    }
                    carRentService.AddNewCar(newCar);
                    break;
                case "4":
                    List<Client> clients = carRentService.GetAllClientsFromDb();
                    foreach (Client cl in clients)
                    {
                        Console.WriteLine(cl);
                    }
                    break;
                case "5":
                    Client newClient = new Client();
                    Console.WriteLine("Enter first name");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter last name");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter year of birth");
                    DateTime yearOfBirth = DateTime.Parse(Console.ReadLine());
                    newClient = new Client(firstName, lastName, yearOfBirth);
                    carRentService.InsertClient(newClient);
                    break;
            }
            }
    }
    public static ICarRentService SetupDependencies()
    {
        //IClientRepository clientRepository = new ClientsFileRepository("clients.csv");
        IClientRepository clientRepository = new ClientsDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;");
        //ICarsRepository carsRepository = new CarsFileRepository("cars.csv");
        ICarsRepository carsRepository = new CarsDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;");
        IClientService clientService = new ClientService(clientRepository);
        ICarsService carService = new CarsService(carsRepository);
        return new CarRentService(clientService, carService);
    }
}