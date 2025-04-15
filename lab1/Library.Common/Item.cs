namespace Library.Common;

public class Item
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }

    public Item(string title, int year)
    {
        Id = Guid.NewGuid();
        Title = title;
        Year = year;
    }

    public virtual void Display()
    {
        Console.WriteLine($"{Title} ({Year})");
    }
}