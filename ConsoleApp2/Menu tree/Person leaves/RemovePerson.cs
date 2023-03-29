internal class RemovePerson : PersonControlMenu
{
    public RemovePerson(Person? person, List<Person>? people, string menuItem = "Remove") : base(person, people, menuItem)
    { }

    public override void Process()
    {
        var consoleWriter = new ConsoleWriter();
        people?.Remove(Person!);
        consoleWriter.WriteMessage("Successful delete", ConsoleColor.Green);
    }
}