internal class MainMenu : Menu
{
    protected List<Person>? people;
    protected List<User>? users;

    public MainMenu(string menuItem = "Main menu") : base(menuItem)
    { }

    public MainMenu(List<Person>? people, List<User>? users, string menuItem = "Main menu") : base(menuItem)
    {
        this.people = people;
        this.users = users;
    }

    protected override bool HasErrors()
    {
        if (people is null && users is null)
            return true;
        if (childrens!.Count == 1)
            return true;
        return false;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new PersonMainMenu(people) },
        };
    }
}