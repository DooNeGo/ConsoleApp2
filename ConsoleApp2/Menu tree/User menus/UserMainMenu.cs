internal class UserMainMenu : MainMenu
{
    public UserMainMenu(List<User>? users, string menuItem = "User menu") : base(menuItem)
    {
        this.users = users;
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new AddUser(users) },
            { 2, new ShowList<User>(users) },
            { 3, new UserSelectionMenu(users) },
        };
    }
}