internal class ShowPeopleList : MainMenu
{
    public ShowPeopleList(List<Person>? people, string menuItem = "Show") : base(people, menuItem: menuItem)
    { }

    public override void Process()
    {
        var userActions = new UserActions();
        userActions.ShowList(people!);
        Console.Write("Нажмите <Enter> для выхода... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }
}
