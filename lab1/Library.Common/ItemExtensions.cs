namespace Library.Common;

public static class ItemExtensions
{
    public static void PrintUpperTitle(this Item item)
    {
        Console.WriteLine(item.Title.ToUpper());
    }
}