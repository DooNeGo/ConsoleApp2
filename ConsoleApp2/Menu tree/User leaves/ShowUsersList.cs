internal class ShowUsersList : MainMenu
{
    public ShowUsersList(List<User> users, string menuItem = "Show") : base(menuItem: menuItem, users:users)
    { }

    public override void Process()
    {
        var userActions = new UserActions();
        userActions.ShowList(users!);
        Console.Write("Нажмите <Enter> для выхода... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }
}