internal class Person
{
    public string? Name { get; set; }
    public int? Age { get; set; }

    public Person(string name = "Undefined", int age = 0)
    {
        Name = name;
        Age = age;
    }

    public override string? ToString() => "Name: " + Name + "  Age: " + Age;
}