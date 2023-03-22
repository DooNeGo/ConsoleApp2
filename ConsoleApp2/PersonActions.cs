class PersonActions : IDataActions
{
    public static void Remove(List<Person> People)
    {
        var ConsoleReader = new ConsoleRead_Write();
        while (true)
        {
            ShowList(People);
            if (People.Count == 0)
            {
                return;
            }
            Console.Write("Введите номер для удаления (0 - Назад): ");
            int? value = ConsoleReader.ReadInt();
            if (value == 0)
            {
                return;
            }
            else if (value != null)
            {
                People.RemoveAt((int)value - 1);
                Message.Show("Успешное удаление", "Green");
            }
            else
            {
                Message.Show("Неверное значение", "Red");
            }
        }
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
        var ConsoleReader = new ConsoleRead_Write();
        var Person = new Person();
        Console.Write("Введите имя (0 - Назад): ");
        Person.Name = ConsoleReader.ReadString();
        if (Person.Name is null)
            return;
        do
        {
            Console.Write("Введите возраст (0 -  Назад): ");
            Person.Age = ConsoleReader.ReadInt();
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
        throw new NotImplementedException();
    }
}
