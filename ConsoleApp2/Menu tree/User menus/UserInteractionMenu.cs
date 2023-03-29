internal class UserInteractionMenu : MainMenu
{
    private Person person;

    public UserInteractionMenu(Person person, string menuItem = "Edit") : base(menuItem: menuItem)
    {
        this.person = person;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, MainMenu>()
        {
            { 1, new EditLogin() },
            { 2, new EditPassword() },
        };
    }

    public Person Person
    { get { return person; } }
}

