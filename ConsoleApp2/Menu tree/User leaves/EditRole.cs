﻿internal class EditRole : EditTool<User>
{
    public EditRole(int? index, List<User>? list, string menuItem = "Edit role") : base(index, list, menuItem)
    { }

    protected override bool EditField()
    {
        var userActions = new UserActions();
        var roleNew = userActions.GetRoleFromConsole();
        if (roleNew is null)
            return false;
        items![(int)Index!].Role = roleNew;
        return true;
    }
}