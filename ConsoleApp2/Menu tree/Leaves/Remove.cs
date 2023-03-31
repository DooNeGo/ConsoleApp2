internal class Remove<T> : ControlMenu<T>
{
    public Remove(List<T>? items, int? index, string menuItem = "Remove") : base(index, menuItem)
    {
        Remove<T>.items = items;
    }

    public override void Process()
    {
        if (HasErrors())
            return;
        var consoleWriter = new ConsoleWriter();
        items!.RemoveAt((int)Index!);
        consoleWriter.WriteMessage("Successful delete", ConsoleColor.Green);
    }

    protected override void UpdateChildrens()
    {
        throw new NotImplementedException();
    }
}