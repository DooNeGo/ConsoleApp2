internal class User
{
    public string? Username { get; set; }
    private string? password;
    public Program.Role? Role { get; set; }

    public User(string username = "Undefined", string password = "", Program.Role role = Program.Role.USER)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public string? Password
    {
        get { return password; }
        set
        {
            if (value is null)
                password = value;
            else
                password = Convert.ToString(value.GetHashCode());
        }
    }

    public override int GetHashCode() => HashCode.Combine(Username, Password, Role);

    public override bool Equals(object? obj) => obj is User user && Username == user.Username;

    public override string? ToString() => "Username: " + Username + "  Role: " + Role;
}