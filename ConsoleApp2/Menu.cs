static class Menu
{
    public static void Show(string[] MenuItems, string prefix = " ")
    {
        Console.Clear();
        if (MenuItems.Length < 1)
        {
            Console.WriteLine("There is no menu items");
            return;
        }
        for (int i = 1; i < MenuItems.Length; i++)
        {
            Console.WriteLine($"{i} -{prefix}{MenuItems[i]}");
        }
        Console.WriteLine($"0 - {MenuItems[0]}");
    }
}
