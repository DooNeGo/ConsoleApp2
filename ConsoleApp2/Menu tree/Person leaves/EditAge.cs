internal class EditAge : EditTool<Person>
{
    public EditAge(int? index, List<Person>? people, string menuItem = "Edit age") : base(index, people, menuItem)
    { }

    protected override bool EditField()
    {
        var personActions = new PersonActions();
        var ageNew = personActions.GetAge();
        if (ageNew is null || ageNew == 0)
            return false;
        list![(int)Index!].Age = ageNew;
        return true;
    }

    protected override void UpdateChildrens()
    {
        throw new NotImplementedException();
    }
}