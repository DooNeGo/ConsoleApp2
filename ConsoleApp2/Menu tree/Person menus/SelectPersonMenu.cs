internal class SelectPersonMenu : MainMenu
{

    public SelectPersonMenu(List<Person> people, string menuItem = "Select person") : base(people, menuItem: menuItem)
    { }


    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, MainMenu>();
        for (int i = 0; i < people!.Count; i++)
        {
            childrens[i + 1] = new PersonControlMenu(people[i], people);
        }
    }


    protected override void ShowMenuItems()
    {
        var consoleWriter = new ConsoleWriter();
        if (childrens?.Count < 1)
        {
            Console.WriteLine("Empty...");
            Console.WriteLine("0 - Return");
            return;
        }
        for (int i = 1; i <= childrens?.Count; i++)
        {
            Console.Write($"{i}. ");
            PersonControlMenu? personMenu = childrens[i] as PersonControlMenu;
            consoleWriter.WriteListItem(personMenu?.Person);
        }
        Console.Write("Enter number (0 - Return): ");
    }
}
