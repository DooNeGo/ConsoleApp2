internal class EditPassword : EditTool<User>
{
    public EditPassword(int? index, List<User>? list, string menuItem = "Edit password") : base(index, list, menuItem)
    { }

    protected override bool EditField()
    {
        var userActions = new UserActions();
        var passwordNew = userActions.GetPasswordFromConsole();
        if (passwordNew is null)
            return false;
        list![(int)Index!].Password = passwordNew;
        return true;
    }

    protected override void UpdateChildrens()
    {
        throw new NotImplementedException();
    }
}