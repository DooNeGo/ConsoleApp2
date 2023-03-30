internal class Program
{
    private static void Main()
    {
        var users = new List<User>
        {
            new User("admin", "admin", Role.Admin),
            new User()
        };
        List<Person> people = new();
        var menu = new MainMenu(people, users);
        //if (DoAuthorization(users) is null)
        //    return;
        menu.Process();
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
            Console.Write("Login (0 - Exit): ");
            authUser.Login = consoleReader.ReadString();
            if (authUser.Login is null)
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
                consoleWriter.WriteMessage("Вход выполнен успешно", ConsoleColor.Green);
                return Users[(int)status].Role;
            }
            else
            {
                consoleWriter.WriteMessage("Wrong login or password", ConsoleColor.Red);
            }
        }
    }

    public enum Role : byte
    {
        User,
        Admin
    }
}