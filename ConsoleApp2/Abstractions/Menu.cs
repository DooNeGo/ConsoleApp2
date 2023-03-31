abstract class Menu
{
    protected Dictionary<int, Menu>? childrens;
    private readonly string? menuItem;
    protected abstract void UpdateChildrens();
    protected abstract bool HasErrors();

    public Menu(string? menuItem)
    {
        this.menuItem = menuItem;
    }

    protected virtual void ShowChildrens()
    {
        Console.WriteLine($"-----{MenuItem}-----");
        for (int i = 1; i <= childrens?.Count; i++)
        {
            Console.WriteLine($"{i} - {childrens[i].MenuItem}");
        }
        Console.WriteLine("0 - Return");
    }

    public virtual void Process()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            UpdateChildrens();
            if (childrens!.Count == 1)
                childrens[1].Process();
            if (HasErrors())
                return;
            Console.Clear();
            ShowChildrens();
            var value = consoleReader.ReadInt();
            if (value > 0 && value <= childrens!.Count)
                childrens[(int)value].Process();
            else if (value == 0)
                break;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }

    public string? MenuItem
    {
        get { return menuItem; }
    }
}