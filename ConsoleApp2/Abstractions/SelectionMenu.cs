abstract class SelectionMenu<T> : Menu
{
    protected List<T>? items;

    protected SelectionMenu(List<T>? items, string? menuItem) : base(menuItem)
    {
        this.items = items;
    }

    protected override bool HasErrors()
    {
        if (items is null)
            return true;
        return false;
    }

    protected override void ShowChildrens()
    {
        var consoleWriter = new ConsoleWriter();
        Console.WriteLine($"-----{MenuItem}-----");
        if (items is null || childrens?.Count < 1)
        {
            Console.WriteLine("Empty...");
            Console.WriteLine("0 - Return");
            return;
        }
        for (int i = 0; i < items.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            consoleWriter.WriteListItem(items[i]);
        }
        Console.Write("Enter number (0 - Return): ");
    }
}