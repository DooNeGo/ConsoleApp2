internal abstract class DataActions
{
    //public abstract void Add();
    //public abstract void Edit();
    public static void ShowList<T>(List<T> List)
    {
        Console.Clear();
        if (List.Count == 0)
        {
            ConsoleInteraction.WriteMessage("Пусто...");
            return;
        }
        for (int i = 0; i < List.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            if (List is List<User> Users)
                ConsoleInteraction.WriteListItem(Users[i]);
            else if (List is List<Person> People)
                ConsoleInteraction.WriteListItem(People[i]);
            else
                throw new Exception();
        }
    }

    public static void Remove<T>(List<T> List)
    {
        while (true)
        {
            var value = SelectListItem(List);
            if (value is null)
                return;
            List.RemoveAt((int)value - 1);
            ConsoleInteraction.WriteMessage("Успешное удаление", "Green");
        }
    }

    private static int? SelectListItem<T>(List<T> List)
    {
        while (true)
        {
            ShowList(List);
            if (List.Count == 0)
                return null;
            Console.Write("Введите номер (0 - Назад): ");
            int? value = ConsoleInteraction.ReadInt();
            if (value == 0)
                return null;
            else if (value > 1 && value <= List.Count)
                return value;
            else
                ConsoleInteraction.WriteMessage("Неверное значение", "Red");
        }
    }
}
