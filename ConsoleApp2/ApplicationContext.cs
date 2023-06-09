﻿internal class ApplicationContext<T>
{
    public List<T> Items { get; init; }
    public List<T>? FoundItems { get; set; }
    public T? CurrentItem { get; set; }
    public User? CurrentUser { get; set; }
    public ApplicationContext(List<T> items)
    {
        Items = items;
    }
}