internal class PersonMainMenu : MainMenu
{
    public PersonMainMenu(List<Person>? people, string menuItem = "Person menu") : base(people, menuItem: menuItem)
    { }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, MainMenu>()
        {
            { 1, new AddPerson(people) },
            { 2, new ShowPeopleList(people) },
            { 3, new SelectPersonMenu(people!) },
        };
    }
}