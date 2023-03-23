class User
{
    public string? Login;
    public string? Password;
    public Program.Role Role;

    public User(string login = "User", string password = "User", Program.Role role = Program.Role.User )
    {
        Login = login;
        Password = password;
        Role = role;
    }
}