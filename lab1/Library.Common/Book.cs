namespace Library.Common;

public class Book : Item
{
    public string Author { get; set; }

    public Book(string title, int year, string author)
        : base(title, year)
    {
        Author = author;
    }

    public override void Display()
    {
        Console.WriteLine($"Book: {Title} by {Author} ({Year})");
    }
}