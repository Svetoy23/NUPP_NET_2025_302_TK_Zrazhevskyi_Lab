namespace Library.Common;

public class Reader
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int RegisteredYear { get; set; }

    public Reader(string name, int registeredYear)
    {
        Id = Guid.NewGuid();
        Name = name;
        RegisteredYear = registeredYear;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Reader: {Name}, Since {RegisteredYear}");
    }
}