internal class ExtendMainMenu : Menu
{
    protected List<Person>? people;
    protected List<User>? users;

    public ExtendMainMenu(string menuItem = "Main menu") : base(menuItem)
    { }

    public ExtendMainMenu(List<Person>? people, List<User>? users, string menuItem = "Main menu") : base(menuItem)
    {
        this.people = people;
        this.users = users;
    }

    protected override bool HasErrors()
    {
        if (people is null && users is null)
            return true;
        return false;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new ExtendUserMainMenu(users) },
            { 2, new ExtendPersonMainMenu(people) },
        };
    }
}