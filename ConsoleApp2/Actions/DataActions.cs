internal class DataActions
{
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

    public void Search<T>(ApplicationContext<T> context)
    {
        var consoleReader = new ConsoleReader();
        Console.Clear();
        Console.Write("Search (0 - Return): ");
        var compare = consoleReader.ReadString();
        if (compare is null)
            return;
        compare = compare.ToLower();
        if (context is ApplicationContext<Person> personContext)
        {
            personContext.FoundItems = new();
            foreach (var person in personContext.Items)
            {
                var ageString = person.Age.ToString()!.ToLower();
                if (person.Name!.ToLower().Contains(compare) || ageString.Contains(compare))
                {
                    personContext.FoundItems.Add(person);
                }
            }
            return;
        }
        if (context is ApplicationContext<User> userContext)
        {
            userContext.FoundItems = new();
            foreach (var user in userContext.Items)
            {
                if (user.Username!.ToLower().Contains(compare))
                {
                    userContext.FoundItems.Add(user);
                }
            }
            return;
        }
    }

    public bool ShowList<T>(List<T>? list)
    {
        var consoleWriter = new ConsoleWriter();
        Console.Clear();
        Console.WriteLine($"-----List-----");
        if (list is null || list.Count == 0)
        {
            Console.WriteLine("Empty...");
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
