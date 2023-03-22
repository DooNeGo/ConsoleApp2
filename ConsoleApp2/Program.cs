internal class Program
{

    private static void Main()
    {
        var Users = new List<User>
        {
            new User("admin", "admin", (byte)Role.ADMIN),
            new User()
        };
        List<Person> People = new();
        var MainMenuPersonItems = new string[] { "Выход", "Добавить", "Удалить", "Изменить", "Показать" };
        while (true)
        {
            ConsoleRead_Write.WriteMenu(MainMenuPersonItems);
            if (DoPersonActions(ConsoleRead_Write.ReadInt(), People) == (byte)CodeStatus.EXIT)
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