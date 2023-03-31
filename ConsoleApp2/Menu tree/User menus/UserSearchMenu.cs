internal class UserSearchMenu : UserSelectionMenu
{
    public UserSearchMenu(List<User>? items, string menuItem = "Search") : base(items, menuItem)
    { }

    public override void Process()
    {
        var userActions = new UserActions();
        items = userActions.Search(items!);
        base.Process();
    }
}