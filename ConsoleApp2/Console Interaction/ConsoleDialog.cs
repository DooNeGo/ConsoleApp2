internal class ConsoleDialog
{
    public Person? GetPersonDialog()
    {
        Person person = new();
        person.Name = GetPersonNameDialog();
        if (person.Name is null)
            return null;
        person.Age = GetPersonAgeDialog();
        if (person.Age is null)
            return null;
        return person;
    }

    public string? GetPersonNameDialog()
    {
        while (true)
        {
            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();
            Console.Write("Enter a name (0 - Return): ");
            var name = consoleReader.ReadString();
            if (name != "")
                return name;
            else
                consoleWriter.WriteMessage("Please, enter a name", ConsoleColor.Red);
        }
    }

    public int? GetPersonAgeDialog()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Write("Enter an age (0 - Return): ");
            var value = consoleReader.ReadInt();
            if (value is null || value < 0 || value > 100)
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
            else if (value == 0)
                return null;
            else
                return value;
        }
    }

    public User? GetUserDialog()
    {
        User user = new();
        user.Username = GetUsenameDialog();
        if (user.Username is null)
            return null;
        user.Password = GetPasswordDialog();
        if (user.Password is null)
            return null;
        user.Role = GetRoleDialog();
        if (user.Role is null)
            return null;
        return user;

    }

    public string? GetUsenameDialog()
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

    public string? GetPasswordDialog()
    {
        var consoleReader = new ConsoleReader();
        Console.Write("Enter password (0 - Return): ");
        return consoleReader.ReadString();
    }

    public Program.Role? GetRoleDialog()
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
