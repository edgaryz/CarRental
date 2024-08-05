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
            Console.WriteLine("1. Cars Menu");
            Console.WriteLine("2. Clients Menu");
            Console.WriteLine("3. Employees Menu");
            Console.WriteLine("4. Orders Menu");
            Console.WriteLine("0. Exit Program");
            Console.WriteLine("-------------------------");
            string mainMenu = Console.ReadLine();
            switch (mainMenu)
            {
                case "0":
                    //Exit Program
                    return;
                case "1":
                    //Cars Menu
                    Console.WriteLine("1. GetAllElectricCars");
                    Console.WriteLine("2. GetAllOilFuelCars");
                    Console.WriteLine("3. InsertNewCar");
                    Console.WriteLine("4. UpdateCarInfo TODO");
                    Console.WriteLine("5. DeleteCar TODO");
                    Console.WriteLine("0. Main Menu");
                    Console.WriteLine("-------------------------");
                    string choiceCars = Console.ReadLine();
                    switch (choiceCars)
                    {
                        case "0":
                            //Main Menu
                            break;
                        case "1":
                            //GetAllElectricCars
                            List<ElectricCar> ev = carRentService.GetAllElectricCars();
                            foreach (ElectricCar e in ev)
                            {
                                Console.WriteLine(e);
                            }
                            break;
                        case "2":
                            //GetAllOilFuelCars
                            List<OilFuelCar> ofc = carRentService.GetAllOilFuelCars();
                            foreach (OilFuelCar v in ofc)
                            {
                                Console.WriteLine(v);
                            }
                            break;
                        case "3":
                            //InsertNewCar
                            Car newCar = new Car();
                            string batteryCapacity = "";
                            int batteryChargingTime = 0;
                            string fuelConsumption = "";
                            Console.WriteLine("Electric Car - 1  Oil Fuel Car - 2: ");
                            string insertCarType = Console.ReadLine();
                            switch (insertCarType)
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
                            switch (insertCarType)
                            {
                                case "1":
                                    newCar = new ElectricCar(brand, model, rentPrice, batteryCapacity, batteryChargingTime);
                                    break;
                                case "2":
                                    newCar = new OilFuelCar(brand, model, rentPrice, fuelConsumption);
                                    break;
                            }
                            carRentService.AddNewCar(newCar);
                            Console.WriteLine("Car creation successful!");
                            break;
                        case "4":
                            //TODO
                            //UpdateCarInfo

                            break;
                        case "5":
                            //TODO
                            //DeleteCar

                            break;
                    }
                    break;
                case "2":
                    //Clients Menu
                    Console.WriteLine("1. GetAllClientsFromDb");
                    Console.WriteLine("2. GetClientById TODO");
                    Console.WriteLine("3. InsertNewClient");
                    Console.WriteLine("4. UpdateEmployee TODO");
                    Console.WriteLine("5. DeleteEmployee TODO");
                    Console.WriteLine("0. Main Menu");
                    Console.WriteLine("-------------------------");
                    string choiceClients = Console.ReadLine();
                    switch (choiceClients)
                    {
                        case "0":
                            //Main Menu
                            break;
                        case "1":
                            //GetAllClientsFromDb
                            List<Client> clients = carRentService.GetAllClientsFromDb();
                            foreach (Client cl in clients)
                            {
                                Console.WriteLine(cl);
                            }
                            break;
                        case "2":
                            //TODO
                            //GetClientById
                            break;
                        case "3":
                            //InsertNewClient
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
                        case "4":
                            //UpdateEmployee
                            break;
                        case "5":
                            //DeleteEmployee
                            break;
                    }
                    break;
                case "3":
                    //Employees Menu
                    Console.WriteLine("1. GetAllEmployeesFromDb TODO");
                    Console.WriteLine("2. GetEmployeeById TODO");
                    Console.WriteLine("3. InsertNewEmployee TODO");
                    Console.WriteLine("4. UpdateEmployee TODO");
                    Console.WriteLine("5. DeleteEmployee TODO");
                    Console.WriteLine("0. Main Menu TODO");
                    Console.WriteLine("-------------------------");
                    string choiceEmployees = Console.ReadLine();
                    switch (choiceEmployees)
                    {
                        case "0":
                            //Main Menu
                            break;
                        case "1":
                            //TODO
                            //GetAllEmployeesFromDb
                            break;
                        case "2":
                            //TODO
                            //GetEmployeeById
                            break;
                        case "3":
                            //TODO
                            //InsertNewEmployee
                            break;
                        case "4":
                            //TODO
                            //InsertNewEmployee
                            break;
                        case "5":
                            //TODO
                            //InsertNewEmployee
                            break;

                    } break;
                case "4":
                    //Orders Menu
                    Console.WriteLine("1. GetAllOrders");
                    Console.WriteLine("2. GetOrderById TODO");
                    Console.WriteLine("3. InsertNewOrder");
                    Console.WriteLine("4. UpdateOrder TODO");
                    Console.WriteLine("5. DeleteOrder TODO");
                    Console.WriteLine("0. Main Menu");
                    Console.WriteLine("-------------------------");
                    string choiceOrders = Console.ReadLine();
                    switch (choiceOrders)
                    {
                        case "0":
                            //Main Menu
                            break;
                        case "1":
                            //GetAllOrders
                            List<RentOrder> orders = carRentService.GetAllOrders();
                            foreach (RentOrder or in orders)
                            {
                                Console.WriteLine(or);
                            }
                            break;
                        case "2":
                            //TODO
                            //GetOrderById
                            break;
                        case "3":
                            //InsertNewOrder
                            RentOrder newOrder = new RentOrder();
                            Console.WriteLine("Enter Client ID");
                            int newClientId = int.Parse(Console.ReadLine());
                            int electricCarId = 0;
                            int oilFuelCarId = 0;
                            Console.WriteLine("Choose Car Type");
                            Console.WriteLine("Electric Car - 1  Oil Fuel Car - 2: ");
                            string orderCarType = Console.ReadLine();
                            switch (orderCarType)
                            {
                                case "1":
                                    List<ElectricCar> evList = carRentService.GetAllElectricCars();
                                    foreach (ElectricCar e in evList)
                                    {
                                        Console.WriteLine(e);
                                    }
                                    Console.WriteLine("----------------------");
                                    Console.WriteLine("Enter EV ID");
                                    electricCarId = int.Parse(Console.ReadLine());
                                    break;
                                case "2":
                                    List<OilFuelCar> ofcList = carRentService.GetAllOilFuelCars();
                                    foreach (OilFuelCar v in ofcList)
                                    {
                                        Console.WriteLine(v);
                                    }
                                    Console.WriteLine("----------------------");
                                    Console.WriteLine("Enter Oil Fuel Car ID");
                                    oilFuelCarId = int.Parse(Console.ReadLine());
                                    break;
                            }
                            Console.WriteLine("Enter Order Start Date");
                            DateTime OrderStartDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Order Days");
                            int newOrderDays = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter cooperating employee ID");
                            int employeeId = int.Parse(Console.ReadLine());
                            switch (orderCarType)
                            {
                                case "1":
                                    newOrder = new RentOrder(newClientId, electricCarId, OrderStartDate, newOrderDays, employeeId);
                                    carRentService.CreateElectricCarOrder(newOrder);
                                    break;
                                case "2":
                                    newOrder = new RentOrder(newClientId, OrderStartDate, newOrderDays, employeeId, oilFuelCarId);
                                    carRentService.CreateOilFuelCarOrder(newOrder);
                                    break;
                            }
                            Console.WriteLine("Order creation successful!");
                            break;
                        case "4":
                            //TODO
                            //UpdateOrder
                            break;
                        case "5":
                            //TODO
                            //DeleteOrder
                            break;
                    }
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
        IRentOrderRepository rentOrderRepository = new OrdersDbRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;");
        IRentOrderService rentOrderService = new RentOrderService(rentOrderRepository, carsRepository, clientRepository);
        IEmployeeRepository employeeRepository = new EmployeeRepository("Server=localhost;Database=car_rental_db;Trusted_Connection=True;");
        IEmployeeService employeeService = new EmployeeService(employeeRepository);

        return new CarRentService(clientService, carService, rentOrderService, employeeService);
    }
}

