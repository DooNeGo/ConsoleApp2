using static Program;

internal class ConsoleWriter : Writer
{
    public override bool WriteListItem<T>(T item)
    {
        if (item is null)
        {
            return false;
        }
        else if (typeof(T) == typeof(Person))
        {
            Person person = item as Person;
            Console.WriteLine($"Имя: {person.Name}  Возраст: {person.Age}");
            return true;
        }
        else if (typeof(T) == typeof(User))
        {
            User user = item as User;
            string roleString;
            if (user.Role == Role.Admin)
                roleString = "Админ";
            else
                roleString = "Пользователь";
            Console.WriteLine($"Логин: {user.Login}  Пароль: {user.Password}  Роль: {roleString}");
            return true;
        }
        return false;
    }

    public void WriteMessage(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.Write("Нажмите <Enter> для выхода... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }

    public void WriteMenu(string[] menuItems, string prefix = " ", string postfix = "")
    {
        Console.Clear();
        if (menuItems.Length < 1)
        {
            Console.WriteLine("There is no menu items");
            return;
        }
        for (int i = 1; i < menuItems.Length; i++)
        {
            Console.WriteLine($"{i} -{prefix}{menuItems[i]} {postfix}");
        }
        Console.WriteLine($"0 - {menuItems[0]}");
    }

}

