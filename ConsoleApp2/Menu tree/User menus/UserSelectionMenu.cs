internal class UserSelectionMenu : SelectionMenu<User>
{
    public UserSelectionMenu(List<User>? items, string menuItem = "Selection menu") : base(items, menuItem)
    { }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>();
        UserControlMenu.items = items;
        UserControlMenu.listCount = items?.Count;
        for (int i = 0; i < items?.Count; i++)
        {
            childrens[i + 1] = new UserControlMenu(i);
        }
    }
}