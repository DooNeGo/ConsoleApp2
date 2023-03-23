using static Program;

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
        if (user.Role == Program.Role.Admin)
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

    public static void WriteMenu(string[] MenuItems, string prefix = " ", string postfix = "")
    {
        Console.Clear();
        if (MenuItems.Length < 1)
        {
            Console.WriteLine("There is no menu items");
            return;
        }
        for (int i = 1; i < MenuItems.Length; i++)
        {
            Console.WriteLine($"{i} -{prefix}{MenuItems[i]} {postfix}");
        }
        Console.WriteLine($"0 - {MenuItems[0]}");
    }

    public static Role? DoAuthorization(List<User> Users)
    {
        var AuthUser = new User();
        while (true)
        {
            Console.Clear();
            Console.Write("Логин (0 - Выход): ");
            AuthUser.Login = ReadString();
            if (AuthUser.Login is null)
            {
                return null;
            }
            Console.Write("Пароль (0 - Выход): ");
            AuthUser.Password = ReadString();
            if (AuthUser.Password is null)
            {
                return null;
            }
            var status = UserActions.CheckRepetitions(Users, AuthUser);
            if (status != null)
            {
                WriteMessage("Вход выполнен успешно", "Green");
                return Users[(int)status].Role;
            }
            else
            {
                WriteMessage("Неверный логин или пароль", "Red");
            }
        }
    }
}