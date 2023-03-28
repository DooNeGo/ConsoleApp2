using static Program;

class ConsoleReader : Reader
{
    public override int? ReadInt() => int.TryParse(Console.ReadLine(), out var result) ? result : null;

    public override string? ReadString()
    {
        var value = Console.ReadLine();
        if (value is "0") 
            return null;
        return value;
    }
}