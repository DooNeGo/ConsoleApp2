internal class DataActions
{
    public bool ShowList<T>(List<T> List)
    {
        var consoleWriter = new ConsoleWriter();
        Console.Clear();
        if (List.Count == 0)
        {
            consoleWriter.WriteMessage("Пусто...");
            return false;
        }
        for (int i = 0; i < List.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            if (List is List<User> Users)
                consoleWriter.WriteListItem(Users[i]);
            else if (List is List<Person> People)
                consoleWriter.WriteListItem(People[i]);
            else
                throw new Exception();
        }
        return true;
    }

    public void Remove<T>(List<T> List)
    {
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            var value = SelectListItem(List);
            if (value is null)
                return;
            List.RemoveAt((int)value - 1);
            consoleWriter.WriteMessage("Успешное удаление", ConsoleColor.Green);
        }
    }

    private protected int? SelectListItem<T>(List<T> List)
    {
        var consoleWriter = new ConsoleWriter();
        var consoleReader = new ConsoleReader();
        while (true)
        {
            ShowList(List);
            if (List.Count == 0)
                return null;
            Console.Write("Введите номер (0 - Назад): ");
            int? value = consoleReader.ReadInt();
            if (value == 0)
                return null;
            else if (value > 1 && value <= List.Count)
                return value;
            else
                consoleWriter.WriteMessage("Неверное значение", ConsoleColor.Red);
        }
    }
}
