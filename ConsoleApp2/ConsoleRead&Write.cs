class ConsoleRead_Write : IReader
{
    public static int? ReadInt()
    {
        var StringValue = Console.ReadLine();
        if (StringValue is null)
            return null;
        bool status = int.TryParse(StringValue, out int IntValue);
        if (status is false)
            return null;
        return IntValue;
    }

    public static string? ReadString()
    {
        var value = Console.ReadLine();
        if (value is "0") 
            return null;
        return value;
    }

    public static void WritePerson(Person person)
    {
        Console.WriteLine($"Имя: {person.Name}  Возраст: {person.Age}");
    }

    public static void WriteUser(User user)
    {
        string StringRole;
        if (user.Role == (byte)Program.Role.ADMIN)
            StringRole = "Админ";
        else
            StringRole = "Пользователь";
        Console.WriteLine($"Логин: {user.Login}  Пароль: {user.Password}  Роль: {StringRole}");
    }

    public static void WriteMessage(string message, string color = "White")
    {
        Console.Clear();
        if (color is "Red")
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (color is "Green")
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.WriteLine(message);
        Console.ResetColor();
        Console.Write("Нажмите <Enter> для выхода... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }

    public static void WriteMenu(string[] MenuItems, string prefix = " ")
    {
        Console.Clear();
        if (MenuItems.Length < 1)
        {
            Console.WriteLine("There is no menu items");
            return;
        }
        for (int i = 1; i < MenuItems.Length; i++)
        {
            Console.WriteLine($"{i} -{prefix}{MenuItems[i]}");
        }
        Console.WriteLine($"0 - {MenuItems[0]}");
    }
}