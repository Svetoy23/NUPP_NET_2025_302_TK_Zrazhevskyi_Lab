using Microsoft.EntityFrameworkCore;
using Airport.Infrastructure;
using Airport.Infrastructure.Models;

class Program
{
    static async Task Main()
    {
        var options = new DbContextOptionsBuilder<AirportContext>()
            .UseSqlite("Data Source=airport.db")
            .Options;

        using var context = new AirportContext(options);
        await context.Database.MigrateAsync();

        var repository = new EfRepository<FlightModel>(context);

        var flight = new FlightModel
        {
            Destination = "Kyiv",
            DepartureTime = DateTime.Now,
            Airplane = new AirplaneModel { Model = "Boeing 737" }
        };

        await repository.AddAsync(flight);
        await context.SaveChangesAsync();
    }
}