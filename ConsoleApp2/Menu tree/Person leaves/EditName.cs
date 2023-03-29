internal class EditName : MainMenu
{
    private readonly int? index;

    public EditName(int? index, List<Person>? people, string menuItem = "Edit name") : base(people, menuItem:menuItem) 
    {
        this.index = index;
    }

    public override void Process()
    {
        var consoleWriter = new ConsoleWriter();
        if (Index is null)
            return;
        Console.Clear();
        EditField();
        consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
    }

    protected virtual void EditField()
    {
        var personActions = new PersonActions();
        string? newName = personActions.GetName();
        if (newName is null)
            return;
        people![(int)Index].Name = newName;
    }

    protected int? Index
    { 
        get { return index; }
    }
}