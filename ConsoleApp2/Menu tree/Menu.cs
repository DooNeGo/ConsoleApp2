internal class Menu
{
    protected readonly Lazy<List<Menu>> children = new();
    public string Name { get; init; }

    public Menu(string name)
    {
        Name = name;
    }

    public Menu Add(Menu child)
    {
        children.Value.Add(child);
        return child;
    }

    protected virtual void ShowChildren()
    {
        Console.WriteLine($"----- {Name} -----");
        for (int i = 0; i < children.Value.Count; i++)
            Console.WriteLine($"{i + 1} - {children.Value[i].Name}");
        Console.WriteLine("0 - Return");
    }

    public virtual void Process()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
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
}