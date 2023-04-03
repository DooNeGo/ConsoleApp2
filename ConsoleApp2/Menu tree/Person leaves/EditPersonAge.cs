internal class EditPersonAge : EditTool<Person>
{
    public EditPersonAge(string name, ApplicationContext<Person> context) : base(name, context)
    { }

    protected override bool EditField()
    {
        var personActions = new PersonActions();
        var ageNew = personActions.GetAge();
        if (ageNew is null || ageNew == 0)
            return false;
        context.CurrentItem!.Age = ageNew;
        return true;
    }
}