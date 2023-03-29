﻿internal class RemovePerson : PersonControlMenu
{
    public RemovePerson(List<Person>? people, int? index,  string menuItem = "Remove") : base(people, index, menuItem)
    { }

    public override void Process()
    {
        var consoleWriter = new ConsoleWriter();
        if (Index is null)
            return;
        items!.RemoveAt((int)Index);
        consoleWriter.WriteMessage("Successful delete", ConsoleColor.Green);
    }
}