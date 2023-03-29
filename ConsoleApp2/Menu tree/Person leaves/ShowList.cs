internal class ShowList<T> : MainMenu
{
    private readonly List<T>? items;

    public ShowList(List<T>? items, string menuItem = "Show") : base(menuItem)
    {
        this.items = items;
    }

    public override void Process()
    {
        var userActions = new UserActions();
        userActions.ShowList(items!);
        Console.Write("Нажмите <Enter> для выхода... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }
}