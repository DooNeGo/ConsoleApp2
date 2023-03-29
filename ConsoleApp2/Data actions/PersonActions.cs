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

    public void Edit(List<Person> People)
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        var EditMenuItems = new string[] { "Назад", "Имя", "Возраст" };
        var personNum = SelectListItem(People);
        if (personNum is null)
            return;
        while (true)
        {
            consoleWriter.WriteMenu(EditMenuItems, " Изменить ");
            var value = consoleReader.ReadInt();
            if (EditMenuItem.Return.Equals(value))
                break;
            else if (EditMenuItem.Name.Equals(value))
                EditName(People[(int)personNum - 1]);
            else if (value == (byte)EditMenuItem.Age)
                EditAge(People[(int)personNum - 1]);
            else
                consoleWriter.WriteMessage("Неверное значение", ConsoleColor.Red);
        }
    }

    private void EditName(Person person)
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        Console.Clear();
        Console.Write("Введите новое имя: ");
        var newName = consoleReader.ReadString();
        if (newName is null)
            return;
        person.Name = newName;
        consoleWriter.WriteMessage("Изменение прошло успешно", ConsoleColor.Green);
    }

    private void EditAge(Person person)
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        Console.Clear();
        Console.Write("Введите новый возраст: ");
        var newAge = consoleReader.ReadInt();
        if (newAge is null)
            return;
        person.Age = newAge;
        consoleWriter.WriteMessage("Изменение прошло успешно", ConsoleColor.Green);
    }

    private enum EditMenuItem : int
    {
        Return,
        Name,
        Age
    }
}
