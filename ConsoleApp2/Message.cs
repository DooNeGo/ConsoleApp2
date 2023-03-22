static class Message
{
    public static void Show(string message, string color = "White")
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
}