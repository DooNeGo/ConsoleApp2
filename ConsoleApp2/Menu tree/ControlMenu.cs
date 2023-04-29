internal class ControlMenu<T> : Menu
{
    private readonly ApplicationContext<T> context;

    public ControlMenu(string name, ApplicationContext<T> context) : base(name)
    {
        this.context = context;
    }

    public override void Process()
    {
        var listCount = context.Items.Count;
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            if (listCount != context.Items.Count)
                return;
            Console.Clear();
            ShowChildren();
            var value = consoleReader.ReadInt();
            if (value > 0 && value <= children.Value.Count)
                children.Value[(int)value - 1].Process();
            else if (value == 0)
                return;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }

    protected override void ShowChildren()
    {
        Console.WriteLine($"----- {Name} -----");
        Console.WriteLine(context.CurrentItem);
        for (int i = 0; i < children.Value.Count; i++)
            Console.WriteLine($"{i + 1} - {children.Value[i].Name}");
        Console.WriteLine("0 - Return");
    }
}