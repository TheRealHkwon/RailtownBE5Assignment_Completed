using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RailtownBE5Assignment.Models;
using RailtownBE5Assignment.Services;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RailtownBE5Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            char mode = ' ';

            Console.WriteLine("Welcome to the distance calculator. Would you like to run on command or in intervals?");
            Console.WriteLine("Enter 'o' for once");
            Console.WriteLine("Enter 'l' for intervals of 5 minutes");


            while (mode != 'o' && mode != 'l')
            {
                mode = Console.ReadKey().KeyChar;

                Console.WriteLine();

                if (mode != 'o' && mode != 'l')
                {
                    Console.WriteLine("Please enter 'o' or 'l'");
                }
            }
            
            if (mode == 'l')
            {
                while (true)
                {
                    await CalculateResults();
                    Thread.Sleep(1000 * 60 * 5);
                }
            }
            else
            {
                await CalculateResults();
            }    

        }

        static async Task CalculateResults()
        {
            ServiceProvider provider = ConfigureServices();

            ILocationServiceAdapter locationAdapter = provider.GetService<ILocationServiceAdapter>();
            IGeoLocationService geoService = provider.GetService<IGeoLocationService>();

            IUser[] users = await locationAdapter.GetUsers("https://jsonplaceholder.typicode.com/users");

            GeoLocationResult result = geoService.GetFarthestUsers(users);

            Console.WriteLine($"Farthest distance is: {result.Distance} km");

            Console.WriteLine();
            result.UserOne.PrintUser();

            Console.WriteLine();
            result.UserTwo.PrintUser();

            PrintResultsToDisk(result);
        }

        static void PrintResultsToDisk(GeoLocationResult result)
        {
            string json = JsonConvert.SerializeObject(result);

            //Defaults to: ..\repos\RailtownBE5Assignment\RailtownBE5Assignment\RailtownBE5Assignment\bin\Debug
            File.AppendAllText($"{Directory.GetCurrentDirectory()}/output.json", json);
        }

        static ServiceProvider ConfigureServices()
        {
            ServiceProvider serviceProvider = new ServiceCollection()

                .AddSingleton<ILocationServiceAdapter, LocationServiceAdapter>()
                .AddSingleton<IGeoLocationService, GeoLocationService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
