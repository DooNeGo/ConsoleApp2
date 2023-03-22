internal class Program
{

    private static void Main()
    {
        var Users = new List<User>
        {
            new User("admin", "admin", Role.ADMIN),
            new User()
        };
        List<Person> People = new();
        var MainMenuItems = new string[] { "Выход", "Добавить", "Удалить", "Изменить", "Показать" };
        while (true)
        {
            ConsoleRead_Write.WriteMenu(MainMenuItems);
            if (DoPersonActions(ConsoleRead_Write.ReadInt(), People) == (byte)MainMenuItem.Exit)
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
                PersonActions.Edit(People);
                return value;

            case (byte)MainMenuItem.Show:
                PersonActions.ShowList(People);
                Console.Write("Нажмите <Enter> для выхода... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                return value;

            default:
                ConsoleRead_Write.WriteMessage(message: "Неверное значение", "Red");
                return null;
        }
    }

    public enum Role : byte
    {
        USER,
        ADMIN
    }

    private enum MainMenuItem : byte
    {
        Exit,
        Add,
        Remove,
        Edit,
        Show,
    }
}