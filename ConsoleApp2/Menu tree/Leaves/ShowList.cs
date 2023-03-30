internal class ShowList<T> : SelectionMenu<T>
{
    public ShowList(List<T>? items, string menuItem = "Show") : base(items, menuItem)
    { }

    public override void Process()
    {
        if (HasErrors())
            return;
        var userActions = new UserActions();
        userActions.ShowList(items);
        Console.Write("Нажмите <Enter> для выхода... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }

    protected override void UpdateChildrens()
    {
        throw new NotImplementedException();
    }
}