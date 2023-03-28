internal class AddUser : MainMenu
{
    public AddUser(string menuItem = "Something...") : base(menuItem)
    {
    }

    private int? CheckRepetitions(List<User> users, User user)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Login == user.Login)
            {
                return i;
            }
        }
        return null;
    }

    public override void Process(List<User> users, List<Person> people)
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();
        User user = new();
        while (true)
        {
            Console.Clear();
            Console.Write("Введите логин (0 - Назад): ");
            user.Login = consoleReader.ReadString();
            if (user.Login is null)
                return;
            Console.Write("Введите пароль (0 - Назад): ");
            user.Password = consoleReader.ReadString();
            if (user.Password is null)
                return;
            while (true)
            {
                Console.Write("Введите роль (0 - Назад 1 - Пользователь 2 - Админ): ");
                var value = consoleReader.ReadInt();
                switch (value)
                {
                    case 0:
                        return;
                    case 1:
                    case 2:
                        user.Role = (Program.Role)value - 1;
                        break;
                    default:
                        consoleWriter.WriteMessage("Неверное значение", ConsoleColor.Red);
                        continue;
                }
                break;
            }
            if (CheckRepetitions(users, user) is not null)
                consoleWriter.WriteMessage("Такой человек уже существует", ConsoleColor.Red);
            else
                break;
        }
        consoleWriter.WriteMessage("Успешное добавление", ConsoleColor.Green);
        users.Add(user);
    }
}

