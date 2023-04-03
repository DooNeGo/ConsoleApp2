internal class UserActions : DataActions
{
    public int? FindUser(List<User> Users, User user)
    {
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Username == user.Username && Users[i].Password == user.Password)
            {
                return i;
            }
        }
        return null;
    }

    public User? AddNewListItem()
    {
        User user = new();
        user.Username = GetUsenameFromConsole();
        if (user.Username is null)
            return null;
        user.Password = GetPasswordFromConsole();
        if (user.Password is null)
            return null;
        user.Role = GetRoleFromConsole();
        if (user.Role is null)
            return null;
        return user;

    }

    public string? GetUsenameFromConsole()
    {
        while (true)
        {
            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();
            Console.Write("Enter username (0 - Return): ");
            var login = consoleReader.ReadString();
            if (login != "")
                return login;
            else
                consoleWriter.WriteMessage("Please, enter an username", ConsoleColor.Red);
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

    public List<User>? Search(List<User> items)
    {
        var consoleReader = new ConsoleReader();
        Console.Clear();
        Console.Write("Search (0 - Return): ");
        var compare = consoleReader.ReadString();
        if (compare is null)
            return null;
        var list = new List<User>();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Username!.ToLower().Contains(compare.ToLower()))
                list.Add(items[i]);
        }
        return list;
    }
}