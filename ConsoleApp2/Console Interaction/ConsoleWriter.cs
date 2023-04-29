internal class ConsoleWriter
{
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