internal class Program
{

    private static void Main()
    {
        var Users = new List<User>
        {
            new User("admin", "admin", Role.Admin),
            new User()
        };
        List<Person> People = new();
        while (true)
        {
            if (ConsoleRead_Write.DoAuthorization(Users) is null)
                return;
            StartMenu(Users, People);
        }
    }

    private static void StartMenu(List<User> Users, List<Person> People)
    {
        var StartMenuItems = new string[] { "Разлогиниться", "Пользователи", "Люди" };
        while (true)
        {
            ConsoleRead_Write.WriteMenu(StartMenuItems);
            var value = ConsoleRead_Write.ReadInt();
            switch (value)
            {
                case (byte)Menu.People:
                    DoPersonActions(People);
                    break;
                case (byte)Menu.Users:
                    DoUserActions(Users);
                    break;
                case (byte)Menu.Exit:
                    return;
                default:
                    ConsoleRead_Write.WriteMessage(message: "Неверное значение", "Red");
                    break;
            }
        }

    }

    private static void DoPersonActions(List<Person> People)
    {
        while (true)
        {
            var MainMenuItems = new string[] { "Назад", "Добавить", "Удалить", "Изменить", "Показать" };
            ConsoleRead_Write.WriteMenu(MainMenuItems);
            var value = ConsoleRead_Write.ReadInt();
            if (value is null)
                continue;
            switch ((MainMenuItem)value)
            {
                case MainMenuItem.Return:
                    return;

                case MainMenuItem.Add:
                    PersonActions.Add(People);
                    break;

                case MainMenuItem.Remove:
                    PersonActions.Remove(People);
                    break;

                case MainMenuItem.Edit:
                    PersonActions.Edit(People);
                    break;

                case MainMenuItem.Show:
                    PersonActions.ShowList(People);
                    Console.Write("Нажмите <Enter> для выхода... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    break;

                default:
                    ConsoleRead_Write.WriteMessage(message: "Неверное значение", "Red");
                    break;
            }
        }
    }

    private static void DoUserActions(List<User> Users)
    {
        while (true)
        {
            var MainMenuItems = new string[] { "Назад", "Добавить", "Удалить", "Изменить", "Показать" };
            ConsoleRead_Write.WriteMenu(MainMenuItems);
            var value = ConsoleRead_Write.ReadInt();
            if (value is null)
                continue;
            switch ((MainMenuItem)value)
            {
                case MainMenuItem.Return:
                    return;

                case MainMenuItem.Add:
                    UserActions.Add(Users);
                    break;

                case MainMenuItem.Remove:
                    UserActions.Remove(Users);
                    break;

                case MainMenuItem.Edit:
                    UserActions.Edit(Users);
                    break;

                case MainMenuItem.Show:
                    UserActions.ShowList(Users);
                    Console.Write("Нажмите <Enter> для выхода... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    break;

                default:
                    ConsoleRead_Write.WriteMessage(message: "Неверное значение", "Red");
                    break;
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