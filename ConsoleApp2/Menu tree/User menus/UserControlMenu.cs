internal class UserControlMenu : ControlMenu<User>
{
    public UserControlMenu(List<User>? items, int? index, string menuItem = "Control menu") : base(items, index, menuItem)
    { }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new EditLogin(Index, items)},
            { 2, new EditPassword(Index, items) },
            { 3, new EditRole(Index, items) },
            { 4, new Remove<User>(items, Index) }
        };
    }
}