internal record Person
{
    public string? Name { get; set; }
    public int? Age { get; set; }

    public Person(string name = "Undefined", int age = 0)
    {
        Name = name;
        Age = age;
    }
}