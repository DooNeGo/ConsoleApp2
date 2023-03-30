internal class ExtendUserMainMenu : ExtendMainMenu
{
    public ExtendUserMainMenu(List<User>? users, string menuItem = "User menu") : base(menuItem)
    {
        this.users = users;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new AddUser(users) },
            { 2, new UserSelectionMenu(users) },
        };
    }
}