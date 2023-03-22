static class PersonActions
{
    public static void Remove(List<Person> People)
    {
        var value = SelectPerson(People);
        if (value is null)
            return;
        People.RemoveAt((int)value - 1);
        ConsoleRead_Write.WriteMessage("Успешное удаление", "Green");
    }

    public static void ShowList(List<Person> People)
    {
        Console.Clear();
        if (People.Count == 0)
        {
            ConsoleRead_Write.WriteMessage("Пусто...");
            return;
        }
        for (int i = 0; i < People.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            ConsoleRead_Write.WritePerson(People[i]);
        }
    }

    public static void Add(List<Person> People)
    {
        Console.Clear();
        Person Person = new();
        Console.Write("Введите имя (0 - Назад): ");
        Person.Name = ConsoleRead_Write.ReadString();
        if (Person.Name is null)
            return;
        do
        {
            Console.Write("Введите возраст (0 -  Назад): ");
            Person.Age = ConsoleRead_Write.ReadInt();
            if (Person.Age is null)
                ConsoleRead_Write.WriteMessage("Неверное значение", "Red");
            else if (Person.Age == 0)
                return;
        } while (Person.Age < 1 || Person.Age > 100);
        ConsoleRead_Write.WriteMessage("Успешное добавление", "Green");
        People.Add(Person);
    }

    public static void Edit(List<Person> People)
    {
        var EditMenuItems = new string[] { "Назад", "Имя", "Возраст" };
        var personNum = SelectPerson(People);
        if (personNum is null)
            return;
        while (true)
        {
            ConsoleRead_Write.WriteMenu(EditMenuItems, " Изменить ");
            var value = ConsoleRead_Write.ReadInt();
            if (value == (byte)EditMenuItem.Return)
                break;
            else if (value == (byte)EditMenuItem.Name)
                EditName(People[(int)personNum - 1]);
            else if (value == (byte)EditMenuItem.Age)
                EditAge(People[(int)personNum - 1]);
            else
                ConsoleRead_Write.WriteMessage("Неверное значение", "Red");
        }
    }

    private static int? SelectPerson(List<Person> People)
    {
        while (true)
        {
            ShowList(People);
            if (People.Count == 0)
                return null;
            Console.Write("Введите номер человека (0 - Назад): ");
            int? value = ConsoleRead_Write.ReadInt();
            if (value == 0)
                return null;
            else if (value > 0 && value <= People.Count)
                return value;
            else
                ConsoleRead_Write.WriteMessage("Неверное значение", "Red");
        }
    }

    private static void EditName(Person person)
    {
        Console.Clear();
        Console.Write("Введите новое имя: ");
        var newName = ConsoleRead_Write.ReadString();
        if (newName is null)
            return;
        person.Name = newName;
        ConsoleRead_Write.WriteMessage("Изменение прошло успешно", "Green");
    }

    private static void EditAge(Person person)
    {
        Console.Clear();
        Console.Write("Введите новый возраст: ");
        var newAge = ConsoleRead_Write.ReadInt();
        if (newAge is null)
            return;
        person.Age = newAge;
        ConsoleRead_Write.WriteMessage("Изменение прошло успешно", "Green");
    }

    private enum EditMenuItem : byte
    {
        Return = 0,
        Name = 1,
        Age = 2
    }
}
