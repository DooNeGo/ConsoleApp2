internal class Program
{
    private static void Main()
    {
        var users = new List<User>
        {
            new User("admin", "admin", Role.ADMIN),
            new User("user", "", Role.USER),
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

        var personSelectionMenu = personMainMenu.Add(new SelectionMenu<Person>("Selection menu", personContext));
        var personSearch = personMainMenu.Add(new SearchMenu<Person>("Search", personContext));
        personMainMenu.Add(new MenuLeaf<Person>("Add", personContext, (personContext, consoleWriter, consoleReader, consoleDialog) =>
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- Person add -----");
                var newPerson = consoleDialog.GetPersonDialog();
                if (newPerson == null)
                    return;
                if (!personContext.Items.Exists(person => person.Equals(newPerson)))
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

        var personControlMenu = personSelectionMenu.Add(new ControlMenu<Person>("Control menu", personContext));
        personSearch.Add(personControlMenu);

        if (userContext.CurrentUser!.Role == Role.ADMIN)
        {
            var userMainMenu = mainMenu.Add(new Menu("Users"));

            userMainMenu.Add(new MenuLeaf<User>("Add", userContext, (userContext, consoleWriter, consoleReader, consoleDialog) =>
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("----- User add -----");
                    var newUser = consoleDialog.GetUserDialog();
                    if (newUser is null)
                        return;
                    if (!userContext.Items.Exists(user => user.Equals(newUser)))
                    {
                        userContext.Items.Add(newUser);
                        consoleWriter.WriteMessage("Success", ConsoleColor.Green);
                    }
                    else
                        consoleWriter.WriteMessage("This user already exist", ConsoleColor.Red);
                }
            }));

            var userSelectionMenu = userMainMenu.Add(new SelectionMenu<User>("Selection menu", userContext));
            var userSearch = userMainMenu.Add(new SearchMenu<User>("Search", userContext));

            var userControlMenu = userSelectionMenu.Add(new ControlMenu<User>("Control menu", userContext));
            userSearch.Add(userControlMenu);

            userControlMenu.Add(new MenuLeaf<User>("Edit Name", userContext, (userContext, consoleWriter, consoleReader, consoleDialog) =>
            {
                var usernameNew = consoleDialog.GetUsenameDialog();
                if (usernameNew is null)
                    return;
                userContext.CurrentItem!.Username = usernameNew;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            userControlMenu.Add(new MenuLeaf<User>("Edit password", userContext, (userContext, consoleWriter, consoleReader, consoleDialog) =>
            {
                var passwordNew = consoleDialog.GetPasswordDialog();
                if (passwordNew is null)
                    return;
                userContext.CurrentItem!.Password = passwordNew;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            userControlMenu.Add(new MenuLeaf<User>("Edit role", userContext, (userContext, consoleWriter, consoleReader, consoleDialog) =>
            {
                var roleNew = consoleDialog.GetRoleDialog();
                if (roleNew is null)
                    return;
                userContext.CurrentItem!.Role = roleNew;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            userControlMenu.Add(new MenuLeaf<User>("Remove", userContext, (context, consoleWriter, consoleReader, consoleDialog) =>
            {
                if (context.CurrentUser != context.CurrentItem)
                {
                    context.Items.Remove(context.CurrentItem!);
                    context.FoundItems?.Remove(context.CurrentItem!);
                    consoleWriter.WriteMessage("Successful delete", ConsoleColor.Green);
                }
                else
                    consoleWriter.WriteMessage("You can not delete the active user", ConsoleColor.Red);
            }));

            personControlMenu.Add(new MenuLeaf<Person>("Edit name", personContext, (personContext, consoleWriter, consoleReader, consoleDialog) =>
            {
                string? newName = consoleDialog.GetPersonNameDialog();
                if (newName is null)
                    return;
                personContext.CurrentItem!.Name = newName;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            personControlMenu.Add(new MenuLeaf<Person>("Edit age", personContext, (personContext, consoleWriter, consoleReader, consoleDialog) =>
            {
                var ageNew = consoleDialog.GetPersonAgeDialog();
                if (ageNew is null || ageNew == 0)
                    return;
                personContext.CurrentItem!.Age = ageNew;
                consoleWriter.WriteMessage("Successful edit", ConsoleColor.Green);
            }));

            personControlMenu.Add(new MenuLeaf<Person>("Remove", personContext, (personContext, consoleWriter, consoleReader, consoleDialog) =>
            {
                personContext.Items.Remove(personContext.CurrentItem!);
                personContext.FoundItems?.Remove(personContext.CurrentItem!);
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
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----- Authorization -----");
            Console.Write("Username (0 - Exit): ");
            authUser.Username = consoleReader.ReadString();
            if (authUser.Username is null)
                return null;
            Console.Write("Password (0 - Exit): ");
            authUser.Password = consoleReader.ReadString();
            if (authUser.Password is null)
                return null;
            var status = users.Find(user => user.Username == authUser.Username && user.Password == authUser.Password);
            if (status != null)
            {
                consoleWriter.WriteMessage("Login Successful", ConsoleColor.Green);
                return status;
            }
            else
            {
                consoleWriter.WriteMessage("Wrong username or password", ConsoleColor.Red);
            }
        }
    }

    public enum Role : byte
    {
        USER,
        ADMIN
    }

}