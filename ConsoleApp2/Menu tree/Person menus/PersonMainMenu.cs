internal class PersonMainMenu : MainMenu
{
    public PersonMainMenu(List<Person>? people, string menuItem = "Person menu") : base(menuItem)
    {
        this.people = people;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new ShowList<Person>(people) },
        };
    }
}