internal class RemoveUser : MainMenu
{
    public RemoveUser(List<User>? users, string menuItem = "Remove") : base(menuItem: menuItem, users:users)
    { }

    public override void Process()
    {
        var userActions = new UserActions();
        userActions.Remove(users!);
    }
}