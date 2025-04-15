namespace Library.Common;

public static class LibraryStats
{
    public static int ItemsCreated;

    static LibraryStats()
    {
        ItemsCreated = 0;
    }

    public static void IncrementItemCount()
    {
        ItemsCreated++;
    }
}