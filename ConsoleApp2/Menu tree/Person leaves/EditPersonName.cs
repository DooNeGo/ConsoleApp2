internal class EditPersonName : EditTool<Person>
{
    public EditPersonName(string name, ApplicationContext<Person> context) : base(name, context)
    { }

    protected override bool EditField()
    {
        var personActions = new PersonActions();
        string? newName = personActions.GetName();
        if (newName is null)
            return false;
        context.CurrentItem!.Name = newName;
        return true;
    }
}