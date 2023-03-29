abstract class DataActions<P>
{
    public abstract P? Add();

    public bool CheckRepetitions<T>(List<T> list, T newItem)
    {
        foreach (T item in list)
        {
            if (item!.Equals(newItem))
                return true;
        }
        return false;
    }

    public bool ShowList<T>(List<T> list)
    {
        var consoleWriter = new ConsoleWriter();
        Console.Clear();
        if (list.Count == 0)
        {
            consoleWriter.WriteMessage("Empty...");
            return false;
        }
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            if (list is List<User> users)
                consoleWriter.WriteListItem(users[i]);
            else if (list is List<Person> people)
                consoleWriter.WriteListItem(people[i]);
            else
                throw new Exception();
        }
        return true;
    }

    public void Remove<T>(List<T> list)
    {
        var consoleWriter = new ConsoleWriter();
        while (true)
        {
            var value = SelectListItem(list);
            if (value is null)
                return;
            list.RemoveAt((int)value - 1);
            consoleWriter.WriteMessage("Success", ConsoleColor.Green);
        }
    }

    public int? SelectListItem<T>(List<T> list)
    {
        var consoleWriter = new ConsoleWriter();
        var consoleReader = new ConsoleReader();
        while (true)
        {
            ShowList(list);
            if (list.Count == 0)
                return null;
            Console.Write("Enter number (0 - Назад): ");
            int? value = consoleReader.ReadInt();
            if (value == 0)
                return null;
            else if (value > 1 && value <= list.Count)
                return value;
            else
                consoleWriter.WriteMessage("Wrong number", ConsoleColor.Red);
        }
    }
}
