internal class EditUserRole : EditTool<User>
{
    public EditUserRole(string name, ApplicationContext<User> context) : base(name, context)
    { }

    protected override bool EditField()
    {
        var userActions = new UserActions();
        var roleNew = userActions.GetRoleFromConsole();
        if (roleNew is null)
            return false;
        context.CurrentItem!.Role = roleNew;
        return true;
    }
}