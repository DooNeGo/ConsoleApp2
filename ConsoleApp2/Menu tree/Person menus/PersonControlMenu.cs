internal class PersonControlMenu : MainMenu
{
    private readonly Person? person;

    public PersonControlMenu(Person? person, List<Person>? people, string menuItem = "Control menu") : base(people, menuItem:menuItem)
    {
        this.person = person;
    }

    protected override void UpdateChildrens()
    {

        childrens = new Dictionary<int, MainMenu>()
        {
            { 1, new EditName(people!.BinarySearch(person!), people)},
            { 2, new EditAge(people!.BinarySearch(person!), people) },
            { 3, new RemovePerson(Person, people) },
        };
    }

    public Person? Person
    { 
        get { return person; } 
    }
}
