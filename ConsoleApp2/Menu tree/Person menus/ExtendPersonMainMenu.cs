internal class ExtendPersonMainMenu : Menu
{
    protected List<Person>? people;
    public ExtendPersonMainMenu(List<Person>? people, string menuItem = "Person menu") : base(menuItem)
    {
        this.people = people;
    }

    protected override bool HasErrors()
    {
        if (people == null)
            return true;
        return false;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new AddPerson(people) },
            { 2, new PersonSelectionMenu(people) },
            { 3, new PersonSearchMenu(people) },
        };
    }
}