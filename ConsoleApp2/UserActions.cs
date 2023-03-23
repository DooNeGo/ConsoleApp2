class UserActions
{
    public static void Remove(List<User> Users)
    {
        while (true)
        {
            var value = SelectUser(Users);
            if (value is null)
                return;
            Users.RemoveAt((int)value - 1);
            ConsoleRead_Write.WriteMessage("Успешное удаление", "Green");
        }
    }

    public static void ShowList(List<User> Users)
    {
        Console.Clear();
        if (Users.Count == 0)
        {
            ConsoleRead_Write.WriteMessage("Пусто...");
            return;
        }
        for (int i = 0; i < Users.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            ConsoleRead_Write.WriteUser(Users[i]);
        }
    }

    public static void Add(List<User> Users)
    {
        User user = new();
        while (true)
        {
            Console.Clear();
            Console.Write("Введите логин (0 - Назад): ");
            user.Login = ConsoleRead_Write.ReadString();
            if (user.Login is null)
                return;
            Console.Write("Введите пароль (0 - Назад): ");
            user.Password = ConsoleRead_Write.ReadString();
            if (user.Password is null)
                return;
            while (true)
            {
                Console.Write("Введите роль (0 - Назад 1 - Пользователь 2 - Админ): ");
                var value = ConsoleRead_Write.ReadInt();
                switch (value)
                {
                    case 0:
                        return;
                    case 1:
                    case 2:
                        user.Role = (Program.Role)value - 1;
                        break;
                    default:
                        ConsoleRead_Write.WriteMessage("Неверное значение", "Red");
                        continue;
                }
                break;
            }
            if (CheckRepetitions(Users, user) is not null)
                ConsoleRead_Write.WriteMessage("Такой человек уже существует", "Red");
            else
                break;
        }
        ConsoleRead_Write.WriteMessage("Успешное добавление", "Green");
        Users.Add(user);
    }

    public static void Edit(List<User> Users)
    {
        var EditMenuItems = new string[] { "Назад", "Логин", "Пароль" };
        var UserNum = SelectUser(Users);
        if (UserNum is null)
            return;
        while (true)
        {
            ConsoleRead_Write.WriteMenu(EditMenuItems, " Изменить ");
            var value = ConsoleRead_Write.ReadInt();
            
        }
    }

    public static int? CheckRepetitions(List<User> Users, User user)
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

    private static int? SelectUser(List<User> Users)
    {
        while (true)
        {
            ShowList(Users);
            if (Users.Count == 0)
                return null;
            Console.Write("Введите номер пользователя (0 - Назад): ");
            int? value = ConsoleRead_Write.ReadInt();
            if (value == 0)
                return null;
            else if (value > 1 && value <= Users.Count)
                return value;
            else
                ConsoleRead_Write.WriteMessage("Неверное значение", "Red");
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
