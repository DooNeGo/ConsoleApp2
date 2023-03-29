internal class UserActions : DataActions<User>
{
    public void Edit(List<User> Users)
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        var EditMenuItems = new string[] { "Назад", "Логин", "Пароль" };
        var UserNum = SelectListItem(Users);
        if (UserNum is null)
            return;
        while (true)
        {
            consoleWriter.WriteMenu(EditMenuItems, " Изменить ");
            var value = consoleReader.ReadInt();

        }
    }

    public int? FindUser(List<User> Users, User user)
    {
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Login == user.Login)
            {
                return i;
            }
        }
        return null;
    }

    public override User? Add()
    {
        User user = new();
        Console.Clear();
        user.Login = GetLogin();
        if (user.Login is null)
            return null;
        user.Password = GetPassword();
        if (user.Password is null)
            return null;
        user.Role = GetRole();
        if (user.Role is null)
            return null;
        return user;

    }

    private string? GetLogin()
    {
        var consoleReader = new ConsoleReader();
        Console.Write("Enter login (0 - Return): ");
        return consoleReader.ReadString();
    }

    private string? GetPassword()
    {
        var consoleReader = new ConsoleReader();
        Console.Write("Enter password (0 - Return): ");
        return consoleReader.ReadString();
    }

    private Program.Role? GetRole()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            Console.Write("Enter role (0 - Return 1 - User 2 - Admin): ");
            var value = consoleReader.ReadInt();
            switch (value)
            {
                case 0:
                    return null;
                case 1:
                case 2:
                    return (Program.Role)value - 1;
                default:
                    consoleWriter.WriteMessage("Неверное значение", ConsoleColor.Red);
                    continue;
            }
        }

    }

    private enum EditMenuItem : byte
    {
        Return,
        Login,
        Password,
        Role
    }
}
