internal class UserMainMenu : MainMenu
{
    public UserMainMenu(string menuItem = "Something...") : base(menuItem)
    {
    }

    private protected override void MakeChildrens()
    {
        childrens = new Dictionary<int, MainMenu>()
        {
            {1, new AddUser("Add") },
            { 2, new RemoveUser("Remove") },
        };
    }
}

