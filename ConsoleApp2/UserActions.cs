﻿internal class UserActions : DataActions
{
    public void Add(List<User> Users)
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
            if (CheckRepetitions(Users, user) is not null)
                consoleWriter.WriteMessage("Такой человек уже существует", ConsoleColor.Red);
            else
                break;
        }
        consoleWriter.WriteMessage("Успешное добавление", ConsoleColor.Green);
        Users.Add(user);
    }

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

    public int? CheckRepetitions(List<User> Users, User user)
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
