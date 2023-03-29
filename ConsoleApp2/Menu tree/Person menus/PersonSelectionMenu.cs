internal class PersonSelectionMenu : SelectionMenu<Person>
{

    public PersonSelectionMenu(List<Person>? people, string menuItem = "Selection menu") : base(people, menuItem)
    { }

    protected override void UpdateChildrens()
    {
        childrens = new Dictionary<int, Menu>();
        for (int i = 0; i < items?.Count; i++)
        {
            childrens[i + 1] = new PersonControlMenu(items, i);
        }
    }
}