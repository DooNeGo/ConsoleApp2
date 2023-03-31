internal class PersonSearchMenu : PersonSelectionMenu
{
    public PersonSearchMenu(List<Person>? people, string menuItem = "Search") : base(people, menuItem)
    { }

    public override void Process()
    {
        var personActions = new PersonActions();
        items = personActions.Search(items!);
        base.Process();
    }
}