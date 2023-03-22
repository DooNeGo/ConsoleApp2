internal class User
{
    private string? login;
    private string? password;
    private byte? role;

    public User(string login = "User", string password = "User", byte role = (byte)Program.Role.USER )
    {
        this.login = login;
        this.password = password;
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
        set { password = value; }
    }

    public byte? Role
    {
        get { return role; }
        set { role = value; }
    }
}