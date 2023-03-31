abstract class ControlMenu<T> : Menu
{
    private readonly int? index;
    public static List<T>? items;
    public static int? listCount;

    protected ControlMenu(int? index, string? menuItem) : base(menuItem)
    {
        this.index = index;
    }

    public int? Index
    {
        get { return index; }
    }

    protected override bool HasErrors()
    {
        if (items is null || index is null)
            return true;
        if (items.Count != listCount)
            return true;
        return false;
    }

    protected override void ShowChildrens()
    {
        var consoleWriter = new ConsoleWriter();
        Console.WriteLine($"-----{MenuItem}-----");
        consoleWriter.WriteListItem(items![(int)Index!]);
        for (int i = 1; i <= childrens!.Count; i++)
        {
            Console.WriteLine($"{i} - {childrens[i].MenuItem}");
        }
        Console.WriteLine("0 - Return");
    }
}