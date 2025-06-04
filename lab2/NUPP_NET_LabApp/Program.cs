using NUPP_NET_LabApp.Models;
using NUPP_NET_LabApp.Services;
using NUPP_NET_LabApp.Sync;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NUPP_NET_LabApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var crudService = new InMemoryCrudService<Bus>();

            var tasks = Enumerable.Range(0, 1000).Select(i =>
                Task.Run(async () =>
                {
                    var bus = Bus.CreateNew();
                    await crudService.CreateAsync(bus);
                }));

            await Task.WhenAll(tasks);

            var page = 1;
            var pageSize = 100;
            var buses = await crudService.ReadAllAsync(page, pageSize);

            var capacities = buses.Select(b => ((Bus)(object)b).Capacity).ToList();
            var minCapacity = capacities.Min();
            var maxCapacity = capacities.Max();
            var avgCapacity = capacities.Average();

            Console.WriteLine($"Min Capacity: {minCapacity}");
            Console.WriteLine($"Max Capacity: {maxCapacity}");
            Console.WriteLine($"Avg Capacity: {avgCapacity}");


            await crudService.SaveAsync();
        }
    }
}
