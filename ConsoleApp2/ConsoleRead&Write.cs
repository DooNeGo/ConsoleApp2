class ConsoleRead_Write : Reader
{
    public override int? ReadInt()
    {
        var StringValue = Console.ReadLine();
        if (StringValue is null)
            return null;
        bool status = int.TryParse(StringValue, out int IntValue);
        if (status is false)
            return null;
        return IntValue;
    }

    public override string? ReadString()
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
}