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
        var StartMenuItems = new string[] { "Выход", "Пользователи", "Люди" };
        while (true)
        {
            var status = StartMenu(StartMenuItems);
            switch (status)
            {
                case Menu.People:
                    DoPersonActions(People);
                    break;
                case Menu.Users:
                    DoUserActions(Users);
                    break;
                case Menu.Exit:
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
            {
                continue;
            }
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
            {
                continue;
            }
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

    private static Menu? StartMenu(string[] StartMenuItems)
    {

        ConsoleRead_Write.WriteMenu(StartMenuItems);
        var value = ConsoleRead_Write.ReadInt();
        if (value is null)
        {
            return null;
        }
        switch ((Menu)value)
        {
            case Menu.Exit:
                return Menu.Exit;
            case Menu.Users:
                return Menu.Users;
            case Menu.People:
                return Menu.People;
            default:
                ConsoleRead_Write.WriteMessage("Неверное значение", "Red");
                return null;
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