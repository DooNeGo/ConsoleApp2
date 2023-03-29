internal class UserMainMenu : MainMenu
{
    public UserMainMenu(List<User>? users, string menuItem = "User menu") : base(menuItem: menuItem, users: users)
    { }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, MainMenu>()
        {
            { 1, new AddUser(users) },
            { 2, new RemoveUser(users) },
            { 3, new ShowUsersList(users!) },
            { 4, new UserEditMenu() },
        };
    }
}