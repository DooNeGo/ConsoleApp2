abstract class EditTool<T> : Menu
{
    protected int? index;
    protected List<T>? list;

    public EditTool(int? index, List<T>? list, string? menuItem) : base(menuItem)
    {
        this.list = list;
        this.index = index;
    }

    public override void Process()
    {
        var consoleWriter = new ConsoleWriter();
        if (Index is null)
            return;
        Console.Clear();
        if (EditField() is true)
            consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
    }

    protected abstract bool EditField();

    protected int? Index
    {
        get { return index; }
    }
}