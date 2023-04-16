class PersonActions : DataActions
{
    public Person? AddNewListItem()
    {
        Person person = new();
        person.Name = GetNameDialog();
        if (person.Name is null)
            return null;
        person.Age = GetAgeDialog();
        if (person.Age is null)
            return null;
        return person;
    }

    public string? GetNameDialog()
    {
        while (true)
        {
            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();
            Console.Write("Enter a name (0 - Return): ");
            var name = consoleReader.ReadString();
            if (name != "")
                return name;
            else
                consoleWriter.WriteMessage("Please, enter a name", ConsoleColor.Red);
        }
    }

    public int? GetAgeDialog()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Write("Enter the age (0 - Return): ");
            var value = consoleReader.ReadInt();
            if (value is null || value < 0 || value > 100)
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
            else if (value == 0)
                return null;
            else
                return value;
        }
    }
}