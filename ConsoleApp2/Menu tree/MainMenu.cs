internal class MainMenu : Menu<MainMenu>
{
    protected List<Person>? people;
    protected List<User>? users;

    public MainMenu(List<Person>? people = null, List<User>? users = null, string menuItem = "Main menu")
    {
        this.menuItem = menuItem;
        this.people = people;
        this.users = users;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, MainMenu>()
        {
            { 1, new UserMainMenu(users) },
            { 2, new PersonMainMenu(people) },
        };
    }

    public override void Process()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
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

    protected override void ShowMenuItems()
    {
        for (int i = 1; i <= childrens!.Count; i++)
        {
            Console.WriteLine($"{i} - {childrens[i].MenuItem}");
        }
        Console.WriteLine("0 - Return");
    }

    public string? MenuItem
    {
        get { return menuItem; }
    }
}