internal class MenuLeaf<T> : Menu
{
    private readonly ApplicationContext<T> context;
    private readonly Action<ApplicationContext<T>, ConsoleWriter, ConsoleReader> action;
    public MenuLeaf(string name, ApplicationContext<T> context, Action<ApplicationContext<T>, ConsoleWriter, ConsoleReader> action) : base(name)
    {
        this.context = context;
        this.action = action;
    }

    public override void Process()
    {
        Console.Clear();
        var consoleWriter = new ConsoleWriter();
        var consoleReader = new ConsoleReader();
        action(context, consoleWriter, consoleReader);
    }
}