internal class EditLogin : EditTool<User>
{
    public EditLogin(int? index, List<User>? list, string menuItem = "Edit login") : base(index, list, menuItem)
    { }

    protected override bool EditField()
    {
        var userActions = new UserActions();
        var loginNew = userActions.GetLoginFromConsole();
        if (loginNew is null)
            return false;
        list![(int)Index].Login = loginNew;
        return true;
    }

    protected override void UpdateChildrens()
    {
        throw new NotImplementedException();
    }
}