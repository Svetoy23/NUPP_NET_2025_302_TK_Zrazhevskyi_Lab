using Library.Common;

var book = new Book("1984", 1949, "George Orwell");
var magazine = new Magazine("Time", 2024, 15);
var reader = new Reader("Anna Kovalenko", 2022);
var librarian = new Librarian("Mr. Volkov");

librarian.OnItemIssued += message => Console.WriteLine($"[Log] {message}");

var itemService = new InMemoryCrudService<Item>(item => item.Id);
itemService.Create(book);
itemService.Create(magazine);

book.PrintUpperTitle();
reader.ShowInfo();
librarian.IssueItem(book, reader);

Console.WriteLine("\n--- Library Items ---");
foreach (var item in itemService.ReadAll())
{
    item.Display();
}

Console.WriteLine($"\nTotal items created: {LibraryStats.ItemsCreated}");