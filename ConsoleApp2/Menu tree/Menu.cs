internal class Menu
{
    protected readonly List<Menu> childrens = new();
    public string Name { get; private set; }

    public Menu(string name)
    {
        Name = name;
    }

    public Menu Add(Menu child)
    {
        childrens.Add(child);
        return child;
    }

    protected virtual void ShowChildren()
    {
        Console.WriteLine($"----- {Name} -----");
        for (int i = 0; i < childrens.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {childrens[i].Name}");
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
            if (value > 0 && value <= childrens.Count)
                childrens[(int)value - 1].Process();
            else if (value == 0)
                return;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }
}