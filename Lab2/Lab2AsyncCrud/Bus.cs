using System;

public class Bus
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public int Capacity { get; set; }

    public static Bus CreateNew()
    {
        var random = new Random();
        return new Bus
        {
            Id = Guid.NewGuid(),
            Model = $"Model-{random.Next(1000)}",
            Capacity = random.Next(10, 100)
        };
    }
}