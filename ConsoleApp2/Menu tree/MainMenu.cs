internal class MainMenu : Menu
{
    protected List<Person>? people = null;
    protected List<User>? users = null;

    public MainMenu(string menuItem = "Main menu") : base(menuItem)
    { }

    public MainMenu(List<Person>? people, List<User>? users, string menuItem = "Main menu") : base(menuItem)
    {
        this.people = people;
        this.users = users;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new UserMainMenu(users) },
            { 2, new PersonMainMenu(people) },
        };
    }
}