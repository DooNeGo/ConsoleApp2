internal class Person
{
    public string? Name { get; set; }
    public int? Age { get; set; }

    public Person(string name = "Undefined", int age = 0)
    {
        Name = name;
        Age = age;
    }

    public override bool Equals(object? obj)
    {
        return obj is Person person &&
               Name == person.Name &&
               Age == person.Age;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }
}