internal class ConsoleWriter : Writer
{
    public override bool WriteListItem<T>(T item)
    {
        if (item is null)
        {
            return false;
        }
        if (item is Person person)
        {
            Console.WriteLine($"Имя: {person?.Name}  Возраст: {person?.Age}");
            return true;
        }
        else if (item is User user)
        {
            Console.WriteLine($"Логин: {user?.Login}  Пароль: {user?.Password}  Роль: {user?.Role}");
            return true;
        }
        else
            throw new Exception();            
    }

    public void WriteMessage(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine("Нажмите <Enter> для выхода... ");
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

