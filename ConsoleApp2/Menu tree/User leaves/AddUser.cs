﻿internal class AddUser : MainMenu
{
    public AddUser(List<User>? users, string menuItem = "Add") : base(menuItem: menuItem, users:users)
    { }

    public override void Process()
    {
        var userActions = new UserActions();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            var newUser = userActions.Add();
            if (newUser is null)
                return;
            if (userActions.CheckRepetitions(users!, newUser) is false)
            {
                users?.Add(newUser);
                consoleWriter.WriteMessage("Success", ConsoleColor.Green);
            }
            else
            {
                consoleWriter.WriteMessage("This person already exist", ConsoleColor.Red);
            }
        }
    }
}