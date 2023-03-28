class PersonActions : DataActions
{
    public void Add(List<Person> People)
    {
        Person Person = new();
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Clear();
            Console.Write("Введите имя (0 - Назад): ");
            Person.Name = consoleReader.ReadString();
            if (Person.Name is null)
                return;
            while (true)
            {
                Console.Write("Введите возраст (0 -  Назад): ");
                Person.Age = consoleReader.ReadInt();
                if (Person.Age is null || Person.Age < 1 || Person.Age > 100)
                    consoleWriter.WriteMessage("Неверное значение", ConsoleColor.Red);
                else if (Person.Age == 0)
                    return;
                else
                    break;
            }
            if (CheckRepetitions(People, Person) is true)
                consoleWriter.WriteMessage("Такой человек уже существует", ConsoleColor.Red);
            else
                break;
        }
        consoleWriter.WriteMessage("Успешное добавление", ConsoleColor.Green);
        People.Add(Person);
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
            if (value == (byte)EditMenuItem.Return)
                break;
            else if (value == (byte)EditMenuItem.Name)
                EditName(People[(int)personNum - 1]);
            else if (value == (byte)EditMenuItem.Age)
                EditAge(People[(int)personNum - 1]);
            else
                consoleWriter.WriteMessage("Неверное значение", ConsoleColor.Red);
        }
    }

    private bool CheckRepetitions(List<Person> People, Person Person)
    {
        foreach (Person person in People)
        {
            if (person.Name == Person.Name && person.Age == Person.Age)
            {
                return true;
            }
        }
        return false;
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

    private enum EditMenuItem : byte
    {
        Return,
        Name,
        Age
    }
}
