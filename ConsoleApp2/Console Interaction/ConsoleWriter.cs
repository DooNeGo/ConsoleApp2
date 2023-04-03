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
            Console.WriteLine($"Name: {person.Name}  Age: {person.Age}");
            return true;
        }
        else if (item is User user)
        {
            Console.WriteLine($"Username: {user.Username}  Role: {user.Role}");
            return true;
        }
        else
            throw new Exception();            
    }

    public void WriteMessage(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.Clear();
        Console.WriteLine("----- Message -----");
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine("Нажмите <Enter> для продолжения... ");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }
}

