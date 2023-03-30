internal class AddUser : ExtendUserMainMenu
{
    public AddUser(List<User>? users, string menuItem = "Add") : base(users, menuItem)
    { }

    public override void Process()
    {
        var userActions = new UserActions();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
        if (HasErrors())
            return;
            var newUser = userActions.AddNewListItem();
            if (newUser is null)
                return;
            if (userActions.CheckRepetitions(users, newUser) is false)
            {
                users?.Add(newUser);
                consoleWriter.WriteMessage("Success", ConsoleColor.Green);
            }
            else
            {
                consoleWriter.WriteMessage("This user already exist", ConsoleColor.Red);
            }
        }
    }
}