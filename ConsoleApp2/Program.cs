internal class Program
{

    private static void Main()
    {
        var Users = new List<User>
        {
            new User("admin", "admin", (byte)Role.ADMIN),
            new User()
        };
        var People = new List<Person>();
        var MainMenuPersonItems = new string[] { "Exit", "Add", "Remove", "Edit", "Show" };
        var ConsoleReader = new ConsoleRead_Write();
        while (true)
        {
            Menu.Show(MainMenuPersonItems);
            if (DoPersonActions(ConsoleReader.ReadInt(), People) == (byte)CodeStatus.EXIT)
                return;

        }

    }

    private static int? DoPersonActions(int? value, List<Person> People)
    {
        switch (value)
        {
            case (byte)MainMenuItem.Exit:
                return value;

            case (byte)MainMenuItem.Add:
                PersonActions.Add(People);        
                return value;

            case (byte)MainMenuItem.Remove:
                PersonActions.Remove(People);
                return value;

            case (byte)MainMenuItem.Edit:
                return value;

            case (byte)MainMenuItem.Show:
                PersonActions.ShowList(People);
                Console.Write("Нажмите <Enter> для выхода... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                return value;

            default:
                Message.Show(message: "Неверное значение", "Red");
                return null;
        }
    }
    
    private static void EditPerson(List<Person> People)
    {
        var EditMenuItems = new string[] { "Назад", "Имя", "Возраст"};
        while (true)
        {
            Menu.Show(EditMenuItems, " Изменить ");
        }
    }

    //private static void RemovePerson(List<Person> People)
    //{
    //    var ConsoleReader = new ConsoleRead_Write();
    //    while (true)
    //    {
    //        ShowPeople(People);
    //        if (People.Count == 0)
    //        {
    //            return;
    //        }
    //        Console.Write("Введите номер для удаления (0 - Назад): ");
    //        int? value = ConsoleReader.ReadInt();
    //        if (value == 0)
    //        {
    //            return;
    //        }
    //        else if (value != null)
    //        {
    //            People.RemoveAt((int)value - 1);
    //            Message.Show("Успешное удаление", "Green");
    //        }
    //        else
    //        {
    //            Message.Show("Неверное значение", "Red");
    //        }
    //    }
    //}

    //private static void ShowPeople(List<Person> People)
    //{
    //    Console.Clear();
    //    if (People.Count == 0)
    //    {
    //        Message.Show("Пусто...");
    //        return;
    //    }
    //    for (int i = 0; i < People.Count; i++)
    //    {
    //        Console.Write($"{i + 1}. ");
    //        ConsoleRead_Write.WritePerson(People[i]);
    //    }
    //}

    //private static Person? AddPerson()
    //{
    //    Console.Clear();
    //    var ConsoleReader = new ConsoleRead_Write();
    //    var Person = new Person();
    //    Console.Write("Введите имя (0 - Назад): ");
    //    Person.Name = ConsoleReader.ReadString();
    //    if (Person.Name is null)
    //        return null;
    //    do
    //    {
    //        Console.Write("Введите возраст (0 -  Назад): ");
    //        Person.Age = ConsoleReader.ReadInt();
    //        if (Person.Age is null)
    //            Message.Show("Неверное значение", "Red");
    //        else if (Person.Age == 0)
    //            return null;
    //    } while (Person.Age < 1 || Person.Age > 100);
    //    Message.Show("Успешное добавление", "Green");
    //    return Person;
    //}

    public enum Role : byte
    {
        USER = 0,
        ADMIN = 1
    }

    public enum CodeStatus : byte
    {
        SUCCESS, EXIT = 0,
        UNSUCCESS = 1,
    }

    private enum MainMenuItem : byte
    {
        Exit = 0,
        Add = 1,
        Remove = 2,
        Edit = 3,
        Show = 4,
    }
}


