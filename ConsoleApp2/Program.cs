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

        personMainMenu.Add(new MenuLeaf<Person>("Add", personContext, personContext =>
        {
            var personActions = new PersonActions();
            var consoleWriter = new ConsoleWriter();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- Person add -----");
                var newPerson = personActions.AddNewListItem();
                if (newPerson == null)
                    return;
                if (personActions.CheckRepetitions(personContext.Items, newPerson) is false)
                {
                    personContext.Items.Add(newPerson);
                    consoleWriter.WriteMessage("Successful add", ConsoleColor.Green);
                }
                else
                {
                    consoleWriter.WriteMessage("This person already exist", ConsoleColor.Red);
                }
            }
        }));
        var personSelectionMenu = personMainMenu.Add(new SelectionMenu<Person>("Selection menu", personContext));
        var personSearch = personMainMenu.Add(new SearchListItem<Person>("Search", personContext));

        var personControlMenu = personSelectionMenu.Add(new ControlMenu<Person>("Control menu", personContext));
        personSearch.Add(personControlMenu);

        if (userContext.CurrentUser!.Role == Role.Admin)
        {
            var userMainMenu = mainMenu.Add(new Menu("Users"));

            userMainMenu.Add(new MenuLeaf<User>("Add", userContext, userContext =>
            {
                Console.Clear();
                Console.WriteLine("----- User add -----");
                var userActions = new UserActions();
                var consoleWriter = new ConsoleWriter();
                while (true)
                {
                    var newUser = userActions.AddNewListItem();
                    if (newUser is null)
                        return;
                    if (userActions.CheckRepetitions(userContext.Items, newUser) is false)
                    {
                        userContext.Items.Add(newUser);
                        consoleWriter.WriteMessage("Success", ConsoleColor.Green);
                    }
                    else
                        consoleWriter.WriteMessage("This user already exist", ConsoleColor.Red);
                }
            }));
            var userSelectionMenu = userMainMenu.Add(new SelectionMenu<User>("Selection menu", userContext));
            var userSearch = userMainMenu.Add(new SearchListItem<User>("Search", userContext));

            var userControlMenu = userSelectionMenu.Add(new ControlMenu<User>("Control menu", userContext));
            userSearch.Add(userControlMenu);

            userControlMenu.Add(new MenuLeaf<User>("Edit Name", userContext, userContext =>
            {
                Console.Clear();
                var userActions = new UserActions();
                var consoleWriter = new ConsoleWriter();
                var usernameNew = userActions.GetUsenameFromConsole();
                if (usernameNew is null)
                    return;
                userContext.CurrentItem!.Username = usernameNew;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            userControlMenu.Add(new MenuLeaf<User>("Edit password", userContext, userContext =>
            {
                Console.Clear();
                var consoleWriter = new ConsoleWriter();
                var userActions = new UserActions();
                var passwordNew = userActions.GetPasswordFromConsole();
                if (passwordNew is null)
                    return;
                userContext.CurrentItem!.Password = passwordNew;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            userControlMenu.Add(new MenuLeaf<User>("Edit role", userContext, userContext =>
            {
                Console.Clear();
                var consoleWriter = new ConsoleWriter();
                var userActions = new UserActions();
                var roleNew = userActions.GetRoleFromConsole();
                if (roleNew is null)
                    return;
                userContext.CurrentItem!.Role = roleNew;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            userControlMenu.Add(new MenuLeaf<User>("Remove", userContext, context =>
            {
                var consoleWriter = new ConsoleWriter();
                if (context.CurrentUser != context.CurrentItem)
                {
                    context.Items.Remove(context.CurrentItem!);
                    context.FoundItems?.Remove(context.CurrentItem!);
                    consoleWriter.WriteMessage("Successful delete", ConsoleColor.Green);
                }
                else
                    consoleWriter.WriteMessage("You can not delete the active user", ConsoleColor.Red);
            }));

            personControlMenu.Add(new MenuLeaf<Person>("Edit name", personContext, personContext =>
            {
                Console.Clear();
                var consoleWriter = new ConsoleWriter();
                var personActions = new PersonActions();
                string? newName = personActions.GetName();
                if (newName is null)
                    return;
                personContext.CurrentItem!.Name = newName;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            personControlMenu.Add(new MenuLeaf<Person>("Edit age", personContext, personContext =>
            {
                Console.Clear();
                var consoleWriter = new ConsoleWriter();
                var personActions = new PersonActions();
                var ageNew = personActions.GetAge();
                if (ageNew is null || ageNew == 0)
                    return;
                personContext.CurrentItem!.Age = ageNew;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            personControlMenu.Add(new MenuLeaf<Person>("Remove", personContext, context =>
            {
                var consoleWriter = new ConsoleWriter();
                context.Items.Remove(context.CurrentItem!);
                context.FoundItems?.Remove(context.CurrentItem!);
                consoleWriter.WriteMessage("Successful delete", ConsoleColor.Green);
            }));
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