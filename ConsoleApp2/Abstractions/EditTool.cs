abstract class EditTool<T> : Menu
{
    protected readonly ApplicationContext<T> context;

    public EditTool(string name, ApplicationContext<T> context) : base(name)
    {
        this.context = context;
    }

    public override void Process()
    {
        var consoleWriter = new ConsoleWriter();
        Console.Clear();
        if (EditField() is true)
            consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
    }

    protected abstract bool EditField();
}