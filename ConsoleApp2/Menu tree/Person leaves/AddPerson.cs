internal class AddPerson : ExtendPersonMainMenu
{
    public AddPerson(List<Person>? people, string menuItem = "Add") : base(people, menuItem)
    { }

    public override void Process()
    {
        if (HasErrors() is true)
            return;
        var personActions = new PersonActions();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            var newPerson = personActions.AddNewListItem();
            if (newPerson == null)
                return;
            if (personActions.CheckRepetitions(people, newPerson) is false)
            {
                people!.Add(newPerson);
                consoleWriter.WriteMessage("Successful add", ConsoleColor.Green);
            }
            else
            {
                consoleWriter.WriteMessage("This person already exist", ConsoleColor.Red);
            }
        }
    }
}
