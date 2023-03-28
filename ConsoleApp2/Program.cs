internal class Program
{

    private static void Main()
    {
        var menu = new MainMenu();
        var users = new List<User>
        {
            new User("admin", "admin", Role.Admin),
            new User()
        };
        List<Person> people = new();
        //if (DoAuthorization(users) is null)
        //    return;
        menu.Process(users, people);
        Console.ReadKey();
    }

    //private static void StartMenu(List<User> Users, List<Person> People)
    //{
    //    var StartMenuItems = new string[] { "Разлогиниться", "Пользователи", "Люди" };
    //    while (true)
    //    {
    //        ConsoleReader.WriteMenu(StartMenuItems);
    //        var value = ConsoleReader.ReadInt();
    //        switch (value)
    //        {
    //            case (byte)Menu.People:
    //                DoPersonActions(People);
    //                break;
    //            case (byte)Menu.Users:
    //                DoUserActions(Users);
    //                break;
    //            case (byte)Menu.Exit:
    //                return;
    //            default:
    //                ConsoleReader.WriteMessage(message: "Неверное значение", "Red");
    //                break;
    //        }
    //    }

    //}

    private static void DoPersonActions(List<Person> People)
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        var personActioner = new PersonActions();
        while (true)
        {
            var MainMenuItems = new string[] { "Назад", "Добавить", "Удалить", "Изменить", "Показать" };
            consoleWriter.WriteMenu(MainMenuItems);
            var value = consoleReader.ReadInt();
            if (value is null)
                continue;
            switch ((MainMenuItem)value)
            {
                case MainMenuItem.Return:
                    return;

                case MainMenuItem.Add:
                    personActioner.Add(People);
                    break;

                case MainMenuItem.Remove:
                    personActioner.Remove(People);
                    break;

                case MainMenuItem.Edit:
                    personActioner.Edit(People);
                    break;

                case MainMenuItem.Show:
                    personActioner.ShowList(People);
                    Console.Write("Нажмите <Enter> для выхода... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    break;

                default:
                    consoleWriter.WriteMessage(message: "Неверное значение", ConsoleColor.Red);
                    break;
            }
        }
    }

    private static void DoUserActions(List<User> Users)
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        var userActioner = new UserActions();
        while (true)
        {
            var MainMenuItems = new string[] { "Назад", "Добавить", "Удалить", "Изменить", "Показать" };
            consoleWriter.WriteMenu(MainMenuItems);
            var value = consoleReader.ReadInt();
            if (value is null)
                continue;
            switch ((MainMenuItem)value)
            {
                case MainMenuItem.Return:
                    return;

                case MainMenuItem.Add:
                    userActioner.Add(Users);
                    break;

                case MainMenuItem.Remove:
                    userActioner.Remove(Users);
                    break;

                case MainMenuItem.Edit:
                    userActioner.Edit(Users);
                    break;

                case MainMenuItem.Show:
                    userActioner.ShowList(Users);
                    Console.Write("Нажмите <Enter> для выхода... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    break;

                default:
                    consoleWriter.WriteMessage(message: "Неверное значение", ConsoleColor.Red);
                    break;
            }
        }
    }

    private static Role? DoAuthorization(List<User> Users)
    {
        var authUser = new User();
        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var userActioner = new UserActions();
        while (true)
        {
            Console.Clear();
            Console.Write("Логин (0 - Выход): ");
            authUser.Login = reader.ReadString();
            if (authUser.Login is null)
            {
                return null;
            }
            Console.Write("Пароль (0 - Выход): ");
            authUser.Password = reader.ReadString();
            if (authUser.Password is null)
            {
                return null;
            }
            var status = userActioner.CheckRepetitions(Users, authUser);
            if (status != null)
            {
                writer.WriteMessage("Вход выполнен успешно", ConsoleColor.Green);
                return Users[(int)status].Role;
            }
            else
            {
                writer.WriteMessage("Неверный логин или пароль", ConsoleColor.Red);
            }
        }
    }

    private enum Menu : byte
    {
        Exit,
        Users,
        People,
    }

    public enum Role : byte
    {
        User,
        Admin
    }

    private enum MainMenuItem : byte
    {
        Return,
        Add,
        Remove,
        Edit,
        Show,
    }
}