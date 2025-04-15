namespace Library.Common;

public class Magazine : Item
{
    public int IssueNumber { get; set; }

    public Magazine(string title, int year, int issue)
        : base(title, year)
    {
        IssueNumber = issue;
    }

    public override void Display()
    {
        Console.WriteLine($"Magazine: {Title} - Issue {IssueNumber} ({Year})");
    }
}