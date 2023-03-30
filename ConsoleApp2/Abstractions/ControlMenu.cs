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
}