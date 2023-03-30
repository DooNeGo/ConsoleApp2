internal class EditUsername : EditTool<User>
{
    public EditUsername(int? index, List<User>? list, string menuItem = "Edit login") : base(index, list, menuItem)
    { }

    protected override bool EditField()
    {
        var userActions = new UserActions();
        var usernameNew = userActions.GetUsenameFromConsole();
        if (usernameNew is null)
            return false;
        items![(int)Index!].Username = usernameNew;
        return true;
    }
}