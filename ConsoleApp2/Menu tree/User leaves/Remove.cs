internal class Remove<T> : ControlMenu<T>
{
    public Remove(List<T>? items, int? index, string menuItem = "Remove") : base(items, index, menuItem)
    { }

    public override void Process()
    {
        var consoleWriter = new ConsoleWriter();
        if (Index is null)
            return;
        items!.RemoveAt((int)Index);
        consoleWriter.WriteMessage("Successful delete", ConsoleColor.Green);
    }

    protected override void UpdateChildrens()
    {
        throw new NotImplementedException();
    }
}