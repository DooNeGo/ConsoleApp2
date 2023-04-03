internal class User
{
    public string? Username { get; set; }
    private string? password;
    public Program.Role? Role { get; set; }

    public User(string username = "Undefined", string password = "", Program.Role role = Program.Role.User)
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
            if (value is not null)
                password = Convert.ToString(value!.GetHashCode());
            else
                password = value;
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is User user &&
               Username == user.Username;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Username, Password, Role);
    }
}