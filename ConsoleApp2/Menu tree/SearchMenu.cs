internal class SearchMenu<T> : Menu
{
    private readonly ApplicationContext<T> context;

    public SearchMenu(string name, ApplicationContext<T> context) : base(name)
    {
        this.context = context;
    }

    public override void Process()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        var dataActions = new DataActions();
        dataActions.Search(context);
        if (context.FoundItems is null)
            return;
        while (true)
        {
            Console.Clear();
            ShowChildren();
            var value = consoleReader.ReadInt();
            if (value > 0 && value <= context.FoundItems!.Count)
            {
                context.CurrentItem = context.FoundItems[(int)value - 1];
                childrens[0].Process();
            }
            else if (value == 0)
            {
                context.FoundItems = null;
                return;
            }
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }

    protected override void ShowChildren()
    {
        var consoleWriter = new ConsoleWriter();
        Console.WriteLine($"----- {Name} -----");
        if (context.FoundItems!.Count == 0)
            Console.WriteLine("Empty...");
        for (int i = 0; i < context.FoundItems!.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            consoleWriter.WriteListItem(context.FoundItems[i]);
        }
        Console.Write("Enter number (0 - Return): ");
    }
}