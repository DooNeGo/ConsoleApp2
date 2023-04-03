internal class RemoveListItem<T> : Menu
{
    private readonly ApplicationContext<T> context;

    public RemoveListItem(string name, ApplicationContext<T> context) : base(name)
    {
        this.context = context;
    }

    public override void Process()
    {
        var consoleWriter = new ConsoleWriter();
        ApplicationContext<User>? userContext = context as ApplicationContext<User>;
        if (userContext is null || userContext.CurrentUser != userContext.CurrentItem)
        {
            context.Items.Remove(context.CurrentItem!);
            context.FoundItems?.Remove(context.CurrentItem!);
            consoleWriter.WriteMessage("Successful delete", ConsoleColor.Green);
        }
        else if (userContext?.CurrentUser == userContext?.CurrentItem)
        {
            consoleWriter.WriteMessage("You can not delete the active user", ConsoleColor.Red); 
        }
    }
}
