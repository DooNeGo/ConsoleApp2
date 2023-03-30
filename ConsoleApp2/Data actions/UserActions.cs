internal class UserActions : DataActions<User>
{
    public int? FindUser(List<User> Users, User user)
    {
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Login == user.Login)
            {
                return i;
            }
        }
        return null;
    }

    public override User? AddUser()
    {
        User user = new();
        Console.Clear();
        user.Login = GetLoginFromConsole();
        if (user.Login is null)
            return null;
        user.Password = GetPasswordFromConsole();
        if (user.Password is null)
            return null;
        user.Role = GetRoleFromConsole();
        if (user.Role is null)
            return null;
        return user;

    }

    public string? GetLoginFromConsole()
    {
        while (true)
        {
            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();
            Console.Write("Enter login (0 - Return): ");
            var login = consoleReader.ReadString();
            if (login != "")
                return login;
            else
                consoleWriter.WriteMessage("Please, enter a login", ConsoleColor.Red);
        }
    }

    public string? GetPasswordFromConsole()
    {
        var consoleReader = new ConsoleReader();
        Console.Write("Enter password (0 - Return): ");
        return consoleReader.ReadString();
    }

    public Program.Role? GetRoleFromConsole()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Write("Enter role (0 - Return 1 - User 2 - Admin): ");
            var value = consoleReader.ReadInt();
            if (value == 0)
                return null;
            else if (value == 1 || value == 2)
                return (Program.Role)value - 1;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }
}
