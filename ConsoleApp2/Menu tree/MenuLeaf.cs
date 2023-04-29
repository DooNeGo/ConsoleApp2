internal class MenuLeaf<T> : Menu
{
    private readonly ApplicationContext<T> context;
    private readonly Action<ApplicationContext<T>, ConsoleWriter, ConsoleReader, ConsoleDialog> action;
    public MenuLeaf(string name, ApplicationContext<T> context, Action<ApplicationContext<T>, ConsoleWriter, ConsoleReader, ConsoleDialog> action) : base(name)
    {
        this.context = context;
        this.action = action;
    }

    public override void Process()
    {
        var consoleWriter = new ConsoleWriter();
        var consoleReader = new ConsoleReader();
        var consoleDialog = new ConsoleDialog();
        action(context, consoleWriter, consoleReader, consoleDialog);
    }
}