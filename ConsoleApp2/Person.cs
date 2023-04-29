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

    public override bool Equals(object? obj)
    {
        return obj is Person person &&
               Name == person.Name &&
               Age == person.Age;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Age);
}