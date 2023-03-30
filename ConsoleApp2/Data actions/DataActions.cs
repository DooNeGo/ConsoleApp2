using System.Linq.Expressions;

abstract class DataActions<P>
{
    public abstract P? AddUser();

    public bool CheckRepetitions<T>(List<T>? list, T newItem)
    {
        if (list is null)
            return false;
        foreach (T item in list)
        {
            if (item!.Equals(newItem))
                return true;
        }
        return false;
    }

    public bool ShowList<T>(List<T>? list)
    {
        var consoleWriter = new ConsoleWriter();
        Console.Clear();
        if (list is null || list.Count == 0)
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
}
