internal class User
{
    private string? login;
    private string? password;
    private Program.Role? role;

    public User(string login = "User", string password = "User", Program.Role role = Program.Role.User)
    {
        this.login = login;
        Password = password;
        this.role = role;
    }

    public string? Login
    { 
        get { return login; }
        set { login = value; }
    }

    public string? Password
    {
        get { return password; }
        set
        {
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
               Login == user.Login;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Login, Password, Role);
    }
}