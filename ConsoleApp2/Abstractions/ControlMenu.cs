abstract class ControlMenu<T> : Menu
{
    private readonly int? index;
    public static List<T>? items;
    public static int? listCount;

    protected ControlMenu(int? index, string? menuItem) : base(menuItem)
    {
        this.index = index;
    }

    public int? Index
    {
        get { return index; }
    }

    private bool IsListCountChanged()
    {
        if (items?.Count != listCount)
            return true;
        return false;
    }

    public override void Process()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            if (IsListCountChanged() is true)
                return;
            Console.Clear();
            Console.WriteLine($"-----{MenuItem}-----");
            UpdateChildrens();
            ShowMenuItems();
            var value = consoleReader.ReadInt();
            if (value > 0 && value <= childrens!.Count)
                childrens[(int)value].Process();
            else if (value == 0)
                break;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }
}
