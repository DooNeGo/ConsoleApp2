internal class User
{
    private string? username;
    private string? password;
    private Program.Role? role;

    public User(string username = "user", string password = "", Program.Role role = Program.Role.User)
    {
        this.username = username;
        Password = password;
        this.role = role;
    }

    public string? Username
    { 
        get { return username; }
        set { username = value; }
    }

    public string? Password
    {
        get { return password; }
        set
        {
            if (value is null)
                password = null;
            else
                password = Convert.ToString(value!.GetHashCode());
        }
    }

    public Program.Role? Role
    { 
        get { return role; }
        set { role = value; }
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