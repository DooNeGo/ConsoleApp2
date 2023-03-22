static class PersonActions
{
    public static void Remove(List<Person> People)
    {
        var value = SelectPerson(People);
        if (value is null)
            return;
        People.RemoveAt((int)value - 1);
        Message.Show("Успешное удаление", "Green");
    }

    public static void ShowList(List<Person> People)
    {
        Console.Clear();
        if (People.Count == 0)
        {
            Message.Show("Пусто...");
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
                Message.Show("Неверное значение", "Red");
            else if (Person.Age == 0)
                return;
        } while (Person.Age < 1 || Person.Age > 100);
        Message.Show("Успешное добавление", "Green");
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
            Menu.Show(EditMenuItems, " Изменить ");
            var value = ConsoleRead_Write.ReadInt();
            switch(value)
            {
                case 0:
                    break;
                case 1:
                    EditName(People[(int)personNum - 1]);                    
                    break;
                case 2:
                    EditAge(People[(int)personNum - 1]);
                    break;
                default:
                    Message.Show("Неверное значение", "Red");
                    break;
            }
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
                Message.Show("Неверное значение", "Red");
        }
    }

    private static void EditName(Person person)
    {
        Console.Write("Введите новое имя: ");
        var newName = ConsoleRead_Write.ReadString();
        if (newName is null)
            return;
        person.Name = newName;
        Message.Show("Изменение прошло успешно", "Green");
    }

    private static void EditAge(Person person)
    {
        Console.Write("Введите новый возраст: ");
        var newAge = ConsoleRead_Write.ReadInt();
        if (newAge is null)
            return;
        person.Age = newAge;
        Message.Show("Изменение прошло успешно", "Green");
    }
}
