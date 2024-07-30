using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRentalConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {


        ICarRentService autonuomaService = SetupDependencies();
        while (true)
        {
            Console.WriteLine("1. Rodyti visus automobilius");
            string pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    List<Car> auto = autonuomaService.GetAllCars();
                    foreach (Car a in auto)
                    {
                        Console.WriteLine(a);
                    }
                    break;
            }


        }
    }
    public static ICarRentService SetupDependencies()
    {
        IKlientaiRepository klientaiRepository = new KlientaiFileRepository();
        IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiFileRepository("cars.csv");
        IKlientaiService klientaiService = new KlientaiService(klientaiRepository);
        IAutomobiliaiService automobiliaiService = new AutomobiliaiService(automobiliaiRepository);
        return new AutonuomosService(klientaiService, automobiliaiService);
    }
}