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

        else if (context is ApplicationContext<User> userContext)
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

        else
        {
            throw new NotImplementedException();
        }
    }
}
