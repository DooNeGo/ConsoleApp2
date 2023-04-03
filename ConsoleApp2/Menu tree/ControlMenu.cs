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
            if (value > 0 && value <= childrens.Count)
                childrens[(int)value - 1].Process();
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
        consoleWriter.WriteListItem(context.CurrentItem);
        for (int i = 0; i < childrens.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {childrens[i].Name}");
        }
        Console.WriteLine("0 - Return");
    }
}