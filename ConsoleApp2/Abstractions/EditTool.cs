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
        if (Index is null)
            return;
        var consoleWriter = new ConsoleWriter();
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