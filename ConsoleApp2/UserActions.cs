internal class UserActions : DataActions
{
    public static void Add(List<User> Users)
    {
        User user = new();
        while (true)
        {
            Console.Clear();
            Console.Write("Введите логин (0 - Назад): ");
            user.Login = ConsoleInteraction.ReadString();
            if (user.Login is null)
                return;
            Console.Write("Введите пароль (0 - Назад): ");
            user.Password = ConsoleInteraction.ReadString();
            if (user.Password is null)
                return;
            while (true)
            {
                Console.Write("Введите роль (0 - Назад 1 - Пользователь 2 - Админ): ");
                var value = ConsoleInteraction.ReadInt();
                switch (value)
                {
                    case 0:
                        return;
                    case 1:
                    case 2:
                        user.Role = (Program.Role)value - 1;
                        break;
                    default:
                        ConsoleInteraction.WriteMessage("Неверное значение", "Red");
                        continue;
                }
                break;
            }
            if (CheckRepetitions(Users, user) is not null)
                ConsoleInteraction.WriteMessage("Такой человек уже существует", "Red");
            else
                break;
        }
        ConsoleInteraction.WriteMessage("Успешное добавление", "Green");
        Users.Add(user);
    }

    public static void Edit(List<User> Users)
    {
        var EditMenuItems = new string[] { "Назад", "Логин", "Пароль" };
        var UserNum = SelectListItem(Users);
        if (UserNum is null)
            return;
        while (true)
        {
            ConsoleInteraction.WriteMenu(EditMenuItems, " Изменить ");
            var value = ConsoleInteraction.ReadInt();

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

    private enum EditMenuItem : byte
    {
        Return,
        Login,
        Password,
        Role
    }
}
