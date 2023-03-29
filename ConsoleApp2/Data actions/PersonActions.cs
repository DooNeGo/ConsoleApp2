class PersonActions : DataActions<Person>
{
    public override Person? Add()
    {
        Person person = new();
        Console.Clear();
        person.Name = GetName();
        if (person.Name is null)
            return null;
        person.Age = GetAge();
        if (person.Age is null)
            return null;
        return person;
    }

    public string? GetName()
    {
        var consoleReader = new ConsoleReader();
        Console.Write("Enter name (0 - Return): ");
        return consoleReader.ReadString();
    }

    public int? GetAge()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Write("Enter age (0 - Return): ");
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
