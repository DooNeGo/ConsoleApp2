internal class EditUserPassword : EditTool<User>
{
    public EditUserPassword(string name, ApplicationContext<User> context) : base(name, context)
    { }

    protected override bool EditField()
    {
        var userActions = new UserActions();
        var passwordNew = userActions.GetPasswordFromConsole();
        if (passwordNew is null)
            return false;
        context.CurrentItem!.Password = passwordNew;
        return true;
    }
}