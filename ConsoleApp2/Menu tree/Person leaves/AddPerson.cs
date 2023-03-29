internal class AddPerson : MainMenu
{
    public AddPerson(List<Person>? people, string menuItem = "Add") : base(people, menuItem: menuItem)
    { }

    public override void Process()
    {
        var personActions = new PersonActions();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            var newPerson = personActions.Add();
            if (newPerson == null)
                return;
            if (personActions.CheckRepetitions(people!, newPerson) is false)
            {
                people?.Add(newPerson);
                consoleWriter.WriteMessage("Successful add", ConsoleColor.Green);
            }
            else
            {
                consoleWriter.WriteMessage("This person already exist", ConsoleColor.Red);
            }
        }
    }
}
