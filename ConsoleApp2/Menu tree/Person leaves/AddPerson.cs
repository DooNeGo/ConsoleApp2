internal class AddPerson : Menu
{
    private readonly List<Person> people;
    public AddPerson(string name, List<Person> people) : base(name)
    {
        this.people = people;
    }

    public override void Process()
    {
        var personActions = new PersonActions();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----- Person add -----");
            var newPerson = personActions.AddNewListItem();
            if (newPerson == null)
                return;
            if (personActions.CheckRepetitions(people, newPerson) is false)
            {
                people.Add(newPerson);
                consoleWriter.WriteMessage("Successful add", ConsoleColor.Green);
            }
            else
            {
                consoleWriter.WriteMessage("This person already exist", ConsoleColor.Red);
            }
        }
    }
}