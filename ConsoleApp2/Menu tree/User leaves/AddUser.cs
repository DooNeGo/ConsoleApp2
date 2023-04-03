internal class AddUser : Menu
{
    private readonly List<User> users;

    public AddUser(string name, List<User> users) : base(name)
    {
        this.users = users;
    }

    public override void Process()
    {
        var userActions = new UserActions();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----- User add -----");
            var newUser = userActions.AddNewListItem();
            if (newUser is null)
                return;
            if (userActions.CheckRepetitions(users, newUser) is false)
            {
                users.Add(newUser);
                consoleWriter.WriteMessage("Success", ConsoleColor.Green);
            }
            else
            {
                consoleWriter.WriteMessage("This user already exist", ConsoleColor.Red);
            }
        }
    }
}