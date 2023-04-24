internal record User
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
            if (value is not null)
                password = Convert.ToString(value.GetHashCode());
            else
                password = value;
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Username, Password, Role);
    }
}