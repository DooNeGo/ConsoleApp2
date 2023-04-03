internal class EditUserName : EditTool<User>
{
    public EditUserName(string name, ApplicationContext<User> context) : base(name, context)
    { }

    protected override bool EditField()
    {
        var userActions = new UserActions();
        var usernameNew = userActions.GetUsenameFromConsole();
        if (usernameNew is null)
            return false;
        context.CurrentItem!.Username = usernameNew;
        return true;
    }
}