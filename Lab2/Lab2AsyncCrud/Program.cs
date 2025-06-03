using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var service = new ThreadSafeCrudService<Bus>(b => b.Id, "buses.json");
        var buses = new ConcurrentBag<Bus>();

        Parallel.For(0, 1000, _ =>
        {
            buses.Add(Bus.CreateNew());
        });

        await Parallel.ForEachAsync(buses, async (bus, _) =>
        {
            await service.CreateAsync(bus);
        });

        var all = await service.ReadAllAsync();

        Console.WriteLine($"Min Capacity: {all.Min(b => b.Capacity)}");
        Console.WriteLine($"Max Capacity: {all.Max(b => b.Capacity)}");
        Console.WriteLine($"Average Capacity: {all.Average(b => b.Capacity)}");

        await service.SaveAsync();
        Console.WriteLine("Data saved to buses.json");
    }
}