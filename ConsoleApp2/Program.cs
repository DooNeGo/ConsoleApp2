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
            if (ConsoleInteraction.DoAuthorization(Users) is null)
                return;
            StartMenu(Users, People);
        }
    }

    private static void StartMenu(List<User> Users, List<Person> People)
    {
        var StartMenuItems = new string[] { "Разлогиниться", "Пользователи", "Люди" };
        while (true)
        {
            ConsoleInteraction.WriteMenu(StartMenuItems);
            var value = ConsoleInteraction.ReadInt();
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
                    ConsoleInteraction.WriteMessage(message: "Неверное значение", "Red");
                    break;
            }
        }

    }

    private static void DoPersonActions(List<Person> People)
    {
        while (true)
        {
            var MainMenuItems = new string[] { "Назад", "Добавить", "Удалить", "Изменить", "Показать" };
            ConsoleInteraction.WriteMenu(MainMenuItems);
            var value = ConsoleInteraction.ReadInt();
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
                    ConsoleInteraction.WriteMessage(message: "Неверное значение", "Red");
                    break;
            }
        }
    }

    private static void DoUserActions(List<User> Users)
    {
        while (true)
        {
            var MainMenuItems = new string[] { "Назад", "Добавить", "Удалить", "Изменить", "Показать" };
            ConsoleInteraction.WriteMenu(MainMenuItems);
            var value = ConsoleInteraction.ReadInt();
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
                    ConsoleInteraction.WriteMessage(message: "Неверное значение", "Red");
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