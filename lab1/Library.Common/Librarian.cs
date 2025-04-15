namespace Library.Common;

public class Librarian
{
    public Guid Id { get; set; }
    public string FullName { get; set; }

    public delegate void Notification(string message);
    public event Notification? OnItemIssued;

    public Librarian(string fullName)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
    }

    public void IssueItem(Item item, Reader reader)
    {
        OnItemIssued?.Invoke($"{FullName} issued '{item.Title}' to {reader.Name}");
    }
}