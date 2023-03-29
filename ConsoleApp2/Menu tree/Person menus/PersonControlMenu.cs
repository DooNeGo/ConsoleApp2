internal class PersonControlMenu : ControlMenu<Person>
{
    public PersonControlMenu(List<Person>? people, int? index, string menuItem = "Control menu") : base(people, index, menuItem)
    { }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>()
        {
            { 1, new EditName(Index, items)},
            { 2, new EditAge(Index, items) },
            { 3, new Remove<Person>(items, Index) },
        };
    }
}
