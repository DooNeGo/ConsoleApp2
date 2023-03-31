class PersonActions : DataActions<Person>
{
    public override Person? AddNewListItem()
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

    public int? GetAge()
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

    public List<Person>? Search(List<Person> items)
    {
        var consoleReader = new ConsoleReader();
        Console.Clear();
        Console.Write("Search (0 - Return): ");
        var compare = consoleReader.ReadString();
        if (compare is null)
            return null;
        compare = compare.ToLower();
        var list = new List<Person>();
        foreach (var person in items)
        {
            var ageString = person.Age.ToString()!.ToLower();
            if (person.Name!.ToLower().Contains(compare) || ageString.Contains(compare))
            {
                list.Add(person);
            }
        }
        return list;
    }
}