abstract class EditTool<T> : Menu
{
    protected int? index;
    protected List<T>? items;

    public EditTool(int? index, List<T>? items, string? menuItem) : base(menuItem)
    {
        this.items = items;
        this.index = index;
    }

    public override void Process()
    {
        if (HasErrors())
            return;
        var consoleWriter = new ConsoleWriter();
        Console.Clear();
        if (EditField() is true)
            consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
    }

    protected abstract bool EditField();

    protected override bool HasErrors()
    {
        if (items is null || index is null)
            return true;
        return false;
    }

    protected override void UpdateChildrens()
    {
        throw new NotImplementedException();
    }

    protected int? Index
    {
        get { return index; }
    }
}