internal class EditName : EditTool<Person>
{
    public EditName(int? index, List<Person>? people, string menuItem = "Edit name") : base(index, people, menuItem)
    { }

    protected override bool EditField()
    {
        var personActions = new PersonActions();
        string? newName = personActions.GetName();
        if (newName is null)
            return false;
        list![(int)Index!].Name = newName;
        return true;
    }

    protected override void UpdateChildrens()
    {
        throw new NotImplementedException();
    }
}