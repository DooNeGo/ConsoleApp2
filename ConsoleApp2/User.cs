class User
{
    public string? Login;
    private string? password;
    public Program.Role Role;

    public User(string login = "User", string password = "User", Program.Role role = Program.Role.User )
    {
        Login = login;
        Password = password;
        Role = role;
    }

    public string? Password
    {
        get { return password; }
        set
        {
            password = Convert.ToString(value?.GetHashCode());
            if ( value is null )
                password = null;
        }
    }
}