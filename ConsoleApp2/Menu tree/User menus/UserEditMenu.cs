internal class UserEditMenu : MainMenu
{
    public UserEditMenu(string menuItem = "Edit menu") : base(menuItem: menuItem)
    { }

    public override void Process()
    {
        var userActions = new UserActions();
        var value = userActions.SelectListItem(users!);

        base.Process();
    }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, MainMenu>
        {
            { 1, new EditLogin() },
            { 2, new EditPassword() },
        };
    }
}