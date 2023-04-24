internal class Menu
{
    protected readonly List<Menu> children = new();
    public string Name { get; init; }

    public Menu(string name)
    {
        Name = name;
    }

    public Menu Add(Menu child)
    {
        children.Add(child);
        return child;
    }

    protected virtual void ShowChildren()
    {
        Console.WriteLine($"----- {Name} -----");
        for (int i = 0; i < children.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {children[i].Name}");
        }
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
            if (value > 0 && value <= children.Count)
                children[(int)value - 1].Process();
            else if (value == 0)
                return;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }
}