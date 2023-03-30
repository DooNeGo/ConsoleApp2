class ConsoleReader : IReader
{
    public int? ReadInt() => int.TryParse(Console.ReadLine(), out var result) ? result : null;

    public string? ReadString()
    {
        var value = Console.ReadLine();
        if (value is "0")
            return null;
        return value;
    }
}