class Person
{
    private string? name;
    private int? age;

    public Person(string name = "Undefine", int age = 0)
    {
        this.name = name;
        this.age = age;
    }

    public string? Name
    {
        get { return name; }
        set { name = value; }
    }

    public int? Age
    {
        get { return age; }
        set { age = value; }
    }
}