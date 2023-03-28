internal class MainMenu : Menu
{
    private protected string menuItem;
    protected Dictionary<int, MainMenu> childrens;

    public MainMenu(string menuItem = "Something...")
    {
        this.menuItem = menuItem;
    }

    private protected override void MakeChildrens()
    {
        childrens = new Dictionary<int, MainMenu>()
        {
            { 1, new UserMainMenu("User") },
            { 2, new PersonMainMenu("Person") },
        };
    }

    public override void Process(List<User> users, List<Person> people)
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        MakeChildrens();
        while (true)
        {
            Console.Clear();
            for (int i = 1; i <= childrens?.Count; i++)
            {
                Console.WriteLine($"{i} - {childrens[i].MenuItem}");
            }
            Console.WriteLine("0 - Return");
            var value = consoleReader.ReadInt();
            if (value > 0 && value <= childrens?.Count)
                childrens?[(int)value].Process(users, people);
            else if (value == 0)
                break;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }

    public string MenuItem
    {
        get { return menuItem; }
    }
}

