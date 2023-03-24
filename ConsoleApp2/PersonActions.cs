class PersonActions : DataActions
{
    public static void Add(List<Person> People)
    {
        Person Person = new();
        while (true)
        {
            Console.Clear();
            Console.Write("Введите имя (0 - Назад): ");
            Person.Name = ConsoleInteraction.ReadString();
            if (Person.Name is null)
                return;
            while (true)
            {
                Console.Write("Введите возраст (0 -  Назад): ");
                Person.Age = ConsoleInteraction.ReadInt();
                if (Person.Age is null || Person.Age < 1 || Person.Age > 100)
                    ConsoleInteraction.WriteMessage("Неверное значение", "Red");
                else if (Person.Age == 0)
                    return;
                else
                    break;
            }
            if (CheckRepetitions(People, Person) is true)
                ConsoleInteraction.WriteMessage("Такой человек уже существует", "Red");
            else
                break;
        }
        ConsoleInteraction.WriteMessage("Успешное добавление", "Green");
        People.Add(Person);
    }

    public static void Edit(List<Person> People)
    {
        var EditMenuItems = new string[] { "Назад", "Имя", "Возраст" };
        var personNum = SelectListItem(People);
        if (personNum is null)
            return;
        while (true)
        {
            ConsoleInteraction.WriteMenu(EditMenuItems, " Изменить ");
            var value = ConsoleInteraction.ReadInt();
            if (value == (byte)EditMenuItem.Return)
                break;
            else if (value == (byte)EditMenuItem.Name)
                EditName(People[(int)personNum - 1]);
            else if (value == (byte)EditMenuItem.Age)
                EditAge(People[(int)personNum - 1]);
            else
                ConsoleInteraction.WriteMessage("Неверное значение", "Red");
        }
    }

    private static bool CheckRepetitions(List<Person> People, Person Person)
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

    private static void EditName(Person person)
    {
        Console.Clear();
        Console.Write("Введите новое имя: ");
        var newName = ConsoleInteraction.ReadString();
        if (newName is null)
            return;
        person.Name = newName;
        ConsoleInteraction.WriteMessage("Изменение прошло успешно", "Green");
    }

    private static void EditAge(Person person)
    {
        Console.Clear();
        Console.Write("Введите новый возраст: ");
        var newAge = ConsoleInteraction.ReadInt();
        if (newAge is null)
            return;
        person.Age = newAge;
        ConsoleInteraction.WriteMessage("Изменение прошло успешно", "Green");
    }

    private enum EditMenuItem : byte
    {
        Return,
        Name,
        Age
    }
}
