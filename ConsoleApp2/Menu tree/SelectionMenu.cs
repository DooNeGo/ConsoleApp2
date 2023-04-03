internal class SelectionMenu<T> : Menu
{
    private readonly ApplicationContext<T> context;

    public SelectionMenu(string name, ApplicationContext<T> context) : base(name)
    {
        this.context = context;
    }

    public override void Process()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Clear();
            ShowChildren();
            var value = consoleReader.ReadInt();
            if (value > 0 && value <= context.Items.Count)
            {
                context.CurrentItem = context.Items[(int)value - 1];
                childrens[0].Process();
            }
            else if (value == 0)
                return;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }

    protected override void ShowChildren()
    {
        var consoleWriter = new ConsoleWriter();
        Console.WriteLine($"----- {Name} -----");
        if (context.Items.Count == 0)
            Console.WriteLine("Empty...");
        for (int i = 0; i < context.Items.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            consoleWriter.WriteListItem(context.Items[i]);
        }
        Console.Write("Enter number (0 - Return): ");
    }
}