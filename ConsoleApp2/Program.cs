internal class Program
{
    private static void Main()
    {
        var users = new List<User>
        {
            new User("admin", "admin", Role.Admin),
            new User()
        };
        List<Person> people = new()
        {
            new Person("Bob", 23),
            new Person("Stas :)"),
            new Person("Matvey supercalifragilisticexpialidocious programmer")
        };
        while (true)
        {
            var role = DoAuthorization(users);
            if (role is null)
            {
                return;
            }
            else if (role is Role.Admin)
            {
                var extendMenu = new ExtendMainMenu(people, users);
                extendMenu.Process();
            }
            else
            {
                var menu = new MainMenu(people, users);
                menu.Process();
            }
        }
    }

    private static Role? DoAuthorization(List<User> Users)
    {
        var authUser = new User();
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        var userActions = new UserActions();
        while (true)
        {
            Console.Clear();
            Console.Write("Username (0 - Exit): ");
            authUser.Username = consoleReader.ReadString();
            if (authUser.Username is null)
            {
                return null;
            }
            Console.Write("Password (0 - Exit): ");
            authUser.Password = consoleReader.ReadString();
            if (authUser.Password is null)
            {
                return null;
            }
            var status = userActions.FindUser(Users, authUser);
            if (status != null)
            {
                consoleWriter.WriteMessage("Login Successful", ConsoleColor.Green);
                return Users[(int)status].Role;
            }
            else
            {
                consoleWriter.WriteMessage("Wrong username or password", ConsoleColor.Red);
            }
        }
    }

    public enum Role : byte
    {
        User,
        Admin
    }
}