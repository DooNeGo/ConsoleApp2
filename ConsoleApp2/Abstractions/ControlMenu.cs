abstract class ControlMenu<T> : Menu
{
    private readonly int? index;
    protected static List<T>? items;
    private static int? listCount;

    protected ControlMenu(List<T>? items, int? index, string? menuItem) : base(menuItem)
    {
        ControlMenu<T>.items = items;
        this.index = index;
        ControlMenu<T>.listCount = items?.Count;
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
            Console.Clear();
            if (IsListCountChanged() is true)
                return;
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
