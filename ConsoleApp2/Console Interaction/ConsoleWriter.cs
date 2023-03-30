internal class ConsoleWriter : IWriter
{
    public bool WriteListItem<T>(T item)
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
            Console.WriteLine($"Логин: {user?.Username}  Пароль: {user?.Password}  Роль: {user?.Role}");
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
}

