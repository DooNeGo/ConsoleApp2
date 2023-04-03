internal class Program
{
    private static void Main()
    {
        var users = new List<User>
        {
            new User("admin", "admin", Role.Admin),
            new User("user", "", Role.User),
        };

        var people = new List<Person>()
        {
            new Person("Bob", 23),
            new Person("Stas :)", 1),
            new Person("Matvey supercalifragilisticexpialidocious programmer", 1)
        };

        var userContext = new ApplicationContext<User>(users);
        var personContext = new ApplicationContext<Person>(people);
        while (true)
        {
            userContext.CurrentUser = DoAuthorization(users);
            if (userContext.CurrentUser is null)
                return;
            var menu = InitializeMenuWithRole(userContext, personContext);
            menu.Process();
        }
    }

    private static Menu InitializeMenuWithRole(ApplicationContext<User> userContext, ApplicationContext<Person> personContext)
    {

        var mainMenu = new Menu("MainMenu");

        var personMainMenu = mainMenu.Add(new Menu("People"));

        personMainMenu.Add(new AddPerson("Add", personContext.Items));
        var personSelectionMenu = personMainMenu.Add(new SelectionMenu<Person>("Selection menu", personContext));
        var personSearch = personMainMenu.Add(new SearchListItem<Person>("Search", personContext));

        var personControlMenu = personSelectionMenu.Add(new ControlMenu<Person>("Control menu", personContext));
        personSearch.Add(personControlMenu);

        if (userContext.CurrentUser!.Role == Role.Admin)
        {
            var userMainMenu = mainMenu.Add(new Menu("Users"));

            userMainMenu.Add(new AddUser("Add", userContext.Items));
            var userSelectionMenu = userMainMenu.Add(new SelectionMenu<User>("Selection menu", userContext));
            var userSearch = userMainMenu.Add(new SearchListItem<User>("Search", userContext));

            var userControlMenu = userSelectionMenu.Add(new ControlMenu<User>("Control menu", userContext));
            userSearch.Add(userControlMenu);

            userControlMenu.Add(new EditUserName("Edit Name", userContext));
            userControlMenu.Add(new EditUserPassword("Edit password", userContext));
            userControlMenu.Add(new EditUserRole("Edit role", userContext));
            userControlMenu.Add(new RemoveListItem<User>("Remove", userContext));
            personControlMenu.Add(new EditPersonName("Edit name", personContext));
            personControlMenu.Add(new EditPersonAge("Edit age", personContext));
            personControlMenu.Add(new RemoveListItem<Person>("Remove", personContext));
        }

        return mainMenu;
    }

    private static User? DoAuthorization(List<User> users)
    {
        var authUser = new User();
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        var userActions = new UserActions();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----- Authorization -----");
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
            var status = userActions.FindUser(users, authUser);
            if (status != null)
            {
                consoleWriter.WriteMessage("Login Successful", ConsoleColor.Green);
                return users[(int)status];
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