internal class EditAge : EditName
{
    public EditAge(int? index, List<Person>? people, string menuItem = "Edit age") : base(index, people, menuItem: menuItem)
    { }

    protected override void EditField()
    {
        var personActions = new PersonActions();
        people![(int)Index].Age = personActions.GetAge();
    }
}